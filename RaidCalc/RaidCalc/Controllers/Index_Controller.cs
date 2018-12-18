using RaidCalc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidCalc.Controllers
{
    public class Index_Controller : IController
    {
        public IView View { get; set; }
        public RaidCalcWindow MainFrame { get; set; }

        public Index_Controller(RaidCalcWindow mainFrame, IView view)
        {
            MainFrame = mainFrame;
            View = view;
            view.Clear();
        }

        public void TryExit()
        {
            MainFrame.Exit();
        }

        public void TryStartGame()
        {
            MainFrame.StartGame();
        }

        public bool NextPage()
        {
            return true;
        }

        public void InitData()
        {
            
        }
    }
}
