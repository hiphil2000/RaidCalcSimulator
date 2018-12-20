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
        #region member

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
            if (Combo_BossList != null)
            {
                Combo_BossList.Enabled = !_readonly;
                if (_readonly == true)
                    Combo_BossList.DropDownStyle = ComboBoxStyle.Simple;
                else
                    Combo_BossList.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            Text_Name.Enabled = !_readonly;
            Text_Stat1.Enabled = !_readonly;
            Text_Stat2.Enabled = !_readonly;
            Text_Stat3.Enabled = !_readonly;
            Text_CurrentHealth.Enabled = !_readonly;
            if (_isBoss)
                Text_MaxHealth.Enabled = false;
            else
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
                _Combo_BossList = new ComboBox();
                Combo_BossList.Size = new Size(140, 25);
                Combo_BossList.Margin = new Padding(0, 0, 4, 0);
                Combo_BossList.DropDownStyle = ComboBoxStyle.DropDownList;
                _Button_Info = new Button();
                _Button_Info.Size = new Size(94, 25);
                _Button_Info.Margin = new Padding(0);
                _Button_Info.Name = "BossInfoButton";
                _Button_Info.Text = "Info";
                flowLayoutPanel1.Controls.Add(Combo_BossList);
                flowLayoutPanel1.Controls.Add(_Button_Info);
                flowLayoutPanel1.Controls.SetChildIndex(Combo_BossList, 1);
                flowLayoutPanel1.Controls.SetChildIndex(Picture_PlayerIcon, 0);
                Text_Name.Visible = false;
                Panel_Stat.Visible = false;
                Text_MaxHealth.Enabled = false;
                Width = Picture_PlayerIcon.Width + Combo_BossList.Width + Combo_BossList.Margin.Right + Panel_Health.Width + Panel_Health.Margin.Left + Panel_Health.Margin.Right + _Button_Info.Width + 6;
            }
            else
            {
                if (_Combo_BossList != null)
                    Combo_BossList.Visible = false;
                Text_Name.Visible = true;
                Panel_Stat.Visible = true;
                Text_MaxHealth.Enabled = true;
            }
                
        }
        #endregion

        

        #region util
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
        #endregion

        #region accessor
        public string Player_Name { get { return Text_Name.Text; } set { Text_Name.Text = value; } }
        public int Player_Stat1 { get { return ParseInt(Text_Stat1.Text); } set { Text_Stat1.Text = value.ToString(); } }
        public int Player_Stat2 { get { return ParseInt(Text_Stat2.Text); } set { Text_Stat2.Text = value.ToString(); } }
        public int Player_Stat3 { get { return ParseInt(Text_Stat3.Text); } set { Text_Stat3.Text = value.ToString(); } }
        public double Player_CurrentHealth { get { return ParseDouble(Text_CurrentHealth.Text); } set { Text_CurrentHealth.Text = value.ToString(); } }
        public double Player_MaxHealth { get { return ParseDouble(Text_MaxHealth.Text); } set { Text_MaxHealth.Text = value.ToString(); } }
        public ComboBox Player_Skills { get { return Combo_Skills; } }
        public ComboBox Combo_BossList { get { return _Combo_BossList; } }
        private ComboBox _Combo_BossList;
        public Button Button_Info { get { return _Button_Info; } }
        private Button _Button_Info;
        #endregion

        public List<ISkillBase> CommonSkills;
        public ISkillBase UltimateSkill;
        public PlayerItem()
        {
            InitializeComponent();
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
            Combo_Skills.Enabled = _selectiveMode;
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
