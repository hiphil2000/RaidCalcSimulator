namespace RaidCalc.Views
{
    partial class UserCommand_View
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Flow_PlayerList = new System.Windows.Forms.FlowLayoutPanel();
            this.Lab_SkillsetBox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_PlayerAdd = new System.Windows.Forms.Button();
            this.Combo_Skillset = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Button_PlayerDel = new System.Windows.Forms.Button();
            this.Button_SetSkill = new System.Windows.Forms.Button();
            this.Lab_PlayerCounter = new System.Windows.Forms.Label();
            this.List_SkillsetList = new System.Windows.Forms.FlowLayoutPanel();
            this.BossItem = new RaidCalc.Views.PlayerItem();
            this.SuspendLayout();
            // 
            // Flow_PlayerList
            // 
            this.Flow_PlayerList.AutoScroll = true;
            this.Flow_PlayerList.Location = new System.Drawing.Point(7, 113);
            this.Flow_PlayerList.Name = "Flow_PlayerList";
            this.Flow_PlayerList.Size = new System.Drawing.Size(633, 324);
            this.Flow_PlayerList.TabIndex = 0;
            // 
            // Lab_SkillsetBox
            // 
            this.Lab_SkillsetBox.AutoSize = true;
            this.Lab_SkillsetBox.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lab_SkillsetBox.Location = new System.Drawing.Point(646, 90);
            this.Lab_SkillsetBox.Name = "Lab_SkillsetBox";
            this.Lab_SkillsetBox.Size = new System.Drawing.Size(89, 20);
            this.Lab_SkillsetBox.TabIndex = 3;
            this.Lab_SkillsetBox.Text = "스킬 리스트";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "플레이어 리스트";
            // 
            // Button_PlayerAdd
            // 
            this.Button_PlayerAdd.Location = new System.Drawing.Point(538, 87);
            this.Button_PlayerAdd.Name = "Button_PlayerAdd";
            this.Button_PlayerAdd.Size = new System.Drawing.Size(102, 23);
            this.Button_PlayerAdd.TabIndex = 100;
            this.Button_PlayerAdd.Text = "플레이어 추가";
            this.Button_PlayerAdd.UseVisualStyleBackColor = true;
            this.Button_PlayerAdd.Click += new System.EventHandler(this.Button_PlayerAdd_Click);
            // 
            // Combo_Skillset
            // 
            this.Combo_Skillset.FormattingEnabled = true;
            this.Combo_Skillset.Items.AddRange(new object[] {
            "Basic",
            "Offence",
            "Defence",
            "Heal"});
            this.Combo_Skillset.Location = new System.Drawing.Point(1042, 85);
            this.Combo_Skillset.Name = "Combo_Skillset";
            this.Combo_Skillset.Size = new System.Drawing.Size(121, 25);
            this.Combo_Skillset.TabIndex = 101;
            this.Combo_Skillset.SelectionChangeCommitted += new System.EventHandler(this.Combo_Skillset_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "보스";
            // 
            // Button_PlayerDel
            // 
            this.Button_PlayerDel.Location = new System.Drawing.Point(430, 86);
            this.Button_PlayerDel.Name = "Button_PlayerDel";
            this.Button_PlayerDel.Size = new System.Drawing.Size(102, 23);
            this.Button_PlayerDel.TabIndex = 100;
            this.Button_PlayerDel.Text = "플레이어 제거";
            this.Button_PlayerDel.UseVisualStyleBackColor = true;
            this.Button_PlayerDel.Click += new System.EventHandler(this.Button_PlayerDel_Click);
            // 
            // Button_SetSkill
            // 
            this.Button_SetSkill.Location = new System.Drawing.Point(1083, 396);
            this.Button_SetSkill.Name = "Button_SetSkill";
            this.Button_SetSkill.Size = new System.Drawing.Size(80, 23);
            this.Button_SetSkill.TabIndex = 100;
            this.Button_SetSkill.Text = "스킬 확정";
            this.Button_SetSkill.UseVisualStyleBackColor = true;
            this.Button_SetSkill.Click += new System.EventHandler(this.Button_SetSkill_Click);
            // 
            // Lab_PlayerCounter
            // 
            this.Lab_PlayerCounter.AutoSize = true;
            this.Lab_PlayerCounter.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lab_PlayerCounter.Location = new System.Drawing.Point(128, 90);
            this.Lab_PlayerCounter.Name = "Lab_PlayerCounter";
            this.Lab_PlayerCounter.Size = new System.Drawing.Size(62, 20);
            this.Lab_PlayerCounter.TabIndex = 3;
            this.Lab_PlayerCounter.Text = "(00/24)";
            // 
            // List_SkillsetList
            // 
            this.List_SkillsetList.AutoScroll = true;
            this.List_SkillsetList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.List_SkillsetList.Location = new System.Drawing.Point(646, 113);
            this.List_SkillsetList.Name = "List_SkillsetList";
            this.List_SkillsetList.Size = new System.Drawing.Size(517, 277);
            this.List_SkillsetList.TabIndex = 102;
            this.List_SkillsetList.WrapContents = false;
            // 
            // BossItem
            // 
            this.BossItem.BackColor = System.Drawing.Color.White;
            this.BossItem.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BossItem.IsBoss = true;
            this.BossItem.IsSelected = false;
            this.BossItem.Location = new System.Drawing.Point(7, 33);
            this.BossItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BossItem.Name = "BossItem";
            this.BossItem.Player_CurrentHealth = 0D;
            this.BossItem.Player_MaxHealth = 0D;
            this.BossItem.Player_Name = "";
            this.BossItem.Player_Stat1 = 0;
            this.BossItem.Player_Stat2 = 0;
            this.BossItem.Player_Stat3 = 0;
            this.BossItem.Readonly = false;
            this.BossItem.SelectiveMode = false;
            this.BossItem.Size = new System.Drawing.Size(594, 31);
            this.BossItem.SkillsVisible = false;
            this.BossItem.TabIndex = 103;
            // 
            // UserCommand_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BossItem);
            this.Controls.Add(this.List_SkillsetList);
            this.Controls.Add(this.Combo_Skillset);
            this.Controls.Add(this.Button_PlayerDel);
            this.Controls.Add(this.Button_SetSkill);
            this.Controls.Add(this.Button_PlayerAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Lab_PlayerCounter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lab_SkillsetBox);
            this.Controls.Add(this.Flow_PlayerList);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserCommand_View";
            this.Size = new System.Drawing.Size(1166, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Flow_PlayerList;
        private System.Windows.Forms.Label Lab_SkillsetBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_PlayerAdd;
        private System.Windows.Forms.ComboBox Combo_Skillset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button_PlayerDel;
        private System.Windows.Forms.Button Button_SetSkill;
        private System.Windows.Forms.Label Lab_PlayerCounter;
        private System.Windows.Forms.FlowLayoutPanel List_SkillsetList;
        private PlayerItem BossItem;
    }
}
