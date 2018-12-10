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
        ISkillBase skill;

        public SkillItem()
        {
            InitializeComponent();
        }

        public SkillItem(SkillType type, string name, double skillConst, int cooltime, string description) : this()
        {
            skill = new BasicSkill() { Type = type, Name = name, ForceConst = skillConst, Cooltime = cooltime, Description = description };

            Lab_Description.Text = skill.Description;
            string result = skill.Cooltime < 0 ? "패시브" : skill.Cooltime.ToString() + "턴";
            Lab_Cooltime.Text = result;
            Lab_SkillName.Text = skill.Name;
            Lab_SkillType.Text = skill.Type.ToString();
            Lab_SkillConst.Text = skill.ForceConst < 0 ? "무제한" : skill.ForceConst.ToString();
            if (skill.Type.HasFlag(SkillType.Basic))
                BackColor = Color.FromArgb(255, 229, 153);
            if (skill.Type.HasFlag(SkillType.Offence))
                BackColor = Color.FromArgb(234, 153, 153);
            if (skill.Type.HasFlag(SkillType.Defence))
                BackColor = Color.FromArgb(159, 197, 232);
            if (skill.Type.HasFlag(SkillType.Heal))
                BackColor = Color.FromArgb(182, 215, 168);
        }
    }
}
