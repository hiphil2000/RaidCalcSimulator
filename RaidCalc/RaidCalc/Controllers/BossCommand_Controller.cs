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
        private string _SelectedPlayerName;

        private List<ICommands> _CommandQueue;

        public BossCommand_Controller(RaidCalcWindow mainFrame, IView view)
        {
            MainFrame = mainFrame;
            View = view;
            _CommandQueue = new List<ICommands>();
        }
        public void InitData()
        {
            BossCommand_View view = View as BossCommand_View;
            AddPlayers(MainFrame.GetPlayerList());
            foreach (var item in _PlayerList)
            {
                view.GridItem.points.Add(item.Name, new Point(item.PosX, item.PosY));
                Console.WriteLine($" 플레이어 확인: name: {item.Name}, position: {new Point(item.PosX, item.PosY)}");
            }
            SetBoss(MainFrame.GetBoss());
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

        public void SetBoss(Player player)
        {
            BossCommand_View view = View as BossCommand_View;
            view.SetBoss(player);
        }

        public void GridClicked(Point location)
        {
            BossCommand_View view = View as BossCommand_View;
            Player p = view.Boss;

            if (p.PosX < 0 || p.PosY < 0)
            {
                var moveSkill = MainFrame.GetSkillByName("이동");
                var gridPoint = view.GridItem.ToGridLocation(location);
                if (view.GridItem.DuplicateCheck(gridPoint) == true)
                {
                    MessageBox.Show("해당 위치에는 이미 엔티티가 있습니다.", "실패");
                    return;
                }
                if (_CommandQueue.FirstOrDefault(x => x.SourcePlayer.Name.Equals(p.Name) && x.UsedSkill.Name.Equals("이동")) != null)
                {
                    if (MessageBox.Show($"{p.Name}은 이미 이동 위치를 결정했습니다. 다시 설정하시겠습니까?[{gridPoint.X}:{gridPoint.Y}]", "재설정", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Command command = new Command(p, null, gridPoint, moveSkill);
                        _CommandQueue.Remove(_CommandQueue.First(x => x.SourcePlayer.Name.Equals(p.Name)));
                        _CommandQueue.Add(command);
                        view.GridItem.RemovePoint(p.Name);
                        view.GridItem.AddPoint(p.Name, location, "Boss");
                    }
                }
                else
                {
                    if (MessageBox.Show($"{p.Name}의 위치를 [{gridPoint.X}:{gridPoint.Y}]로 설정하시겠습니까?", "설정", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Command command = new Command(p, null, view.GridItem.ToGridLocation(location), moveSkill);
                        _CommandQueue.Add(command);
                        view.GridItem.AddPoint(p.Name, location, "Boss");
                    }
                }
                view.GridItem.DrawGrid();
            }
            else
            {

            }
        }

        public bool NextPage()
        {
            return Validation();
            MainFrame.SetBossQueue(_CommandQueue);
        }

        private bool Validation()
        {
            BossCommand_View view = View as BossCommand_View;
            if (view.GridItem.points.ContainsKey(view.Boss.Name) == false)
            {
                MessageBox.Show("보스의 위치가 정해지지 않았습니다.");
                return false;
            }
            return true;
        }
    }
}
