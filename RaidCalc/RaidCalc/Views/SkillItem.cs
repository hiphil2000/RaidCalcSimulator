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
        public SkillItem()
        {
            InitializeComponent();
        }

        public SkillItem(SkillType type, string name, double skillConst, int cooltime, string description) : this()
        {
            Lab_Description.Text = description;
            string result = cooltime < 0 ? "패시브" : cooltime.ToString() + "턴";
            Lab_Cooltime.Text = result;
            Lab_SkillName.Text = name;
            Lab_SkillType.Text = type.ToString();
            Lab_SkillConst.Text = skillConst.ToString();
            if (type.HasFlag(SkillType.Basic))
                BackColor = Color.FromArgb(255, 229, 153);
            if (type.HasFlag(SkillType.Offence))
                BackColor = Color.FromArgb(234, 153, 153);
            if (type.HasFlag(SkillType.Defence))
                BackColor = Color.FromArgb(159, 197, 232);
            if (type.HasFlag(SkillType.Heal))
                BackColor = Color.FromArgb(182, 215, 168);
        }
    }
}
