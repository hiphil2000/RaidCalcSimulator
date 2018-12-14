﻿using System;
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
    public partial class PlayerItem : UserControl
    {
        public bool SelectiveMode
        {
            get
            {
                return _selectiveMode;
            }
            set
            {
                _selectiveMode = value;
                SetSelectiveMode();
            }
        }
        private bool _selectiveMode;

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                SetSelected();
            }
        }
        private bool _isSelected;

        public bool Readonly { get { return _readonly; } set { _readonly = value; SetReadonly(); } }
        private bool _readonly;

        private void SetReadonly()
        {
            Text_Name.Enabled = !_readonly;
            Text_Stat1.Enabled = !_readonly;
            Text_Stat2.Enabled = !_readonly;
            Text_Stat3.Enabled = !_readonly;
            Text_CurrentHealth.Enabled = !_readonly;
            Text_MaxHealth.Enabled = !_readonly;
        }

        public bool SkillsVisible
        {
            get { return _SkillsVisible; }
            set
            {
                _SkillsVisible = value;
                Combo_Skills.Visible = _SkillsVisible;
            }
        }
        private bool _SkillsVisible;

        public bool IsBoss
        {
            get
            {
                return _isBoss;
            }
            set
            {
                _isBoss = value;
                SetVisibleMode();
            }
        }
        private bool _isBoss;

        public object SelectedSkillName
        {
            get
            {
                return Combo_Skills.SelectedItem;
            }
        }

        private void SetBackground(Color color)
        {
            this.BackColor = color;
        }

        private void SetVisibleMode()
        {
            if (_isBoss)
            {
                Panel_Stat.Visible = false;
            } else
            {
                Panel_Stat.Visible = true;
            }
                
        }

        private int ParseInt(string text)
        {
            var temp = text;
            if (string.IsNullOrEmpty(temp))
            {
                temp = "0";
            }

            return int.Parse(temp);
        }

        private double ParseDouble(string text)
        {
            var temp = text;
            if (string.IsNullOrEmpty(temp))
            {
                temp = "0";
            }

            return double.Parse(temp);
        }

        public string Player_Name { get { return Text_Name.Text; } set { Text_Name.Text = value; } }
        public int Player_Stat1 { get { return ParseInt(Text_Stat1.Text); } set { Text_Stat1.Text = value.ToString(); } }
        public int Player_Stat2 { get { return ParseInt(Text_Stat2.Text); } set { Text_Stat2.Text = value.ToString(); } }
        public int Player_Stat3 { get { return ParseInt(Text_Stat3.Text); } set { Text_Stat3.Text = value.ToString(); } }
        public double Player_CurrentHealth { get { return ParseDouble(Text_CurrentHealth.Text); } set { Text_CurrentHealth.Text = value.ToString(); } }
        public double Player_MaxHealth { get { return ParseDouble(Text_MaxHealth.Text); } set { Text_MaxHealth.Text = value.ToString(); } }
        public ComboBox Player_Skills { get { return Combo_Skills; } }

        public List<ISkillBase> CommonSkills;
        public ISkillBase UltimateSkill;
        public PlayerItem()
        {
            InitializeComponent();
            Text_Name.Click += PlayerItem_Click;
            Text_Stat1.Click += PlayerItem_Click;
            Text_Stat2.Click += PlayerItem_Click;
            Text_Stat3.Click += PlayerItem_Click;
            Text_CurrentHealth.Click += PlayerItem_Click;
            Text_MaxHealth.Click += PlayerItem_Click;
            SkillsVisible = false;
            CommonSkills = new List<ISkillBase>();
        }

        public PlayerItem(Player player) : this()
        {
            Text_Name.Text = player.Name;
            Text_Stat1.Text = player.Stat.Stat1.ToString();
            Text_Stat2.Text = player.Stat.Stat2.ToString();
            Text_Stat3.Text = player.Stat.Stat3.ToString();
            Text_CurrentHealth.Text = player.CurrentHp.ToString();
            Text_MaxHealth.Text = player.MaxHp.ToString();
            Combo_Skills.Items.AddRange(player.CommonSkills.Select(x => x.Name).ToArray());
            //Combo_Skills.Items.Add(player.UltimateSkill.Name);
        }

        public void SetSelectiveMode()
        {
            Text_Name.ReadOnly = _selectiveMode;
            Text_Stat1.ReadOnly = _selectiveMode;
            Text_Stat2.ReadOnly = _selectiveMode;
            Text_Stat3.ReadOnly = _selectiveMode;
            Text_CurrentHealth.ReadOnly = _selectiveMode;
            Text_MaxHealth.ReadOnly = _selectiveMode;
        }

        public void SetSelected()
        {
            if (_isSelected)
                this.BackColor = Color.Yellow;
            else
                this.BackColor = Color.White;
        }


        private void PlayerItem_Click(object sender, EventArgs e)
        {
            if (_selectiveMode)
            {
                _isSelected = !_isSelected;
                SetSelected();
            }
        }

        public void AddCommonSkill(ISkillBase skill)
        {
            if (!CommonSkills.Contains(skill))
                CommonSkills.Add(skill);
        }

        public void DeleteCommonSkill(ISkillBase skill)
        {
            if (CommonSkills.Contains(skill))
                CommonSkills.Remove(skill);
        }

        public void AddCommonSkillRange(List<ISkillBase> skills)
        {
            foreach(var item in skills)
            {
                CommonSkills.Add(item);
            }
        }

        public void SetUltimate(ISkillBase skill)
        {
            UltimateSkill = skill;
        }

        public Player ToPlayer()
        {
            return new Player(
                Text_Name.Text,
                new Stats(
                    ParseDouble(Text_Stat1.Text),
                    ParseDouble(Text_Stat2.Text),
                    ParseDouble(Text_Stat3.Text)),
                ParseDouble(Text_MaxHealth.Text),
                ParseDouble(Text_CurrentHealth.Text),
                1,
                -1,
                -1)
            { CommonSkills = CommonSkills, UltimateSkill = UltimateSkill };
        }

        private void Text_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Text_Stat1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Text_Stat2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Text_Stat3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Text_MaxHealth_TextChanged(object sender, EventArgs e)
        {

        }

        private void Text_CurrentHealth_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
