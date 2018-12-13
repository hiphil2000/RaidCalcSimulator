namespace RaidCalc.Views
{
    partial class BossCommand_View
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
            this.Lab_PlayerCounter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Flow_PlayerList = new System.Windows.Forms.FlowLayoutPanel();
            this.Grid_GridMap = new RaidCalc.Views.GridMap();
            this.Lab_GridMap = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Lab_PlayerCounter
            // 
            this.Lab_PlayerCounter.AutoSize = true;
            this.Lab_PlayerCounter.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lab_PlayerCounter.Location = new System.Drawing.Point(127, 94);
            this.Lab_PlayerCounter.Name = "Lab_PlayerCounter";
            this.Lab_PlayerCounter.Size = new System.Drawing.Size(62, 20);
            this.Lab_PlayerCounter.TabIndex = 110;
            this.Lab_PlayerCounter.Text = "(00/24)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(2, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 111;
            this.label1.Text = "플레이어 리스트";
            // 
            // Flow_PlayerList
            // 
            this.Flow_PlayerList.AutoScroll = true;
            this.Flow_PlayerList.Location = new System.Drawing.Point(6, 117);
            this.Flow_PlayerList.Name = "Flow_PlayerList";
            this.Flow_PlayerList.Size = new System.Drawing.Size(644, 510);
            this.Flow_PlayerList.TabIndex = 109;
            // 
            // Grid_GridMap
            // 
            this.Grid_GridMap.BackColor = System.Drawing.Color.Gray;
            this.Grid_GridMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Grid_GridMap.Location = new System.Drawing.Point(656, 117);
            this.Grid_GridMap.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Grid_GridMap.Name = "Grid_GridMap";
            this.Grid_GridMap.Size = new System.Drawing.Size(507, 507);
            this.Grid_GridMap.TabIndex = 108;
            this.Grid_GridMap.Paint += new System.Windows.Forms.PaintEventHandler(this.Grid_GridMap_Paint);
            this.Grid_GridMap.MouseLeave += new System.EventHandler(this.Grid_GridMap_MouseLeave);
            this.Grid_GridMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Grid_GridMap_MouseMove);
            // 
            // Lab_GridMap
            // 
            this.Lab_GridMap.AutoSize = true;
            this.Lab_GridMap.Location = new System.Drawing.Point(898, 90);
            this.Lab_GridMap.Name = "Lab_GridMap";
            this.Lab_GridMap.Size = new System.Drawing.Size(65, 17);
            this.Lab_GridMap.TabIndex = 107;
            this.Lab_GridMap.Text = "상황 입력";
            // 
            // BossCommand_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Lab_PlayerCounter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Flow_PlayerList);
            this.Controls.Add(this.Grid_GridMap);
            this.Controls.Add(this.Lab_GridMap);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BossCommand_View";
            this.Size = new System.Drawing.Size(1166, 633);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lab_PlayerCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel Flow_PlayerList;
        private GridMap Grid_GridMap;
        private System.Windows.Forms.Label Lab_GridMap;
    }
}
