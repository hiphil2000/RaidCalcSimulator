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
using RaidCalcCore.Models;

namespace RaidCalc.Views
{
    public partial class PlayerCommand_View : UserControl, IView
    {
        public IController Controller { get; set; }
        public string ViewName { get; set; }

        public PlayerCommand_View()
        {
            InitializeComponent();
            ViewName = "PlayerCommand";
        }
        public void SetController(IController controller)
        {
            Controller = controller;
        }

        public void DrawData(object[] data)
        {
            foreach (Player player in data[0] as List<Player>)
            {
                Flow_PlayerList.Controls.Add(new PlayerItem(player) { Readonly = false });
            }
        }

        private void gridMap1_Load(object sender, PaintEventArgs e)
        {
            Grid_GridMap.DrawGrid();
        }

        private void Grid_GridMap_Click(object sender, EventArgs e)
        {
        }

        private void Grid_GridMap_MouseClick(object sender, MouseEventArgs e)
        {
            Grid_GridMap.AddPoint(new Random().NextDouble().ToString(), e.Location);
            Console.WriteLine(e.Location);
        }

        private void PlayerCommand_View_Load(object sender, EventArgs e)
        {

        }
    }
}
