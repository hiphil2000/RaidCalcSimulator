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
using RaidCalcCore.Models;

namespace RaidCalc.Views
{
    public partial class UserCommand_View : UserControl, IView
    {
        public IController Controller { get; set; }
        public string ViewName { get; set; }

        private PlayerItem _nowPlayer;
        private bool Selecting;

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
            var List = (data[0] as List<ISkillBase>).Where(x => x.Type.HasFlag((SkillType)Enum.Parse(typeof(SkillType), Combo_Skillset.SelectedItem.ToString()))).Select(x => new SkillItem(x.Type, x.Name, x.ForceConst, x.Cooltime, x.Description) { SelectiveMode = Selecting }).ToArray<Control>();
            List_SkillsetList.Controls.Clear();
            List_SkillsetList.Controls.AddRange(List);
        }

        public void AddPlayer()
        {
            PlayerItem pitem = new PlayerItem();
            Flow_PlayerList.Controls.Add(pitem);
        }

        public void AddPlayer(Player player)
        {
            PlayerItem pitem = new PlayerItem(player);
            Flow_PlayerList.Controls.Add(pitem);
        }

        private void Button_PlayerAdd_Click(object sender, EventArgs e)
        {
            if (Flow_PlayerList.Controls.Count >= 24)
            {
                MessageBox.Show("플레이어 최대 인원은 24인입니다.", "실패");
                Button_PlayerAdd.Enabled = false;
            }
            else
            {
                Button_PlayerAdd.Enabled = true;
                AddPlayer();
                Lab_PlayerCounter.Text = $"({Flow_PlayerList.Controls.Count.ToString("00")}/24)";
            }
        }

        private void Button_PlayerDel_Click(object sender, EventArgs e)
        {
            (Controller as UserCommand_Controller).Delete();
        }

        public void StartDelete()
        {
            Button_PlayerAdd.Enabled = false;
            Button_SetSkill.Enabled = false;
            foreach (var item in Flow_PlayerList.Controls)
            {
                PlayerItem pitem = item as PlayerItem;
                pitem.SelectiveMode = true;
            }
        }

        public void DoDelete()
        {
            StringBuilder names = new StringBuilder(" ");
            var list = Flow_PlayerList.Controls;
            int selectedItem = 0;
            foreach (var item in list)
            {
                if ((item as PlayerItem).IsSelected)
                {
                    names.Append($"\"{(item as PlayerItem).Player_Name.Trim()}\" ");
                    selectedItem++;
                }
            }
            if (selectedItem > 0 && MessageBox.Show($"선택된 플레이어들을 삭제하시겠습니까?{Environment.NewLine}{{{names.ToString()}}}", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    PlayerItem pitem = list[i] as PlayerItem;
                    if (pitem.IsSelected)
                    {
                        pitem.Dispose();
                        i--;
                        continue;
                    }
                    pitem.SelectiveMode = false;
                }
            }
            else
            {
                StopDelete();
            }
            Button_PlayerAdd.Enabled = true;
            Button_SetSkill.Enabled = true;
            Lab_PlayerCounter.Text = $"({Flow_PlayerList.Controls.Count.ToString("00")}/24)";
        }

        public void StopDelete()
        {
            Button_PlayerAdd.Enabled = true;
            foreach (var item in Flow_PlayerList.Controls)
            {
                PlayerItem pitem = item as PlayerItem;
                pitem.SelectiveMode = false;
                pitem.IsSelected = false;
            }
        }

        private void Combo_Skillset_SelectionChangeCommitted(object sender, EventArgs e)
        {
            (Controller as UserCommand_Controller).SetSkillList();
        }

        private void Button_SetSkill_Click(object sender, EventArgs e)
        {
            if (!Selecting)
            {
                Button_PlayerAdd.Enabled = false;
                Button_PlayerDel.Enabled = false;
                foreach (var item in Flow_PlayerList.Controls)
                {
                    PlayerItem pitem = item as PlayerItem;
                    pitem.SelectiveMode = true;
                    BindEventsAllChildren(pitem, StartSelectOnce);
                }
                Selecting = true;
            }
            else
            {
                AddSkills(_nowPlayer);
                Button_PlayerAdd.Enabled = true;
                Button_PlayerDel.Enabled = true;
                foreach (var item in Flow_PlayerList.Controls)
                {
                    PlayerItem pitem = item as PlayerItem;
                    pitem.SelectiveMode = false;
                    pitem.IsSelected = false;
                    UnBindEventsAllChildren(pitem, StartSelectOnce);
                }
                _nowPlayer = null;
                Selecting = false;
            }
            foreach (SkillItem skill in List_SkillsetList.Controls)
            {
                skill.SelectiveMode = Selecting;
                skill.IsSelected = false;
            }
        }

        private void StartSelectOnce(object o, EventArgs e)
        {
            var selectedPlayer = GetParentPlayerItem(o as Control);
            if (!selectedPlayer.Equals(_nowPlayer))
            {
                AddSkills(_nowPlayer);
            }
            _nowPlayer = selectedPlayer;
            foreach (var item in Flow_PlayerList.Controls)
            {
                if (_nowPlayer.Equals(item))
                    continue;
                PlayerItem pitem = item as PlayerItem;
                pitem.IsSelected = false;
            }
            foreach (SkillItem sitem in List_SkillsetList.Controls)
            {
                sitem.IsSelected = false;
                foreach (ISkillBase skill in _nowPlayer.CommonSkills)
                {
                    if (skill.Name.Equals(sitem.Skill.Name))
                        sitem.IsSelected = true;
                }
            }
        }

        private void AddSkills(PlayerItem pitem)
        {
            if (pitem == null)
                return;
            foreach (SkillItem sitem in List_SkillsetList.Controls)
            {
                if (sitem.IsSelected)
                    pitem.AddCommonSkill(sitem.Skill);
                else
                    pitem.DeleteCommonSkill(sitem.Skill);
            }
        }

        private PlayerItem GetParentPlayerItem(Control contrl)
        {
            if ((contrl.Parent as PlayerItem) == null)
            {
                return GetParentPlayerItem(contrl.Parent);
            } else
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

        public List<Player> GetPlayerData()
        {
            List<Player> plist = new List<Player>();
            foreach (PlayerItem pitem in Flow_PlayerList.Controls)
            {
                plist.Add(pitem.ToPlayer());
            }
            return plist;
        }
    }
}
