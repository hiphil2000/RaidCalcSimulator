﻿using System;
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
using RaidCalc.Controllers;

namespace RaidCalc.Views
{
    public partial class PlayerCommand_View : UserControl, IView
    {
        #region Class Members
        public IController Controller { get; set; }
        public string ViewName { get; set; }
        #endregion

        #region Constructor
        public PlayerCommand_View()
        {
            InitializeComponent();
            ViewName = "PlayerCommand";
        }
        #endregion

        #region Member Accessor
        public int PlayerCounter
        {
            get
            {
                return int.Parse(Lab_PlayerCounter.Text.Substring(1, 2));
            }
            set
            {
                Lab_PlayerCounter.Text = $"({value.ToString("00")}/24)";
            }
        }

        public GridMap GridItem
        {
            get
            {
                return Grid_GridMap;
            }
        }
        #endregion

        #region Class Methods
        public void SetController(IController controller)
        {
            Controller = controller;
        }

        public void DrawData(object[] data)
        {
            
        }

        public void AddPlayer(Player player)
        {
            PlayerCommand_Controller controller = Controller as PlayerCommand_Controller;
            PlayerItem pitem = new PlayerItem(player);
            pitem.Name = player.Name;
            pitem.SelectiveMode = true;
            pitem.SkillsVisible = true;
            pitem.Width = Flow_PlayerList.Width - 6;
            if (player.PosX < 0 || player.PosY < 0)
            {
                if (player.CommonSkills.FirstOrDefault(x => x.Name.Equals("이동")) != null)
                {
                    pitem.Player_Skills.SelectedItem = "이동";
                } else
                {
                    pitem.Player_Skills.Items.Add("최초 좌표 설정");
                    pitem.Player_Skills.SelectedItem = "최초 좌표 설정";
                }
                pitem.Player_Skills.Enabled = false;
            }
            else
            {
                pitem.Player_Skills.Items.Clear();
                pitem.Player_Skills.Items.AddRange(controller.GetSkillList(pitem.Name).Select(x => x.Name).ToArray());
            }
            Grid_GridMap.AddRealPoint(player.Name, new Point(player.PosX, player.PosY));
            Flow_PlayerList.Controls.Add(pitem);
            BindEventsAllChildren(pitem, PlayerSelected);
        }

        public void SelectPlayer(string name)
        {
            PlayerItem pitem = Flow_PlayerList.Controls[name] as PlayerItem;
            pitem.IsSelected = true;
        }

        public void DeSelectPlayer(string name)
        {
            PlayerItem pitem = Flow_PlayerList.Controls[name] as PlayerItem;
            pitem.IsSelected = false;
        }

        private void PlayerSelected(object sender, EventArgs e)
        {
            (Controller as PlayerCommand_Controller).PlayerClicked(GetParentPlayerItem(sender as Control).Name);
        }

        public PlayerItem FindPlayerItemByName(string name)
        {
            return Flow_PlayerList.Controls.Cast<PlayerItem>().FirstOrDefault(x => x.Player_Name.Equals(name));
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// 그리드를 다시 그립니다.
        /// </summary>
        private void Grid_GridMap_Paint(object sender, PaintEventArgs e)
        {
            Grid_GridMap.DrawGrid();
        }

        private void Grid_GridMap_MouseClick(object sender, MouseEventArgs e)
        {
            (Controller as PlayerCommand_Controller).GridClicked(e.Location);
        }

        private void Grid_GridMap_MouseMove_1(object sender, MouseEventArgs e)
        {
            (Controller as PlayerCommand_Controller).GridHighlight(e.Location);
            Grid_GridMap.SetHighlight(e.Location, "Rectangle", new Size(3,4), new Point(1,2), true);
        }

        private void Grid_GridMap_MouseLeave(object sender, EventArgs e)
        {
            Grid_GridMap.SetHighlight(new Point(-1,-1), null);
        }
        #endregion


        private void PlayerCommand_View_Load(object sender, EventArgs e)
        {

        }


        private PlayerItem GetParentPlayerItem(Control contrl)
        {
            if ((contrl.Parent as PlayerItem) == null)
            {
                return GetParentPlayerItem(contrl.Parent);
            }
            else
            {
                return contrl.Parent as PlayerItem;
            }
        }

        private Control BindEventsAllChildren(Control control, EventHandler e)
        {
            if (control != null)
            {
                foreach (Control child in control.Controls)
                {
                    if (child as ComboBox == null)
                        child.Click += e;
                    BindEventsAllChildren(child, e);
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        private Control UnBindEventsAllChildren(Control control, EventHandler e)
        {
            if (control != null)
            {
                control.Click -= e;
                foreach (Control child in control.Controls)
                {
                    child.Click -= e;
                    UnBindEventsAllChildren(child, e);
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public void Clear()
        {
            Flow_PlayerList.Controls.Clear();
            Grid_GridMap.points.Clear();
        }
    }
}
