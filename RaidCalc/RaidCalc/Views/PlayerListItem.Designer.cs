namespace RaidCalc.Views
{
    partial class PlayerListItem
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
            this.Text_PlayerName = new System.Windows.Forms.TextBox();
            this.Text_Stat1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Text_Stat2 = new System.Windows.Forms.TextBox();
            this.Text_Stat3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Text_CurrentHp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Text_MaxHp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Text_PlayerName
            // 
            this.Text_PlayerName.Location = new System.Drawing.Point(4, 3);
            this.Text_PlayerName.Margin = new System.Windows.Forms.Padding(0);
            this.Text_PlayerName.Name = "Text_PlayerName";
            this.Text_PlayerName.Size = new System.Drawing.Size(137, 27);
            this.Text_PlayerName.TabIndex = 0;
            // 
            // Text_Stat1
            // 
            this.Text_Stat1.Location = new System.Drawing.Point(156, 3);
            this.Text_Stat1.Margin = new System.Windows.Forms.Padding(0);
            this.Text_Stat1.MaxLength = 1;
            this.Text_Stat1.Name = "Text_Stat1";
            this.Text_Stat1.Size = new System.Drawing.Size(20, 27);
            this.Text_Stat1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "/";
            // 
            // Text_Stat2
            // 
            this.Text_Stat2.Location = new System.Drawing.Point(197, 3);
            this.Text_Stat2.Margin = new System.Windows.Forms.Padding(0);
            this.Text_Stat2.MaxLength = 1;
            this.Text_Stat2.Name = "Text_Stat2";
            this.Text_Stat2.Size = new System.Drawing.Size(20, 27);
            this.Text_Stat2.TabIndex = 0;
            // 
            // Text_Stat3
            // 
            this.Text_Stat3.Location = new System.Drawing.Point(238, 3);
            this.Text_Stat3.Margin = new System.Windows.Forms.Padding(0);
            this.Text_Stat3.MaxLength = 1;
            this.Text_Stat3.Name = "Text_Stat3";
            this.Text_Stat3.Size = new System.Drawing.Size(20, 27);
            this.Text_Stat3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "/";
            // 
            // Text_CurrentHp
            // 
            this.Text_CurrentHp.Location = new System.Drawing.Point(271, 3);
            this.Text_CurrentHp.Margin = new System.Windows.Forms.Padding(0);
            this.Text_CurrentHp.MaxLength = 1;
            this.Text_CurrentHp.Name = "Text_CurrentHp";
            this.Text_CurrentHp.Size = new System.Drawing.Size(67, 27);
            this.Text_CurrentHp.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "/";
            // 
            // Text_MaxHp
            // 
            this.Text_MaxHp.Location = new System.Drawing.Point(359, 3);
            this.Text_MaxHp.Margin = new System.Windows.Forms.Padding(0);
            this.Text_MaxHp.MaxLength = 1;
            this.Text_MaxHp.Name = "Text_MaxHp";
            this.Text_MaxHp.Size = new System.Drawing.Size(67, 27);
            this.Text_MaxHp.TabIndex = 0;
            // 
            // PlayerListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Text_Stat3);
            this.Controls.Add(this.Text_Stat2);
            this.Controls.Add(this.Text_MaxHp);
            this.Controls.Add(this.Text_CurrentHp);
            this.Controls.Add(this.Text_Stat1);
            this.Controls.Add(this.Text_PlayerName);
            this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.Name = "PlayerListItem";
            this.Size = new System.Drawing.Size(428, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Text_PlayerName;
        private System.Windows.Forms.TextBox Text_Stat1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Text_Stat2;
        private System.Windows.Forms.TextBox Text_Stat3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Text_CurrentHp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Text_MaxHp;
    }
}
