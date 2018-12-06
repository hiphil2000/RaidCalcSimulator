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

        private bool _isBoss;
        public string Player_Name { get { return Text_Name.Text; } set { Text_Name.Text = value; } }

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

            CommonSkills = new List<ISkillBase>();
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
            CommonSkills.Add(skill);
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
    }
}
