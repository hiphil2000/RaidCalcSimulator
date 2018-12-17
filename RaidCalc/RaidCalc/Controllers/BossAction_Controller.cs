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
    public class BossAction_Controller : IController
    {
        public IView View { get; set; }
        public RaidCalcWindow MainFrame { get; set; }
        private List<Player> _PlayerList;
        private Player _Boss;

        public BossAction_Controller(RaidCalcWindow mainFrame, IView view)
        {
            MainFrame = mainFrame;
            View = view;
        }
        public void InitData()
        {

            BossAction_View view = View as BossAction_View;
            AddPlayers(MainFrame.GetPlayerList());
            foreach (var item in _PlayerList)
            {
                view.GridItem.AddRealPoint(item.Name, new Point(item.PosX, item.PosY));
                string msg = $" 플레이어 확인: name: {item.Name}, position: {new Point(item.PosX, item.PosY)}";
                MainFrame.WriteLog(msg);
            }
            SetBoss(MainFrame.GetBoss());
        }

        private void SetBoss(Player player)
        {
            BossAction_View view = View as BossAction_View;
            _Boss = player;
            view.GridItem.AddRealPoint(_Boss.Name, new Point(_Boss.PosX, _Boss.PosY));
            string msg = $" 보스 확인: name: {_Boss.Name}, position: {new Point(_Boss.PosX, _Boss.PosY)}";
            MainFrame.WriteLog(msg);
            view.SetBoss(player);
        }

        public void AddPlayers(List<Player> players)
        {
            BossAction_View view = View as BossAction_View;
            _PlayerList = players;
            foreach (Player player in _PlayerList)
            {
                view.AddPlayer(player);
            }
            view.PlayerCounter = _PlayerList.Count;
        }

        public bool NextPage()
        {
            return true;
        }

    }
}
