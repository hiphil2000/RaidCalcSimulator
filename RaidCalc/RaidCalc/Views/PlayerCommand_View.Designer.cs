﻿namespace RaidCalc.Views
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
            this.Lab_GridMap = new System.Windows.Forms.Label();
            this.Grid_GridMap = new RaidCalc.Views.GridMap();
            this.Button_PlayerDel = new System.Windows.Forms.Button();
            this.Button_PlayerAdd = new System.Windows.Forms.Button();
            this.Lab_PlayerCounter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Flow_PlayerList = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // Lab_GridMap
            // 
            this.Lab_GridMap.AutoSize = true;
            this.Lab_GridMap.Location = new System.Drawing.Point(895, 89);
            this.Lab_GridMap.Name = "Lab_GridMap";
            this.Lab_GridMap.Size = new System.Drawing.Size(65, 17);
            this.Lab_GridMap.TabIndex = 101;
            this.Lab_GridMap.Text = "상황 입력";
            // 
            // Grid_GridMap
            // 
            this.Grid_GridMap.BackColor = System.Drawing.Color.Gray;
            this.Grid_GridMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Grid_GridMap.Location = new System.Drawing.Point(653, 116);
            this.Grid_GridMap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Grid_GridMap.Name = "Grid_GridMap";
            this.Grid_GridMap.Size = new System.Drawing.Size(510, 510);
            this.Grid_GridMap.TabIndex = 103;
            this.Grid_GridMap.Click += new System.EventHandler(this.Grid_GridMap_Click);
            this.Grid_GridMap.Paint += new System.Windows.Forms.PaintEventHandler(this.gridMap1_Load);
            this.Grid_GridMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Grid_GridMap_MouseClick);
            // 
            // Button_PlayerDel
            // 
            this.Button_PlayerDel.Location = new System.Drawing.Point(426, 89);
            this.Button_PlayerDel.Name = "Button_PlayerDel";
            this.Button_PlayerDel.Size = new System.Drawing.Size(102, 23);
            this.Button_PlayerDel.TabIndex = 107;
            this.Button_PlayerDel.Text = "플레이어 제거";
            this.Button_PlayerDel.UseVisualStyleBackColor = true;
            // 
            // Button_PlayerAdd
            // 
            this.Button_PlayerAdd.Location = new System.Drawing.Point(534, 90);
            this.Button_PlayerAdd.Name = "Button_PlayerAdd";
            this.Button_PlayerAdd.Size = new System.Drawing.Size(102, 23);
            this.Button_PlayerAdd.TabIndex = 108;
            this.Button_PlayerAdd.Text = "플레이어 추가";
            this.Button_PlayerAdd.UseVisualStyleBackColor = true;
            // 
            // Lab_PlayerCounter
            // 
            this.Lab_PlayerCounter.AutoSize = true;
            this.Lab_PlayerCounter.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lab_PlayerCounter.Location = new System.Drawing.Point(124, 93);
            this.Lab_PlayerCounter.Name = "Lab_PlayerCounter";
            this.Lab_PlayerCounter.Size = new System.Drawing.Size(62, 20);
            this.Lab_PlayerCounter.TabIndex = 105;
            this.Lab_PlayerCounter.Text = "(00/24)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(-1, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 106;
            this.label1.Text = "플레이어 리스트";
            // 
            // Flow_PlayerList
            // 
            this.Flow_PlayerList.AutoScroll = true;
            this.Flow_PlayerList.Location = new System.Drawing.Point(3, 116);
            this.Flow_PlayerList.Name = "Flow_PlayerList";
            this.Flow_PlayerList.Size = new System.Drawing.Size(644, 510);
            this.Flow_PlayerList.TabIndex = 104;
            // 
            // PlayerCommand_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Button_PlayerDel);
            this.Controls.Add(this.Button_PlayerAdd);
            this.Controls.Add(this.Lab_PlayerCounter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Flow_PlayerList);
            this.Controls.Add(this.Grid_GridMap);
            this.Controls.Add(this.Lab_GridMap);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PlayerCommand_View";
            this.Size = new System.Drawing.Size(1166, 633);
            this.Load += new System.EventHandler(this.PlayerCommand_View_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lab_GridMap;
        private GridMap Grid_GridMap;
        private System.Windows.Forms.Button Button_PlayerDel;
        private System.Windows.Forms.Button Button_PlayerAdd;
        private System.Windows.Forms.Label Lab_PlayerCounter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel Flow_PlayerList;
    }
}
