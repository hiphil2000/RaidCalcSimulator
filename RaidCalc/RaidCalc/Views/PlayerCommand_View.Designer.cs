namespace RaidCalc.Views
{
    partial class PlayerCommand_View
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
            this.maskedTextBox5 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox6 = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Lab_GridMap = new System.Windows.Forms.Label();
            this.Flow_PlayerList = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Grid_GridMap = new RaidCalc.Views.GridMap();
            this.panel3.SuspendLayout();
            this.Flow_PlayerList.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // maskedTextBox5
            // 
            this.maskedTextBox5.Location = new System.Drawing.Point(255, 3);
            this.maskedTextBox5.Name = "maskedTextBox5";
            this.maskedTextBox5.Size = new System.Drawing.Size(100, 25);
            this.maskedTextBox5.TabIndex = 98;
            // 
            // maskedTextBox6
            // 
            this.maskedTextBox6.Location = new System.Drawing.Point(149, 3);
            this.maskedTextBox6.Name = "maskedTextBox6";
            this.maskedTextBox6.Size = new System.Drawing.Size(100, 25);
            this.maskedTextBox6.TabIndex = 97;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "이름";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(43, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 25);
            this.textBox3.TabIndex = 96;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.maskedTextBox5);
            this.panel3.Controls.Add(this.maskedTextBox6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Location = new System.Drawing.Point(6, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(361, 33);
            this.panel3.TabIndex = 102;
            // 
            // Lab_GridMap
            // 
            this.Lab_GridMap.AutoSize = true;
            this.Lab_GridMap.Location = new System.Drawing.Point(600, 68);
            this.Lab_GridMap.Name = "Lab_GridMap";
            this.Lab_GridMap.Size = new System.Drawing.Size(65, 17);
            this.Lab_GridMap.TabIndex = 101;
            this.Lab_GridMap.Text = "상황 입력";
            // 
            // Flow_PlayerList
            // 
            this.Flow_PlayerList.AutoScroll = true;
            this.Flow_PlayerList.Controls.Add(this.panel2);
            this.Flow_PlayerList.Location = new System.Drawing.Point(3, 59);
            this.Flow_PlayerList.Name = "Flow_PlayerList";
            this.Flow_PlayerList.Size = new System.Drawing.Size(442, 379);
            this.Flow_PlayerList.TabIndex = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "이름";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(425, 33);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "이름";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "이름";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(146, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "/";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(212, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(98, 25);
            this.comboBox1.TabIndex = 104;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(324, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(98, 25);
            this.comboBox2.TabIndex = 104;
            // 
            // Grid_GridMap
            // 
            this.Grid_GridMap.BackColor = System.Drawing.Color.Gray;
            this.Grid_GridMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Grid_GridMap.Location = new System.Drawing.Point(451, 108);
            this.Grid_GridMap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Grid_GridMap.Name = "Grid_GridMap";
            this.Grid_GridMap.Size = new System.Drawing.Size(330, 330);
            this.Grid_GridMap.TabIndex = 103;
            this.Grid_GridMap.Click += new System.EventHandler(this.Grid_GridMap_Click);
            this.Grid_GridMap.Paint += new System.Windows.Forms.PaintEventHandler(this.gridMap1_Load);
            this.Grid_GridMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Grid_GridMap_MouseClick);
            // 
            // PlayerCommand_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Grid_GridMap);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Lab_GridMap);
            this.Controls.Add(this.Flow_PlayerList);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PlayerCommand_View";
            this.Size = new System.Drawing.Size(784, 464);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.Flow_PlayerList.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Lab_GridMap;
        private System.Windows.Forms.FlowLayoutPanel Flow_PlayerList;
        private GridMap Grid_GridMap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
