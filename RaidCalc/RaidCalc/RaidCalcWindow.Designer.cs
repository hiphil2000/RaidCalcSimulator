namespace RaidCalc
{
    partial class RaidCalcWindow
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lab_Title = new System.Windows.Forms.Label();
            this.Panel_MainFrame = new System.Windows.Forms.Panel();
            this.Button_Next = new System.Windows.Forms.Button();
            this.Button_Previous = new System.Windows.Forms.Button();
            this.Flow_ButtonBox = new System.Windows.Forms.FlowLayoutPanel();
            this.Flow_ToolBox = new System.Windows.Forms.FlowLayoutPanel();
            this.Button_Log = new System.Windows.Forms.Button();
            this.Flow_ButtonBox.SuspendLayout();
            this.Flow_ToolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lab_Title
            // 
            this.Lab_Title.AutoSize = true;
            this.Lab_Title.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lab_Title.Location = new System.Drawing.Point(12, 28);
            this.Lab_Title.Name = "Lab_Title";
            this.Lab_Title.Size = new System.Drawing.Size(101, 30);
            this.Lab_Title.TabIndex = 0;
            this.Lab_Title.Text = "Lab_Title";
            // 
            // Panel_MainFrame
            // 
            this.Panel_MainFrame.AutoScroll = true;
            this.Panel_MainFrame.Location = new System.Drawing.Point(12, 62);
            this.Panel_MainFrame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel_MainFrame.Name = "Panel_MainFrame";
            this.Panel_MainFrame.Size = new System.Drawing.Size(609, 379);
            this.Panel_MainFrame.TabIndex = 1;
            this.Panel_MainFrame.Resize += new System.EventHandler(this.Panel_MainFrame_Resize);
            // 
            // Button_Next
            // 
            this.Button_Next.Location = new System.Drawing.Point(85, 4);
            this.Button_Next.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button_Next.Name = "Button_Next";
            this.Button_Next.Size = new System.Drawing.Size(75, 33);
            this.Button_Next.TabIndex = 2;
            this.Button_Next.Text = "Next";
            this.Button_Next.UseVisualStyleBackColor = true;
            this.Button_Next.Click += new System.EventHandler(this.Button_Next_Click);
            // 
            // Button_Previous
            // 
            this.Button_Previous.Enabled = false;
            this.Button_Previous.Location = new System.Drawing.Point(4, 4);
            this.Button_Previous.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button_Previous.Name = "Button_Previous";
            this.Button_Previous.Size = new System.Drawing.Size(75, 33);
            this.Button_Previous.TabIndex = 2;
            this.Button_Previous.Text = "Previous";
            this.Button_Previous.UseVisualStyleBackColor = true;
            this.Button_Previous.Click += new System.EventHandler(this.Button_Previous_Click);
            // 
            // Flow_ButtonBox
            // 
            this.Flow_ButtonBox.Controls.Add(this.Button_Next);
            this.Flow_ButtonBox.Controls.Add(this.Button_Previous);
            this.Flow_ButtonBox.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.Flow_ButtonBox.Location = new System.Drawing.Point(458, 448);
            this.Flow_ButtonBox.Name = "Flow_ButtonBox";
            this.Flow_ButtonBox.Size = new System.Drawing.Size(163, 41);
            this.Flow_ButtonBox.TabIndex = 3;
            // 
            // Flow_ToolBox
            // 
            this.Flow_ToolBox.Controls.Add(this.Button_Log);
            this.Flow_ToolBox.Location = new System.Drawing.Point(12, 448);
            this.Flow_ToolBox.Name = "Flow_ToolBox";
            this.Flow_ToolBox.Size = new System.Drawing.Size(203, 41);
            this.Flow_ToolBox.TabIndex = 4;
            // 
            // Button_Log
            // 
            this.Button_Log.Location = new System.Drawing.Point(3, 4);
            this.Button_Log.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button_Log.Name = "Button_Log";
            this.Button_Log.Size = new System.Drawing.Size(96, 33);
            this.Button_Log.TabIndex = 2;
            this.Button_Log.Text = "Show Logs";
            this.Button_Log.UseVisualStyleBackColor = true;
            this.Button_Log.Click += new System.EventHandler(this.Button_Log_Click);
            // 
            // RaidCalcWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 495);
            this.Controls.Add(this.Flow_ToolBox);
            this.Controls.Add(this.Flow_ButtonBox);
            this.Controls.Add(this.Panel_MainFrame);
            this.Controls.Add(this.Lab_Title);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "RaidCalcWindow";
            this.Text = "RaidCalc";
            this.Load += new System.EventHandler(this.RaidCalc_Load);
            this.Flow_ButtonBox.ResumeLayout(false);
            this.Flow_ToolBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lab_Title;
        private System.Windows.Forms.Panel Panel_MainFrame;
        private System.Windows.Forms.Button Button_Next;
        private System.Windows.Forms.Button Button_Previous;
        private System.Windows.Forms.FlowLayoutPanel Flow_ButtonBox;
        private System.Windows.Forms.FlowLayoutPanel Flow_ToolBox;
        private System.Windows.Forms.Button Button_Log;
    }
}

