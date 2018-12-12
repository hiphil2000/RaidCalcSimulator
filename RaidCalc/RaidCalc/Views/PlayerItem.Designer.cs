namespace RaidCalc.Views
{
    partial class PlayerItem
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
            this.Text_Name = new System.Windows.Forms.TextBox();
            this.Text_Stat1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Text_Stat2 = new System.Windows.Forms.TextBox();
            this.Text_Stat3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Panel_Stat = new System.Windows.Forms.Panel();
            this.Panel_Health = new System.Windows.Forms.FlowLayoutPanel();
            this.Text_MaxHealth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Text_CurrentHealth = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.Panel_Stat.SuspendLayout();
            this.Panel_Health.SuspendLayout();
            this.SuspendLayout();
            // 
            // Text_Name
            // 
            this.Text_Name.Location = new System.Drawing.Point(3, 3);
            this.Text_Name.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.Text_Name.Name = "Text_Name";
            this.Text_Name.Size = new System.Drawing.Size(168, 25);
            this.Text_Name.TabIndex = 0;
            this.Text_Name.TextChanged += new System.EventHandler(this.Text_Name_TextChanged);
            this.Text_Name.Leave += new System.EventHandler(this.Text_Name_Leave);
            // 
            // Text_Stat1
            // 
            this.Text_Stat1.Location = new System.Drawing.Point(0, 0);
            this.Text_Stat1.Margin = new System.Windows.Forms.Padding(0);
            this.Text_Stat1.MaxLength = 1;
            this.Text_Stat1.Name = "Text_Stat1";
            this.Text_Stat1.Size = new System.Drawing.Size(22, 25);
            this.Text_Stat1.TabIndex = 0;
            this.Text_Stat1.TextChanged += new System.EventHandler(this.Text_Stat1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "/";
            // 
            // Text_Stat2
            // 
            this.Text_Stat2.Location = new System.Drawing.Point(35, 0);
            this.Text_Stat2.Margin = new System.Windows.Forms.Padding(0);
            this.Text_Stat2.MaxLength = 1;
            this.Text_Stat2.Name = "Text_Stat2";
            this.Text_Stat2.Size = new System.Drawing.Size(22, 25);
            this.Text_Stat2.TabIndex = 0;
            this.Text_Stat2.TextChanged += new System.EventHandler(this.Text_Stat2_TextChanged);
            // 
            // Text_Stat3
            // 
            this.Text_Stat3.Location = new System.Drawing.Point(70, 0);
            this.Text_Stat3.Margin = new System.Windows.Forms.Padding(0);
            this.Text_Stat3.MaxLength = 1;
            this.Text_Stat3.Name = "Text_Stat3";
            this.Text_Stat3.Size = new System.Drawing.Size(22, 25);
            this.Text_Stat3.TabIndex = 0;
            this.Text_Stat3.TextChanged += new System.EventHandler(this.Text_Stat3_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "/";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Text_Name);
            this.flowLayoutPanel1.Controls.Add(this.Panel_Stat);
            this.flowLayoutPanel1.Controls.Add(this.Panel_Health);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(594, 31);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // Panel_Stat
            // 
            this.Panel_Stat.Controls.Add(this.Text_Stat1);
            this.Panel_Stat.Controls.Add(this.Text_Stat2);
            this.Panel_Stat.Controls.Add(this.Text_Stat3);
            this.Panel_Stat.Controls.Add(this.label2);
            this.Panel_Stat.Controls.Add(this.label1);
            this.Panel_Stat.Location = new System.Drawing.Point(178, 3);
            this.Panel_Stat.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Panel_Stat.Name = "Panel_Stat";
            this.Panel_Stat.Size = new System.Drawing.Size(94, 25);
            this.Panel_Stat.TabIndex = 3;
            // 
            // Panel_Health
            // 
            this.Panel_Health.Controls.Add(this.Text_CurrentHealth);
            this.Panel_Health.Controls.Add(this.label3);
            this.Panel_Health.Controls.Add(this.Text_MaxHealth);
            this.Panel_Health.Location = new System.Drawing.Point(278, 3);
            this.Panel_Health.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Panel_Health.Name = "Panel_Health";
            this.Panel_Health.Size = new System.Drawing.Size(309, 25);
            this.Panel_Health.TabIndex = 4;
            // 
            // Text_MaxHealth
            // 
            this.Text_MaxHealth.Location = new System.Drawing.Point(164, 0);
            this.Text_MaxHealth.Margin = new System.Windows.Forms.Padding(0);
            this.Text_MaxHealth.Name = "Text_MaxHealth";
            this.Text_MaxHealth.Size = new System.Drawing.Size(145, 25);
            this.Text_MaxHealth.TabIndex = 2;
            this.Text_MaxHealth.TextChanged += new System.EventHandler(this.Text_MaxHealth_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(148, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "/";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Text_CurrentHealth
            // 
            this.Text_CurrentHealth.Location = new System.Drawing.Point(0, 0);
            this.Text_CurrentHealth.Margin = new System.Windows.Forms.Padding(0);
            this.Text_CurrentHealth.Name = "Text_CurrentHealth";
            this.Text_CurrentHealth.Size = new System.Drawing.Size(145, 25);
            this.Text_CurrentHealth.TabIndex = 3;
            this.Text_CurrentHealth.TextChanged += new System.EventHandler(this.Text_CurrentHealth_TextChanged);
            // 
            // PlayerItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PlayerItem";
            this.Size = new System.Drawing.Size(594, 31);
            this.Click += new System.EventHandler(this.PlayerItem_Click);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.Panel_Stat.ResumeLayout(false);
            this.Panel_Stat.PerformLayout();
            this.Panel_Health.ResumeLayout(false);
            this.Panel_Health.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Text_Name;
        private System.Windows.Forms.TextBox Text_Stat1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Text_Stat2;
        private System.Windows.Forms.TextBox Text_Stat3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel Panel_Stat;
        private System.Windows.Forms.FlowLayoutPanel Panel_Health;
        private System.Windows.Forms.TextBox Text_MaxHealth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Text_CurrentHealth;
    }
}
