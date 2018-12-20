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
    public class BossCommand_Controller : IController
    {
        public IView View { get; set; }
        public RaidCalcWindow MainFrame { get; set; }

        private List<Player> _PlayerList;

        private List<ICommands> _CommandQueue;
        private Boss _Boss;

        public BossCommand_Controller(RaidCalcWindow mainFrame, IView view)
        {
            MainFrame = mainFrame;
            View = view;
            _CommandQueue = new List<ICommands>();
            view.Clear();
        }

        public void InitData()
        {
            BossCommand_View view = View as BossCommand_View;
            view.GridItem.points.Clear();
            AddPlayers(MainFrame.GetPlayerList());
            foreach (var item in _PlayerList)
            {
                view.GridItem.points.Add(item.Name, new Point(item.PosX, item.PosY));
                string msg = $" 플레이어 확인: name: {item.Name}, position: {new Point(item.PosX, item.PosY)}";
                MainFrame.WriteLog(msg);
            }
            SetBoss(MainFrame.GetBoss());
            view.GridItem.DrawGrid();
        }

        public void AddPlayers(List<Player> players)
        {
            BossCommand_View view = View as BossCommand_View;
            _PlayerList = players;
            foreach (Player player in _PlayerList)
            {
                view.AddPlayer(player);
            }
            view.PlayerCounter = _PlayerList.Count;
        }

        public void SetBoss(Boss player)
        {
            BossCommand_View view = View as BossCommand_View;
            _Boss = player;
            if (_Boss.PosX > -1 && _Boss.PosY > -1)
            {
                view.GridItem.AddRealPoint(_Boss.Name, new Point(_Boss.PosX, _Boss.PosY));
                string msg = $" 보스 확인: name: {_Boss.Name}, position: {new Point(_Boss.PosX, _Boss.PosY)}";
                MainFrame.WriteLog(msg);
            }
            view.SetBoss(player);
            view.GetBossitem.Button_Info.Click += (object sender, EventArgs e) =>
            {
                if (view.GetBossitem.Combo_BossList.Text.Length > 0)
                    new RaidCalcInfoWindow(MainFrame.GetBossByName(view.GetBossitem.Combo_BossList.Text)).ShowDialog();
            };
        }

        public Player GetBoss()
        {
            return _Boss;
        }

        public void GridClicked(Point location)
        {
            BossCommand_View view = View as BossCommand_View;

            if (_Boss.PosX < 0 || _Boss.PosY < 0)
            {
                var moveSkill = MainFrame.GetSkillByName("이동");
                var gridPoint = view.GridItem.ToGridLocation(location);
                if (view.GridItem.DuplicateCheck(gridPoint) == true)
                {
                    MessageBox.Show("해당 위치에는 이미 엔티티가 있습니다.", "실패");
                    return;
                }
                if (_CommandQueue.FirstOrDefault(x => x.SourcePlayer.Name.Equals(_Boss.Name) && x.UsedSkill.Name.Equals("이동")) != null)
                {
                    if (MessageBox.Show($"{_Boss.Name}은 이미 이동 위치를 결정했습니다. 다시 설정하시겠습니까?[{gridPoint.X}:{gridPoint.Y}]", "재설정", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Command command = new Command(_Boss, null, gridPoint, moveSkill);
                        _CommandQueue.Remove(_CommandQueue.First(x => x.SourcePlayer.Name.Equals(_Boss.Name)));
                        _CommandQueue.Add(command);
                        view.GridItem.RemovePoint(_Boss.Name);
                        view.GridItem.AddRealPoint(_Boss.Name, gridPoint);
                    }
                }
                else
                {
                    if (MessageBox.Show($"{_Boss.Name}의 위치를 [{gridPoint.X}:{gridPoint.Y}]로 설정하시겠습니까?", "설정", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Command command = new Command(_Boss, null, view.GridItem.ToGridLocation(location), moveSkill);
                        _CommandQueue.Add(command);
                        view.GridItem.AddRealPoint(_Boss.Name, gridPoint);
                    }
                }
                view.GridItem.DrawGrid();
            }
            else
            {
                if (view.GetBossitem.Player_Skills.SelectedItem == null)
                {
                    MessageBox.Show("보스의 스킬을 먼저 선택하십시오.", "실패");
                    return;
                }
                else
                {

                }
            }
        }

        public bool NextPage()
        {
            bool result = Validation();
            if (result)
            {
                MainFrame.SetBossQueue(_CommandQueue);
                _CommandQueue.Clear();
            }
            return result;
        }

        private bool Validation()
        {
            BossCommand_View view = View as BossCommand_View;
            if (view.GridItem.points.ContainsKey(_Boss.Name) == false)
            {
                MessageBox.Show("보스의 위치가 정해지지 않았습니다.");
                return false;
            }
            return true;
        }
    }
}
