using RaidCalc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidCalc.Controllers
{
    public class PlayerCommand_Controller : IController
    {
        public IView View { get; set; }
        public RaidCalcWindow MainFrame { get; set; }

        public PlayerCommand_Controller(RaidCalcWindow mainFrame, IView view)
        {
            MainFrame = mainFrame;
            View = view;
        }

        public bool NextPage()
        {
            return true;
        }

        public void InitData()
        {
            View.DrawData(new object[] { MainFrame.GetPlayerList() });
        }
    }
}
