namespace RaidCalc.Views
{
    partial class SkillItem
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
            this.Lab_SkillType = new System.Windows.Forms.Label();
            this.Lab_SkillName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Lab_SkillConst = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Lab_Cooltime = new System.Windows.Forms.Label();
            this.Lab_Description = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lab_SkillType
            // 
            this.Lab_SkillType.AutoSize = true;
            this.Lab_SkillType.Location = new System.Drawing.Point(4, 4);
            this.Lab_SkillType.Name = "Lab_SkillType";
            this.Lab_SkillType.Size = new System.Drawing.Size(38, 17);
            this.Lab_SkillType.TabIndex = 0;
            this.Lab_SkillType.Text = "Basic";
            // 
            // Lab_SkillName
            // 
            this.Lab_SkillName.AutoSize = true;
            this.Lab_SkillName.Location = new System.Drawing.Point(57, 4);
            this.Lab_SkillName.Name = "Lab_SkillName";
            this.Lab_SkillName.Size = new System.Drawing.Size(34, 17);
            this.Lab_SkillName.TabIndex = 0;
            this.Lab_SkillName.Text = "이동";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "위력:";
            // 
            // Lab_SkillConst
            // 
            this.Lab_SkillConst.AutoSize = true;
            this.Lab_SkillConst.Location = new System.Drawing.Point(44, 21);
            this.Lab_SkillConst.Name = "Lab_SkillConst";
            this.Lab_SkillConst.Size = new System.Drawing.Size(47, 17);
            this.Lab_SkillConst.TabIndex = 0;
            this.Lab_SkillConst.Text = "무제한";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "쿨타임:";
            // 
            // Lab_Cooltime
            // 
            this.Lab_Cooltime.AutoSize = true;
            this.Lab_Cooltime.Location = new System.Drawing.Point(205, 21);
            this.Lab_Cooltime.Name = "Lab_Cooltime";
            this.Lab_Cooltime.Size = new System.Drawing.Size(28, 17);
            this.Lab_Cooltime.TabIndex = 0;
            this.Lab_Cooltime.Text = "5턴";
            // 
            // Lab_Description
            // 
            this.Lab_Description.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lab_Description.Location = new System.Drawing.Point(3, 48);
            this.Lab_Description.Name = "Lab_Description";
            this.Lab_Description.Size = new System.Drawing.Size(299, 52);
            this.Lab_Description.TabIndex = 0;
            this.Lab_Description.Text = "마스레이드에서 이동 제한을 받지 않고, 원하는 마스로 이동할 수 있습니다.";
            // 
            // SkillItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Lab_Cooltime);
            this.Controls.Add(this.Lab_Description);
            this.Controls.Add(this.Lab_SkillConst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lab_SkillName);
            this.Controls.Add(this.Lab_SkillType);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SkillItem";
            this.Size = new System.Drawing.Size(305, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lab_SkillType;
        private System.Windows.Forms.Label Lab_SkillName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lab_SkillConst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Lab_Cooltime;
        private System.Windows.Forms.Label Lab_Description;
    }
}
