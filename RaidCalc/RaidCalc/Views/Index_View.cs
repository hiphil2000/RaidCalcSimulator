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
using RaidCalc.Controllers;

namespace RaidCalc.Views
{
    public partial class Index_View : UserControl, IView
    {
        public IController Controller { get; set; }
        public string ViewName { get; set; }

        public Index_View()
        {
            InitializeComponent();
            ViewName = "Index";
        }
        public void SetController(IController controller)
        {
            Controller = controller;
        }

        public void DrawData(object[] data)
        {
            throw new NotImplementedException();
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            (Controller as Index_Controller).TryExit();
        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            (Controller as Index_Controller).TryStartGame();
        }

        public void Clear()
        {
            
        }
    }
}
