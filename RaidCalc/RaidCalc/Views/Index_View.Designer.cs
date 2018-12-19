namespace RaidCalc.Views
{
    partial class Index_View
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
            this.Button_Start = new System.Windows.Forms.Button();
            this.Button_Exit = new System.Windows.Forms.Button();
            this.Button_Options = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Button_Start
            // 
            this.Button_Start.Location = new System.Drawing.Point(23, 45);
            this.Button_Start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button_Start.Name = "Button_Start";
            this.Button_Start.Size = new System.Drawing.Size(75, 33);
            this.Button_Start.TabIndex = 0;
            this.Button_Start.Text = "Start";
            this.Button_Start.UseVisualStyleBackColor = true;
            this.Button_Start.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // Button_Exit
            // 
            this.Button_Exit.Location = new System.Drawing.Point(23, 126);
            this.Button_Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(75, 33);
            this.Button_Exit.TabIndex = 0;
            this.Button_Exit.Text = "Exit";
            this.Button_Exit.UseVisualStyleBackColor = true;
            this.Button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // Button_Options
            // 
            this.Button_Options.Location = new System.Drawing.Point(23, 205);
            this.Button_Options.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button_Options.Name = "Button_Options";
            this.Button_Options.Size = new System.Drawing.Size(75, 33);
            this.Button_Options.TabIndex = 0;
            this.Button_Options.Text = "Options";
            this.Button_Options.UseVisualStyleBackColor = true;
            this.Button_Options.Click += new System.EventHandler(this.button3_Click);
            // 
            // Index_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Button_Options);
            this.Controls.Add(this.Button_Exit);
            this.Controls.Add(this.Button_Start);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Index_View";
            this.Size = new System.Drawing.Size(515, 384);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_Start;
        private System.Windows.Forms.Button Button_Exit;
        private System.Windows.Forms.Button Button_Options;
    }
}
