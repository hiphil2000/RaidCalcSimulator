using RaidCalc.Interfaces;
using RaidCalc.Views;
using RaidCalcCore.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaidCalc.Controllers
{
    public class PlayerCommand_Controller : IController
    {
        public IView View { get; set; }
        public RaidCalcWindow MainFrame { get; set; }

        private Player _Boss;
        private List<Player> _PlayerList;
        private string _SelectedPlayerName;

        private List<ICommands> _CommandQueue;

        public PlayerCommand_Controller(RaidCalcWindow mainFrame, IView view)
        {
            MainFrame = mainFrame;
            View = view;
            _CommandQueue = new List<ICommands>();
            view.Clear();
        }

        public void PlayerClicked(string name)
        {
            PlayerCommand_View view = View as PlayerCommand_View;
            if (string.IsNullOrEmpty(_SelectedPlayerName))
            {
                _SelectedPlayerName = name;
                view.SelectPlayer(_SelectedPlayerName);
            }
            else if (_SelectedPlayerName.Equals(name) == true)
            {
                view.DeSelectPlayer(_SelectedPlayerName);
                _SelectedPlayerName = null;
            }
            else if (_SelectedPlayerName.Equals(name) == false)
            {
                view.DeSelectPlayer(_SelectedPlayerName);
                _SelectedPlayerName = name;
                view.SelectPlayer(_SelectedPlayerName);
            }

        }

        public void GridClicked(Point location)
        {
            PlayerCommand_View view = View as PlayerCommand_View;
            
            Player p = _PlayerList.FirstOrDefault(x => x.Name.Equals(_SelectedPlayerName));
            if (p == null)
            {
                MessageBox.Show("플레이어를 선택하세요.", "실패");
                return;
            }

            if (p.PosX < 0 || p.PosY < 0)
            {
                var moveSkill = p.CommonSkills.FirstOrDefault(x => x.Name.Equals("이동"));
                if (moveSkill == null) {
                    moveSkill = MainFrame.GetSkillByName("이동");
                }
                var gridPoint = view.GridItem.ToGridLocation(location);
                if (_CommandQueue.FirstOrDefault(x => x.SourcePlayer.Name.Equals(p.Name)) != null)
                {
                    if (MessageBox.Show($"{p.Name}은 이미 이동 위치를 결정했습니다. 다시 설정하시겠습니까?[{gridPoint.X}:{gridPoint.Y}]","재설정", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Command command = new Command(p, null, gridPoint, moveSkill);
                        _CommandQueue.Remove(_CommandQueue.First(x => x.SourcePlayer.Equals(p)));
                        _CommandQueue.Add(command);
                        view.GridItem.RemovePoint(_SelectedPlayerName);
                        view.GridItem.AddRealPoint(_SelectedPlayerName, gridPoint);
                    }
                }
                else
                {
                    if (MessageBox.Show($"{p.Name}의 위치를 [{gridPoint.X}:{gridPoint.Y}]로 설정하시겠습니까?", "설정", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Command command = new Command(p, null, view.GridItem.ToGridLocation(location), moveSkill);
                        _CommandQueue.Add(command);
                        view.GridItem.RemovePoint(_SelectedPlayerName);
                        view.GridItem.AddRealPoint(_SelectedPlayerName, gridPoint);
                    }
                }
            }
            else
            {
                var pitem = view.FindPlayerItemByName(p.Name);
                if (pitem.SelectedSkillName == null)
                {
                    MessageBox.Show($"{p.Name}의 스킬을 먼저 선택하십시오.", "실패");
                    return;
                }
                ICommands com = null;
                if ((com = _CommandQueue.FirstOrDefault(x => x.SourcePlayer.Name.Equals(_SelectedPlayerName))) != null)
                {
                    var result = MessageBox.Show($"{_SelectedPlayerName}(은)는 이미 {com.UsedSkill.Name}(을)를 {com.DestinationPlayer}에 사용할 것 입니다. 입력을 초기화합니까?", "경고", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        return;
                    else
                    {
                        _CommandQueue.Remove(_CommandQueue.FirstOrDefault(x => x.SourcePlayer.Name.Equals(_SelectedPlayerName)));
                        var original = MainFrame.GetPlayerList().FirstOrDefault(x => x.Name.Equals(_SelectedPlayerName));
                        view.GridItem.RemovePoint(_SelectedPlayerName);
                        view.GridItem.AddRealPoint(_SelectedPlayerName, new Point(original.PosX, original.PosY));
                        view.GridItem.DrawGrid();
                    }
                }
                var skill = MainFrame.GetSkillByName(pitem.SelectedSkillName.ToString());
                var gridPoint = view.GridItem.ToGridLocation(location);
                if (MessageBox.Show($"[{_SelectedPlayerName}]의 스킬 [{skill.Name}](을)를 [{gridPoint.ToString()}]에 사용합니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string message = "";
                    DialogResult messageResult = DialogResult.No;
                    if (!view.GridItem.DuplicateCheck(gridPoint))
                    {
                        message += "해당 위치에 플레이어/엔티티가 없습니다.";
                    }
                    if (message.Length > 0) 
                    {
                        messageResult = MessageBox.Show($"{message} 그래도 진행합니까?", "경고", MessageBoxButtons.YesNo);
                    }
                    if (message.Length <= 0 || messageResult == DialogResult.Yes)
                    {
                        Command command = new Command(p, null, view.GridItem.ToGridLocation(location), skill);
                        _CommandQueue.Add(command);
                    }
                    if (skill.Name.Equals("이동"))
                    {
                        view.GridItem.RemovePoint(_SelectedPlayerName);
                        view.GridItem.AddRealPoint(_SelectedPlayerName, view.GridItem.ToGridLocation(location));
                    }
                }
                view.GridItem.DrawGrid();
            }
        }

        public void InitData()
        {
            PlayerCommand_View view = View as PlayerCommand_View;
            view.GridItem.points.Clear();
            AddPlayers(MainFrame.GetPlayerList());
            SetBoss(MainFrame.GetBoss());
        }

        private void SetBoss(Player player)
        {
            PlayerCommand_View view = View as PlayerCommand_View;
            _Boss = player;
            PlayerItem pitem = view.Controls["BossItem"] as PlayerItem;
            pitem.Player_Name = _Boss.Name;
            pitem.Player_CurrentHealth = _Boss.CurrentHp;
            pitem.Player_MaxHealth = _Boss.MaxHp;
            if (_Boss.PosX > -1 && _Boss.PosY > -1)
                view.GridItem.AddRealPoint(_Boss.Name, new Point(_Boss.PosX, _Boss.PosY));
        }

        public void AddPlayers(List<Player> players)
        {
            PlayerCommand_View view = View as PlayerCommand_View;
            _PlayerList = players;
            foreach (Player player in _PlayerList)
            {
                view.AddPlayer(player);
            }
            view.PlayerCounter = _PlayerList.Count;
        }

        public bool NextPage()
        {
            bool result = Validation();
            if (result)
            {
                MainFrame.SetQueue(_CommandQueue);
                _CommandQueue.Clear();
            }
            return result;
        }

        public List<ISkillBase> GetSkillList(string playerName)
        {
            var player = _PlayerList.FirstOrDefault(x => x.Name.Equals(playerName));
            var turn = MainFrame.GetExacTurn(); 
            var list = player.CommonSkills.Where(x => (x.UsedTurn > 0 && turn - x.Cooltime >= x.UsedTurn) || (x.UsedTurn <= 0)).ToList();
            return list;
        }

        public Player GetBoss()
        {
            return _Boss;
        }

        private bool Validation()
        {
            bool isValidated = false;
            PlayerCommand_View view = View as PlayerCommand_View;
            string errorMsg = "";
            foreach (var item in _PlayerList)
            {
                if (view.GridItem.points.ContainsKey(item.Name) == false)
                {
                    errorMsg += $"{item.Name}의 위치가 정해지지 않았습니다.";
                }
            }
            if (errorMsg.Length <= 0 )
                isValidated = true;
            else
            {
                errorMsg.Insert(0, "유효성 검사에 실패했습니다.\r\n자세한 내용:\r\n");
                MessageBox.Show(errorMsg.ToString(), "실패");
            }
            return isValidated;
        }

    }
}
