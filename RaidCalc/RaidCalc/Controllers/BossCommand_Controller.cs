using RaidCalc.Interfaces;
using RaidCalc.Views;
using RaidCalcCore.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public bool NextPage()
        {
            return false;
        }

        public void InitData()
        {
            BossCommand_View view = View as BossCommand_View;
            AddPlayers(MainFrame.GetPlayerList());
            foreach (var item in _PlayerList)
            {
                view.GridItem.points.Add(item.Name, new Point(item.PosX, item.PosY));
                Console.WriteLine($"플레이어 로드: name: {item.Name}, position: {new Point(item.PosX, item.PosY)}");
            }
        }
    }
}
