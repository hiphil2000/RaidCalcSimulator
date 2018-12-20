namespace RaidCalc.Views
{
    partial class RaidCalcInfoWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.Lab_Name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Lab_Type = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.List_Skills = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.List_TimeLine = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.List_Descriptions = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type:";
            // 
            // Lab_Name
            // 
            this.Lab_Name.AutoSize = true;
            this.Lab_Name.Location = new System.Drawing.Point(246, 9);
            this.Lab_Name.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.Lab_Name.Name = "Lab_Name";
            this.Lab_Name.Size = new System.Drawing.Size(70, 17);
            this.Lab_Name.TabIndex = 1;
            this.Lab_Name.Text = "Lab_Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name: ";
            // 
            // Lab_Type
            // 
            this.Lab_Type.AutoSize = true;
            this.Lab_Type.Location = new System.Drawing.Point(57, 9);
            this.Lab_Type.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.Lab_Type.Name = "Lab_Type";
            this.Lab_Type.Size = new System.Drawing.Size(70, 17);
            this.Lab_Type.TabIndex = 1;
            this.Lab_Type.Text = "Lab_Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "SkillList";
            // 
            // List_Skills
            // 
            this.List_Skills.FormattingEnabled = true;
            this.List_Skills.HorizontalScrollbar = true;
            this.List_Skills.ItemHeight = 17;
            this.List_Skills.Location = new System.Drawing.Point(15, 160);
            this.List_Skills.Name = "List_Skills";
            this.List_Skills.ScrollAlwaysVisible = true;
            this.List_Skills.Size = new System.Drawing.Size(410, 344);
            this.List_Skills.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Descriptions:";
            // 
            // List_TimeLine
            // 
            this.List_TimeLine.FormattingEnabled = true;
            this.List_TimeLine.HorizontalScrollbar = true;
            this.List_TimeLine.ItemHeight = 17;
            this.List_TimeLine.Location = new System.Drawing.Point(449, 160);
            this.List_TimeLine.Name = "List_TimeLine";
            this.List_TimeLine.ScrollAlwaysVisible = true;
            this.List_TimeLine.Size = new System.Drawing.Size(374, 344);
            this.List_TimeLine.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(446, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "TimeLine";
            // 
            // List_Descriptions
            // 
            this.List_Descriptions.FormattingEnabled = true;
            this.List_Descriptions.HorizontalScrollbar = true;
            this.List_Descriptions.ItemHeight = 17;
            this.List_Descriptions.Location = new System.Drawing.Point(249, 31);
            this.List_Descriptions.Name = "List_Descriptions";
            this.List_Descriptions.ScrollAlwaysVisible = true;
            this.List_Descriptions.Size = new System.Drawing.Size(574, 89);
            this.List_Descriptions.TabIndex = 2;
            // 
            // RaidCalcInfoWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 516);
            this.Controls.Add(this.List_Descriptions);
            this.Controls.Add(this.List_TimeLine);
            this.Controls.Add(this.List_Skills);
            this.Controls.Add(this.Lab_Type);
            this.Controls.Add(this.Lab_Name);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RaidCalcInfoWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RaidCalcInfoWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lab_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Lab_Type;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox List_Skills;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox List_TimeLine;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox List_Descriptions;
    }
}