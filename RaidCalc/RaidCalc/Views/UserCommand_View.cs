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
        #region Class Members
        public IController Controller { get; set; }
        public string ViewName { get; set; }
        #endregion

        #region Constructor
        public UserCommand_View()
        {
            InitializeComponent();
            ViewName = "UserCommand";
        }
        #endregion

        #region Interface Methods
        public void SetController(IController controller)
        {
            Controller = controller;
        }

        public void DrawData(object[] data)
        {
        }
        #endregion

        #region Membmer Accessor
        /// <summary>
        /// 스킬셋 콤보박스에 접근하는 접근자입니다.
        /// </summary>
        public string SkillsetName { get { return Combo_Skillset.SelectedItem.ToString(); } }

        /// <summary>
        /// 플레이어 선택(삭제/스킬확정)에 관련된 접근자입니다.
        /// </summary>
        public bool IsPlayerEditing
        {
            set
            {
                _IsPlayerEditing = value;
                Button_PlayerAdd.Enabled = !_IsPlayerEditing;
                // PlayerCounter 접근자에 접근해 PlayerAdd 버튼의 활성화 상태를 변경합니다.
                if (value == false)
                    PlayerCounter = PlayerCounter;
                Button_SetSkill.Enabled = !_IsPlayerEditing;
                foreach (PlayerItem pitem in Flow_PlayerList.Controls)
                {
                    pitem.IsSelected = false;
                    pitem.SelectiveMode = _IsPlayerEditing;
                    if (_IsPlayerEditing == true)
                        BindEventsAllChildren(pitem, PlayerSelected);
                    else
                        UnBindEventsAllChildren(pitem, PlayerSelected);
                }
            }
        }
        private bool _IsPlayerEditing;

        /// <summary>
        /// 스킬 확정에 관련된 접근자입니다.
        /// </summary>
        public bool IsSkillEditing
        {
            set
            {
                _IsSkillEditing = value;
                Button_PlayerAdd.Enabled = !_IsSkillEditing;
                // PlayerCounter 접근자에 접근해 PlayerAdd 버튼의 활성화 상태를 변경합니다.
                if (value == false)
                    PlayerCounter = PlayerCounter;
                Button_PlayerDel.Enabled = !_IsSkillEditing;
                foreach (PlayerItem pitem in Flow_PlayerList.Controls)
                {
                    pitem.IsSelected = false;
                    pitem.SelectiveMode = _IsSkillEditing;
                    if (_IsSkillEditing == true)
                        BindEventsAllChildren(pitem, PlayerSelected);
                    else
                        UnBindEventsAllChildren(pitem, PlayerSelected);
                }
                foreach (SkillItem sitem in List_SkillsetList.Controls)
                {
                    sitem.IsSelected = false;
                    sitem.SelectiveMode = _IsSkillEditing;
                }
            }
        }
        private bool _IsSkillEditing;

        /// <summary>
        /// 플레이어 카운터에 접근하는 접근자입니다.
        /// </summary>
        public int PlayerCounter {
            get
            {
                return int.Parse(Lab_PlayerCounter.Text.Substring(1,2));
            }
            set
            {
                Lab_PlayerCounter.Text = $"({value.ToString("00")}/24)";
                if (value >= 24)
                    Button_PlayerAdd.Enabled = false;
                else
                    Button_PlayerAdd.Enabled = true;
            }
        }

        /// <summary>
        /// 현재 PlayerItem의 List를 구하는 접근자입니다.
        /// </summary>
        public List<PlayerItem> PlayerItems
        {
            get
            {
                List<PlayerItem> playerList = new List<PlayerItem>();
                playerList.AddRange(Flow_PlayerList.Controls.OfType<PlayerItem>());
                return playerList;
            }
        }
        #endregion

        #region ClassMethods
        public void DrawSkillset(List<ISkillBase> skills)
        {
            List_SkillsetList.Controls.Clear();
            List_SkillsetList.Controls.AddRange(skills
                .Select(x => new SkillItem(x.Type, x.Name, x.ForceConst, x.Cooltime, x.Description, x.SkillFunction) { SelectiveMode = _IsSkillEditing})
                .ToArray<Control>());
        }

        public void AddPlayer(Player player)
        {
            PlayerItem pitem = new PlayerItem(player);
            pitem.Name = player.Name;
            pitem.Width = Flow_PlayerList.Width - 6;
            Flow_PlayerList.Controls.Add(pitem);
        }

        public void DeletePlayer(string playerName)
        {
            Flow_PlayerList.Controls.RemoveByKey(playerName);
        }

        public void DeletePlayers(List<string> playerNames)
        {
            foreach (string name in playerNames)
            {
                Flow_PlayerList.Controls.RemoveByKey(name);
            }
        }

        public void ClearPlayerSelection(string except)
        {
            foreach (PlayerItem pitem in Flow_PlayerList.Controls)
            {
                if (pitem.Name.Equals(except))
                    continue;
                pitem.IsSelected = false;
            }
        }

        public void ClearSkillSelection()
        {
            foreach (SkillItem sitem in List_SkillsetList.Controls)
            {
                sitem.IsSelected = false;
            }
        }

        public List<ISkillBase> GetSelectedSkills()
        {
            List<ISkillBase> skills = new List<ISkillBase>();
            foreach (SkillItem sitem in List_SkillsetList.Controls)
            {
                if (sitem.IsSelected == true)
                    skills.Add(sitem.Skill);
            }
            return skills;
        }

        public void HighlightSkills(List<ISkillBase> skills)
        {
            var temp = skills;
            foreach (SkillItem sitem in List_SkillsetList.Controls)
            {
                foreach (ISkillBase item in temp)
                {
                    if (sitem.Skill.Name.Equals(item.Name))
                    {
                        sitem.IsSelected = true;
                        temp.Remove(item);
                        break;
                    }
                }
            }
        }
        #endregion

        #region Event Handlers
        private void Button_PlayerAdd_Click(object sender, EventArgs e)
        {
            (Controller as UserCommand_Controller).AddPlayer();
        }

        private void Button_PlayerDel_Click(object sender, EventArgs e)
        {
            (Controller as UserCommand_Controller).Delete();
        }

        private void Combo_Skillset_SelectionChangeCommitted(object sender, EventArgs e)
        {
            (Controller as UserCommand_Controller).LoadSkillList();
        }

        private void Button_SetSkill_Click(object sender, EventArgs e)
        {
            (Controller as UserCommand_Controller).SetSkillList();
        }

        private void PlayerSelected(object sender, EventArgs e)
        {
            (Controller as UserCommand_Controller).PlayerClicked(GetParentPlayerItem(sender as Control).Name);
        }
        #endregion
        
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
    }
}
