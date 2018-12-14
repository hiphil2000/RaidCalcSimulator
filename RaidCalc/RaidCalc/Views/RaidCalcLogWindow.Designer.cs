namespace RaidCalc.Views
{
    partial class RaidCalcLogWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Text_Logs = new System.Windows.Forms.TextBox();
            this.Lab_Title = new System.Windows.Forms.Label();
            this.Flow_ButtonBox = new System.Windows.Forms.FlowLayoutPanel();
            this.Button_Save = new System.Windows.Forms.Button();
            this.Button_Copy = new System.Windows.Forms.Button();
            this.Flow_ButtonBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Text_Logs
            // 
            this.Text_Logs.Location = new System.Drawing.Point(12, 65);
            this.Text_Logs.Multiline = true;
            this.Text_Logs.Name = "Text_Logs";
            this.Text_Logs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Text_Logs.Size = new System.Drawing.Size(496, 477);
            this.Text_Logs.TabIndex = 0;
            // 
            // Lab_Title
            // 
            this.Lab_Title.AutoSize = true;
            this.Lab_Title.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lab_Title.Location = new System.Drawing.Point(12, 25);
            this.Lab_Title.Name = "Lab_Title";
            this.Lab_Title.Size = new System.Drawing.Size(50, 30);
            this.Lab_Title.TabIndex = 1;
            this.Lab_Title.Text = "Log";
            // 
            // Flow_ButtonBox
            // 
            this.Flow_ButtonBox.Controls.Add(this.Button_Save);
            this.Flow_ButtonBox.Controls.Add(this.Button_Copy);
            this.Flow_ButtonBox.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.Flow_ButtonBox.Location = new System.Drawing.Point(345, 18);
            this.Flow_ButtonBox.Name = "Flow_ButtonBox";
            this.Flow_ButtonBox.Size = new System.Drawing.Size(163, 41);
            this.Flow_ButtonBox.TabIndex = 4;
            // 
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(85, 4);
            this.Button_Save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(75, 33);
            this.Button_Save.TabIndex = 2;
            this.Button_Save.Text = "Save As...";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_Copy
            // 
            this.Button_Copy.Location = new System.Drawing.Point(4, 4);
            this.Button_Copy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button_Copy.Name = "Button_Copy";
            this.Button_Copy.Size = new System.Drawing.Size(75, 33);
            this.Button_Copy.TabIndex = 2;
            this.Button_Copy.Text = "Copy";
            this.Button_Copy.UseVisualStyleBackColor = true;
            this.Button_Copy.Click += new System.EventHandler(this.Button_Copy_Click);
            // 
            // RaidCalcLogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 554);
            this.Controls.Add(this.Flow_ButtonBox);
            this.Controls.Add(this.Lab_Title);
            this.Controls.Add(this.Text_Logs);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RaidCalcLogWindow";
            this.Text = "RaidCalcLogWindow";
            this.Resize += new System.EventHandler(this.RaidCalcLogWindow_Resize);
            this.Flow_ButtonBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Text_Logs;
        private System.Windows.Forms.Label Lab_Title;
        private System.Windows.Forms.FlowLayoutPanel Flow_ButtonBox;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.Button Button_Copy;
    }
}