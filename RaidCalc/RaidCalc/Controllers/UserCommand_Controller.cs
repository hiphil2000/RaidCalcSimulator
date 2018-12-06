using RaidCalc.Interfaces;
using RaidCalc.Views;
using RaidCalcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidCalc.Controllers
{
    public class UserCommand_Controller : IController
    {
        public IView View { get; set; }
        public RaidCalcWindow MainFrame { get; set; }
        public bool IsDeleting { get; set; }

        List<Player> PlayerList;

        public UserCommand_Controller(RaidCalcWindow mainFrame, IView view)
        {
            MainFrame = mainFrame;
            View = view;
            PlayerList = new List<Player>();
        }

        public void Delete()
        {
            if (!IsDeleting)
                (View as UserCommand_View).StartDelete();
            else
            {
                (View as UserCommand_View).DoDelete();
            }
            IsDeleting = !IsDeleting;
        }

        public void SetSkillList()
        {
            (View as UserCommand_View).DrawData(new object[] { MainFrame.GetSkillList() });
        }
    }
}
