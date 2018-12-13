using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaidCalc.Views
{
    public partial class RaidCalcLogWindow : Form
    {
        private RaidCalcWindow _MainFrame;

        public RaidCalcLogWindow(RaidCalcWindow mainFrame)
        {
            InitializeComponent();
            _MainFrame = mainFrame;
            Text_Logs.Text = mainFrame.PrintLog();
        }

        private void RaidCalcLogWindow_Resize(object sender, EventArgs e)
        {
            Text_Logs.Size = new Size(Width - 36, Height - 51 - Text_Logs.Location.Y);
            Flow_ButtonBox.Location = new Point(Text_Logs.Location.X + Text_Logs.Width - Flow_ButtonBox.Width, Flow_ButtonBox.Location.Y);

        }
    }
}
