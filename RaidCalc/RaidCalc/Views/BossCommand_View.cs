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
using RaidCalc.Controllers;

namespace RaidCalc.Views
{
    public partial class BossCommand_View : UserControl, IView
    {
        #region Class Members
        public IController Controller { get; set; }
        public string ViewName { get; set; }
        #endregion

        #region Constructor
        public BossCommand_View()
        {
            InitializeComponent();
            ViewName = "BossCommand";
        }
        #endregion

        #region Member Accessor
        public Player Boss { get { return bitem.ToPlayer(); } }
        public string SelectedBossSkill { get { return bitem.SelectedSkillName.ToString(); } }
        private PlayerItem bitem;
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

        #region ClassMethods
        public void SetController(IController controller)
        {
            Controller = controller;
        }

        public void DrawData(object[] data)
        {
            throw new NotImplementedException();
        }

        public void AddPlayer(Player player)
        {
            PlayerItem pitem = new PlayerItem(player);
            pitem.Name = player.Name;
            pitem.SelectiveMode = false;
            pitem.SkillsVisible = false;
            pitem.Width = Flow_PlayerList.Width - 6;
            Flow_PlayerList.Controls.Add(pitem);
        }

        public void SetBoss(Player player)
        {
            bitem = new PlayerItem();
            bitem.Name = "BossItem";
            Controls.Add(bitem);
            bitem.IsBoss = true;
            bitem.SkillsVisible = true;
            bitem.Readonly = true;
            bitem.Location = new Point(3, 35);
            bitem.Player_Name = player.Name;
            bitem.Player_CurrentHealth = player.CurrentHp;
            bitem.Player_MaxHealth = player.MaxHp;

            if (player.PosX < 0 || player.PosY < 0)
            {
                if (player.CommonSkills.FirstOrDefault(x => x.Name.Equals("이동")) != null)
                {
                    bitem.Player_Skills.SelectedItem = "이동";
                }
                else
                {
                    bitem.Player_Skills.Items.Add("최초 좌표 설정");
                    bitem.Player_Skills.SelectedItem = "최초 좌표 설정";
                }
                bitem.Player_Skills.Enabled = false;
            }
        }

        #endregion

        #region Event Handlers

        private void Grid_GridMap_MouseMove(object sender, MouseEventArgs e)
        {
            Grid_GridMap.SetHighlight(e.Location);
        }

        private void Grid_GridMap_MouseLeave(object sender, EventArgs e)
        {
            Grid_GridMap.SetHighlight(new Point(-1, -1));
        }
        private void Grid_GridMap_Paint(object sender, PaintEventArgs e)
        {
            Grid_GridMap.DrawGrid();
        }

        private void Grid_GridMap_MouseClick(object sender, MouseEventArgs e)
        {
            (Controller as BossCommand_Controller).GridClicked(e.Location);
        }
        #endregion

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
                    if (child.Name.Equals("Combo_Skills") == false)
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
            if (Flow_PlayerList != null || Flow_PlayerList.Controls.Count > 0)
                Flow_PlayerList.Controls.Clear();
            if (bitem != null)
                bitem.Dispose();
        }
    }
}
