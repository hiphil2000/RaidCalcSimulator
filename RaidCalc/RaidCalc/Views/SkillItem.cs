using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RaidCalcCore.Models;

namespace RaidCalc.Views
{
    public partial class SkillItem : UserControl
    {
        public ISkillBase Skill;

        public bool IsSelected { get { return _isSelected; } set { _isSelected = value; SetSelected(); } }
        public bool SelectiveMode { get { return _selectiveMode; } set { _selectiveMode = value; SetSelectiveMode(); } }

        private bool _isSelected;
        private bool _selectiveMode;

        public SkillItem()
        {
            InitializeComponent();
            SelectiveMode = true;
            BindAll(this);
            this.Click += ClickEventHandler;
        }

        private void SetSelectiveMode()
        {
            if (_selectiveMode)
                IsSelected = false;
        }

        private void SetSelected()
        {
            if (_isSelected && _selectiveMode)
                Panel_Selected.BackColor = Color.Yellow;
            else
                Panel_Selected.BackColor = Color.Transparent;
        }

        public SkillItem(SkillType type, string name, double skillConst, int cooltime, string description, Func<IPlayer, IPlayer, object, bool> skillFunction) : this()
        {
            Skill = new BasicSkill() { Type = type, Name = name, ForceConst = skillConst, Cooltime = cooltime, Description = description, SkillFunction = skillFunction };

            Lab_Description.Text = Skill.Description;
            string result = Skill.Cooltime < 0 ? "패시브" : Skill.Cooltime.ToString() + "턴";
            Lab_Cooltime.Text = result;
            Lab_SkillName.Text = Skill.Name;
            string typeText = "";
            if (Skill.Type.HasFlag(SkillType.Basic))
                typeText = SkillType.Basic.ToString();
            if (Skill.Type.HasFlag(SkillType.Defence))
                typeText = SkillType.Defence.ToString();
            if (Skill.Type.HasFlag(SkillType.Offence))
                typeText = SkillType.Offence.ToString();
            if (Skill.Type.HasFlag(SkillType.Heal))
                typeText = SkillType.Heal.ToString();
            Lab_SkillType.Text = typeText;

            Lab_SkillConst.Text = Skill.ForceConst < 0 ? "무제한" : Skill.ForceConst.ToString();
            if (Skill.Type.HasFlag(SkillType.Basic))
                BackColor = Color.FromArgb(255, 229, 153);
            if (Skill.Type.HasFlag(SkillType.Offence))
                BackColor = Color.FromArgb(234, 153, 153);
            if (Skill.Type.HasFlag(SkillType.Defence))
                BackColor = Color.FromArgb(159, 197, 232);
            if (Skill.Type.HasFlag(SkillType.Heal))
                BackColor = Color.FromArgb(182, 215, 168);
        }

        private Control BindAll(Control control)
        {
            if (control != null)
            {
                foreach (Control child in control.Controls)
                {
                    child.Click += ClickEventHandler;
                    BindAll(child);
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        private void ClickEventHandler(object sender, EventArgs e)
        {
            IsSelected = !IsSelected;
        }
    }
}
