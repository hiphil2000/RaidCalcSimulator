using RaidCalc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidCalc.Controllers
{
    public class BossCommand_Controller : IController
    {
        public IView View { get; set; }
        public RaidCalcWindow MainFrame { get; set; }

        public BossCommand_Controller(RaidCalcWindow mainFrame, IView view)
        {
            MainFrame = mainFrame;
            View = view;
        }

        public bool NextPage()
        {
            return false;
        }

        public void InitData()
        {
            throw new NotImplementedException();
        }
    }
}
