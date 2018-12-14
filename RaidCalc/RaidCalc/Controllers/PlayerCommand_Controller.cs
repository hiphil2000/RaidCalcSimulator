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
                        view.GridItem.AddPoint(_SelectedPlayerName, location);
                    }
                }
                else
                {
                    if (MessageBox.Show($"{p.Name}의 위치를 [{gridPoint.X}:{gridPoint.Y}]로 설정하시겠습니까?", "설정", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Command command = new Command(p, null, view.GridItem.ToGridLocation(location), moveSkill);
                        _CommandQueue.Add(command);
                        view.GridItem.AddPoint(_SelectedPlayerName, location);
                    }
                }
                view.GridItem.DrawGrid();
            }
            else
            {
                var pitem = view.FindPlayerItemByName(p.Name);
                if (pitem.SelectedSkillName == null)
                {
                    MessageBox.Show($"{p.Name}의 스킬을 먼저 선택하십시오.", "실패");
                    return;
                }
                var skill = MainFrame.GetSkillByName(pitem.SelectedSkillName.ToString());
                var gridPoint = view.GridItem.ToGridLocation(location);
                if (MessageBox.Show($"[{skill}](을)를 [{gridPoint.ToString()}]에 사용합니까?", "확인") == DialogResult.Yes)
                {
                    string message = "";
                    DialogResult messageResult = DialogResult.No;
                    try { var destination = view.GridItem.GetPlayerNameByPoint(gridPoint); }
                    catch (Exception ex)
                    {
                        message += ex.Message;
                    }
                    if (message.Length > 0)
                    {
                        messageResult = MessageBox.Show($"{message} 그래도 진행합니까?", "경고");
                    }
                    if (message.Length <= 0 || messageResult == DialogResult.Yes)
                    {
                        Command command = new Command(p, null, view.GridItem.ToGridLocation(location), skill);
                        _CommandQueue.Add(command);
                        view.GridItem.AddPoint(_SelectedPlayerName, location);
                    }
                }
            }
        }

        public void InitData()
        {
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
            if (Validation())
            {
                MainFrame.SetQueue(_CommandQueue);
            }
            return true;
        }
        private bool Validation()
        {
            bool isValidated = false;
            PlayerCommand_View view = View as PlayerCommand_View;
            StringBuilder errorMsg = new StringBuilder();
            foreach (var item in _PlayerList)
            {
                if (view.GridItem.points.ContainsKey(item.Name) == false)
                {
                    errorMsg.AppendLine($"{item.Name}의 위치가 정해지지 않았습니다.");
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
