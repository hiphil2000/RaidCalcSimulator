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
            this.List_SkillsetList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_PlayerAdd = new System.Windows.Forms.Button();
            this.Combo_Skillset = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Button_PlayerDel = new System.Windows.Forms.Button();
            this.playerListItem6 = new RaidCalc.Views.PlayerListItem();
            this.playerListItem1 = new RaidCalc.Views.PlayerListItem();
            this.playerListItem2 = new RaidCalc.Views.PlayerListItem();
            this.playerListItem3 = new RaidCalc.Views.PlayerListItem();
            this.playerListItem4 = new RaidCalc.Views.PlayerListItem();
            this.playerListItem5 = new RaidCalc.Views.PlayerListItem();
            this.Flow_PlayerList.SuspendLayout();
            this.SuspendLayout();
            // 
            // Flow_PlayerList
            // 
            this.Flow_PlayerList.AutoScroll = true;
            this.Flow_PlayerList.Controls.Add(this.playerListItem1);
            this.Flow_PlayerList.Controls.Add(this.playerListItem2);
            this.Flow_PlayerList.Controls.Add(this.playerListItem3);
            this.Flow_PlayerList.Controls.Add(this.playerListItem4);
            this.Flow_PlayerList.Controls.Add(this.playerListItem5);
            this.Flow_PlayerList.Location = new System.Drawing.Point(7, 113);
            this.Flow_PlayerList.Name = "Flow_PlayerList";
            this.Flow_PlayerList.Size = new System.Drawing.Size(430, 324);
            this.Flow_PlayerList.TabIndex = 0;
            // 
            // Lab_SkillsetBox
            // 
            this.Lab_SkillsetBox.AutoSize = true;
            this.Lab_SkillsetBox.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lab_SkillsetBox.Location = new System.Drawing.Point(445, 90);
            this.Lab_SkillsetBox.Name = "Lab_SkillsetBox";
            this.Lab_SkillsetBox.Size = new System.Drawing.Size(89, 20);
            this.Lab_SkillsetBox.TabIndex = 3;
            this.Lab_SkillsetBox.Text = "스킬 리스트";
            // 
            // List_SkillsetList
            // 
            this.List_SkillsetList.FormattingEnabled = true;
            this.List_SkillsetList.ItemHeight = 17;
            this.List_SkillsetList.Location = new System.Drawing.Point(449, 114);
            this.List_SkillsetList.Name = "List_SkillsetList";
            this.List_SkillsetList.Size = new System.Drawing.Size(311, 327);
            this.List_SkillsetList.TabIndex = 6;
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
            this.Button_PlayerAdd.Location = new System.Drawing.Point(335, 87);
            this.Button_PlayerAdd.Name = "Button_PlayerAdd";
            this.Button_PlayerAdd.Size = new System.Drawing.Size(102, 23);
            this.Button_PlayerAdd.TabIndex = 100;
            this.Button_PlayerAdd.Text = "플레이어 추가";
            this.Button_PlayerAdd.UseVisualStyleBackColor = true;
            // 
            // Combo_Skillset
            // 
            this.Combo_Skillset.FormattingEnabled = true;
            this.Combo_Skillset.Location = new System.Drawing.Point(639, 85);
            this.Combo_Skillset.Name = "Combo_Skillset";
            this.Combo_Skillset.Size = new System.Drawing.Size(121, 25);
            this.Combo_Skillset.TabIndex = 101;
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
            this.Button_PlayerDel.Location = new System.Drawing.Point(227, 87);
            this.Button_PlayerDel.Name = "Button_PlayerDel";
            this.Button_PlayerDel.Size = new System.Drawing.Size(102, 23);
            this.Button_PlayerDel.TabIndex = 100;
            this.Button_PlayerDel.Text = "플레이어 제거";
            this.Button_PlayerDel.UseVisualStyleBackColor = true;
            // 
            // playerListItem6
            // 
            this.playerListItem6.BackColor = System.Drawing.Color.Transparent;
            this.playerListItem6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerListItem6.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.playerListItem6.ForeColor = System.Drawing.Color.Black;
            this.playerListItem6.Location = new System.Drawing.Point(7, 32);
            this.playerListItem6.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.playerListItem6.Name = "playerListItem6";
            this.playerListItem6.Size = new System.Drawing.Size(430, 36);
            this.playerListItem6.TabIndex = 102;
            // 
            // playerListItem1
            // 
            this.playerListItem1.BackColor = System.Drawing.Color.Transparent;
            this.playerListItem1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerListItem1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.playerListItem1.ForeColor = System.Drawing.Color.Black;
            this.playerListItem1.Location = new System.Drawing.Point(0, 0);
            this.playerListItem1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.playerListItem1.Name = "playerListItem1";
            this.playerListItem1.Size = new System.Drawing.Size(430, 36);
            this.playerListItem1.TabIndex = 5;
            // 
            // playerListItem2
            // 
            this.playerListItem2.BackColor = System.Drawing.Color.Transparent;
            this.playerListItem2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerListItem2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.playerListItem2.ForeColor = System.Drawing.Color.Black;
            this.playerListItem2.Location = new System.Drawing.Point(0, 39);
            this.playerListItem2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.playerListItem2.Name = "playerListItem2";
            this.playerListItem2.Size = new System.Drawing.Size(430, 36);
            this.playerListItem2.TabIndex = 6;
            // 
            // playerListItem3
            // 
            this.playerListItem3.BackColor = System.Drawing.Color.Transparent;
            this.playerListItem3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerListItem3.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.playerListItem3.ForeColor = System.Drawing.Color.Black;
            this.playerListItem3.Location = new System.Drawing.Point(0, 78);
            this.playerListItem3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.playerListItem3.Name = "playerListItem3";
            this.playerListItem3.Size = new System.Drawing.Size(430, 36);
            this.playerListItem3.TabIndex = 7;
            // 
            // playerListItem4
            // 
            this.playerListItem4.BackColor = System.Drawing.Color.Transparent;
            this.playerListItem4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerListItem4.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.playerListItem4.ForeColor = System.Drawing.Color.Black;
            this.playerListItem4.Location = new System.Drawing.Point(0, 117);
            this.playerListItem4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.playerListItem4.Name = "playerListItem4";
            this.playerListItem4.Size = new System.Drawing.Size(430, 36);
            this.playerListItem4.TabIndex = 8;
            // 
            // playerListItem5
            // 
            this.playerListItem5.BackColor = System.Drawing.Color.Transparent;
            this.playerListItem5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerListItem5.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.playerListItem5.ForeColor = System.Drawing.Color.Black;
            this.playerListItem5.Location = new System.Drawing.Point(0, 156);
            this.playerListItem5.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.playerListItem5.Name = "playerListItem5";
            this.playerListItem5.Size = new System.Drawing.Size(430, 36);
            this.playerListItem5.TabIndex = 9;
            // 
            // UserCommand_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.playerListItem6);
            this.Controls.Add(this.Combo_Skillset);
            this.Controls.Add(this.Button_PlayerDel);
            this.Controls.Add(this.Button_PlayerAdd);
            this.Controls.Add(this.List_SkillsetList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lab_SkillsetBox);
            this.Controls.Add(this.Flow_PlayerList);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserCommand_View";
            this.Size = new System.Drawing.Size(769, 450);
            this.Load += new System.EventHandler(this.UserCommand_View_Load);
            this.Flow_PlayerList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Flow_PlayerList;
        private System.Windows.Forms.Label Lab_SkillsetBox;
        private System.Windows.Forms.ListBox List_SkillsetList;
        private PlayerListItem playerListItem1;
        private PlayerListItem playerListItem2;
        private PlayerListItem playerListItem3;
        private PlayerListItem playerListItem4;
        private PlayerListItem playerListItem5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_PlayerAdd;
        private System.Windows.Forms.ComboBox Combo_Skillset;
        private PlayerListItem playerListItem6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button_PlayerDel;
    }
}
