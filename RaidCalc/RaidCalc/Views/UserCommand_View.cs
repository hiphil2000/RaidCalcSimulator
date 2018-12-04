using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RaidCalc.Interfaces;

namespace RaidCalc.Views
{
    public partial class UserCommand_View : UserControl, IView
    {
        public IController Controller { get; set; }
        public string ViewName { get; set; }

        public UserCommand_View()
        {
            InitializeComponent();
            ViewName = "UserCommand";
        }
        public void SetController(IController controller)
        {
            Controller = controller;
        }

        public void DrawData(object[] data)
        {
            throw new NotImplementedException();
        }
        private void UserCommand_View_Load(object sender, EventArgs e)
        {

        }
    }
}
