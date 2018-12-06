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
            var List = (data[0] as List<ISkillBase>).Where(x => x.Type.HasFlag((SkillType)Enum.Parse(typeof(SkillType), Combo_Skillset.SelectedItem.ToString()))).Select(x => new SkillItem(x.Type,x.Name,x.ForceConst,x.Cooltime,x.Description)).ToArray<Control>();
            List_SkillsetList.Controls.Clear();
            List_SkillsetList.Controls.AddRange(List);
        }

        private void Button_PlayerDel_Click(object sender, EventArgs e)
        {
            (Controller as UserCommand_Controller).Delete();
        }

        public void StartDelete()
        {
            Button_PlayerAdd.Enabled = false;
            foreach (var item in Flow_PlayerList.Controls)
            {
                PlayerItem pitem = item as PlayerItem;
                pitem.SelectiveMode = true;
            }
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
            } else
            {
                StopDelete();
            }
            Button_PlayerAdd.Enabled = true;
            Lab_PlayerCounter.Text = $"({Flow_PlayerList.Controls.Count.ToString("00")}/24)";
        }

        public void AddPlayer()
        {
            PlayerItem pitem = new PlayerItem();
            Flow_PlayerList.Controls.Add(pitem);
        }

        public void AddPlayer(Player player)
        {

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

        private void Combo_Skillset_SelectionChangeCommitted(object sender, EventArgs e)
        {
            (Controller as UserCommand_Controller).SetSkillList();
        }

        private void Button_SetSkill_Click(object sender, EventArgs e)
        {
            if (_nowPlayer != null)
            {
                Button_PlayerAdd.Enabled = true;
                Button_PlayerDel.Enabled = true;
                foreach (var item in Flow_PlayerList.Controls)
                {
                    PlayerItem pitem = item as PlayerItem;
                    pitem.SelectiveMode = true;
                    pitem.Click -= StartSelectOnce;
                }

            }
            else
            {
                Button_PlayerAdd.Enabled = false;
                Button_PlayerDel.Enabled = false;
                foreach (var item in Flow_PlayerList.Controls)
                {
                    PlayerItem pitem = item as PlayerItem;
                    pitem.SelectiveMode = true;
                    pitem.Click += StartSelectOnce;
                }
            }
        }

        private void StartSelectOnce(object o, EventArgs e)
        {
            _nowPlayer = o as PlayerItem;
            foreach (var item in Flow_PlayerList.Controls)
            {
                PlayerItem pitem = item as PlayerItem;
                pitem.IsSelected = false;
            }
        }
    }
}
