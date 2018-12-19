namespace RaidCalc.Views
{
    partial class RaidCalcOptionWindow
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
            this.Text_GameFile = new System.Windows.Forms.TextBox();
            this.Lab_Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_GameFileBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Text_LogFolder = new System.Windows.Forms.TextBox();
            this.Button_LogFolderBrowse = new System.Windows.Forms.Button();
            this.Button_Apply = new System.Windows.Forms.Button();
            this.Button_Ok = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Button_Reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Text_GameFile
            // 
            this.Text_GameFile.Location = new System.Drawing.Point(17, 106);
            this.Text_GameFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text_GameFile.Name = "Text_GameFile";
            this.Text_GameFile.Size = new System.Drawing.Size(341, 25);
            this.Text_GameFile.TabIndex = 0;
            this.Text_GameFile.TextChanged += new System.EventHandler(this.Text_GameFile_TextChanged);
            // 
            // Lab_Title
            // 
            this.Lab_Title.AutoSize = true;
            this.Lab_Title.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lab_Title.Location = new System.Drawing.Point(12, 25);
            this.Lab_Title.Name = "Lab_Title";
            this.Lab_Title.Size = new System.Drawing.Size(92, 30);
            this.Lab_Title.TabIndex = 2;
            this.Lab_Title.Text = "Options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "게임 데이터 파일 위치";
            // 
            // Button_GameFileBrowse
            // 
            this.Button_GameFileBrowse.Location = new System.Drawing.Point(364, 106);
            this.Button_GameFileBrowse.Name = "Button_GameFileBrowse";
            this.Button_GameFileBrowse.Size = new System.Drawing.Size(60, 25);
            this.Button_GameFileBrowse.TabIndex = 4;
            this.Button_GameFileBrowse.Text = "Browse";
            this.Button_GameFileBrowse.UseVisualStyleBackColor = true;
            this.Button_GameFileBrowse.Click += new System.EventHandler(this.Button_GameFileBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "로그 데이터 기본 저장 폴더";
            // 
            // Text_LogFolder
            // 
            this.Text_LogFolder.Location = new System.Drawing.Point(17, 178);
            this.Text_LogFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text_LogFolder.Name = "Text_LogFolder";
            this.Text_LogFolder.Size = new System.Drawing.Size(341, 25);
            this.Text_LogFolder.TabIndex = 0;
            this.Text_LogFolder.TextChanged += new System.EventHandler(this.Text_GameFile_TextChanged);
            // 
            // Button_LogFolderBrowse
            // 
            this.Button_LogFolderBrowse.Location = new System.Drawing.Point(364, 178);
            this.Button_LogFolderBrowse.Name = "Button_LogFolderBrowse";
            this.Button_LogFolderBrowse.Size = new System.Drawing.Size(60, 25);
            this.Button_LogFolderBrowse.TabIndex = 4;
            this.Button_LogFolderBrowse.Text = "Browse";
            this.Button_LogFolderBrowse.UseVisualStyleBackColor = true;
            this.Button_LogFolderBrowse.Click += new System.EventHandler(this.Button_LogFolderBrowse_Click);
            // 
            // Button_Apply
            // 
            this.Button_Apply.Enabled = false;
            this.Button_Apply.Location = new System.Drawing.Point(187, 230);
            this.Button_Apply.Name = "Button_Apply";
            this.Button_Apply.Size = new System.Drawing.Size(75, 23);
            this.Button_Apply.TabIndex = 5;
            this.Button_Apply.Text = "적용";
            this.Button_Apply.UseVisualStyleBackColor = true;
            this.Button_Apply.Click += new System.EventHandler(this.Button_Apply_Click);
            // 
            // Button_Ok
            // 
            this.Button_Ok.Location = new System.Drawing.Point(268, 230);
            this.Button_Ok.Name = "Button_Ok";
            this.Button_Ok.Size = new System.Drawing.Size(75, 23);
            this.Button_Ok.TabIndex = 5;
            this.Button_Ok.Text = "확인";
            this.Button_Ok.UseVisualStyleBackColor = true;
            this.Button_Ok.Click += new System.EventHandler(this.Button_Ok_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Location = new System.Drawing.Point(349, 230);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Cancel.TabIndex = 5;
            this.Button_Cancel.Text = "취소";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Button_Reset
            // 
            this.Button_Reset.Enabled = false;
            this.Button_Reset.Location = new System.Drawing.Point(106, 230);
            this.Button_Reset.Name = "Button_Reset";
            this.Button_Reset.Size = new System.Drawing.Size(75, 23);
            this.Button_Reset.TabIndex = 5;
            this.Button_Reset.Text = "되돌리기";
            this.Button_Reset.UseVisualStyleBackColor = true;
            this.Button_Reset.Click += new System.EventHandler(this.Button_Reset_Click);
            // 
            // RaidCalcOptionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 265);
            this.Controls.Add(this.Button_Reset);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_Ok);
            this.Controls.Add(this.Button_Apply);
            this.Controls.Add(this.Button_LogFolderBrowse);
            this.Controls.Add(this.Button_GameFileBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lab_Title);
            this.Controls.Add(this.Text_LogFolder);
            this.Controls.Add(this.Text_GameFile);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RaidCalcOptionWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RaidCalc - Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Text_GameFile;
        private System.Windows.Forms.Label Lab_Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_GameFileBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Text_LogFolder;
        private System.Windows.Forms.Button Button_LogFolderBrowse;
        private System.Windows.Forms.Button Button_Apply;
        private System.Windows.Forms.Button Button_Ok;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Button Button_Reset;
    }
}