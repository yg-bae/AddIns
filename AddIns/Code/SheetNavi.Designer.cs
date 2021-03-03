﻿
namespace AddIns
{
    partial class SheetNavi
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
            this.SheetList = new System.Windows.Forms.ListBox();
            this.GrpTblCtrl = new System.Windows.Forms.GroupBox();
            this.btnReleaseFilter = new System.Windows.Forms.Button();
            this.GrpSheetCtrl = new System.Windows.Forms.GroupBox();
            this.lblPrevNext = new System.Windows.Forms.Label();
            this.lblRefresh = new System.Windows.Forms.Label();
            this.BtnCfg = new System.Windows.Forms.Button();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnPrev = new System.Windows.Forms.Button();
            this.GrpTblCtrl.SuspendLayout();
            this.GrpSheetCtrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // SheetList
            // 
            this.SheetList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SheetList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SheetList.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SheetList.FormattingEnabled = true;
            this.SheetList.Location = new System.Drawing.Point(0, 94);
            this.SheetList.Name = "SheetList";
            this.SheetList.Size = new System.Drawing.Size(223, 248);
            this.SheetList.TabIndex = 1;
            this.SheetList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.SheetList_DrawItem);
            this.SheetList.DoubleClick += new System.EventHandler(this.SheetList_DoubleClick);
            this.SheetList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SheetList_KeyDown);
            this.SheetList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SheetList_MouseMove);
            // 
            // GrpTblCtrl
            // 
            this.GrpTblCtrl.Controls.Add(this.btnReleaseFilter);
            this.GrpTblCtrl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrpTblCtrl.Location = new System.Drawing.Point(0, 342);
            this.GrpTblCtrl.Name = "GrpTblCtrl";
            this.GrpTblCtrl.Size = new System.Drawing.Size(223, 53);
            this.GrpTblCtrl.TabIndex = 20;
            this.GrpTblCtrl.TabStop = false;
            this.GrpTblCtrl.Text = "테이블";
            // 
            // btnReleaseFilter
            // 
            this.btnReleaseFilter.Location = new System.Drawing.Point(6, 20);
            this.btnReleaseFilter.Name = "btnReleaseFilter";
            this.btnReleaseFilter.Size = new System.Drawing.Size(75, 24);
            this.btnReleaseFilter.TabIndex = 21;
            this.btnReleaseFilter.Text = "필터해제";
            this.btnReleaseFilter.UseVisualStyleBackColor = true;
            this.btnReleaseFilter.Click += new System.EventHandler(this.BtnReleaseFilter_Click);
            // 
            // GrpSheetCtrl
            // 
            this.GrpSheetCtrl.Controls.Add(this.lblPrevNext);
            this.GrpSheetCtrl.Controls.Add(this.lblRefresh);
            this.GrpSheetCtrl.Controls.Add(this.BtnRefresh);
            this.GrpSheetCtrl.Controls.Add(this.BtnNext);
            this.GrpSheetCtrl.Controls.Add(this.BtnPrev);
            this.GrpSheetCtrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpSheetCtrl.Location = new System.Drawing.Point(0, 0);
            this.GrpSheetCtrl.Name = "GrpSheetCtrl";
            this.GrpSheetCtrl.Size = new System.Drawing.Size(223, 94);
            this.GrpSheetCtrl.TabIndex = 10;
            this.GrpSheetCtrl.TabStop = false;
            this.GrpSheetCtrl.Text = "시트";
            // 
            // lblPrevNext
            // 
            this.lblPrevNext.AutoSize = true;
            this.lblPrevNext.Location = new System.Drawing.Point(116, 73);
            this.lblPrevNext.Name = "lblPrevNext";
            this.lblPrevNext.Size = new System.Drawing.Size(95, 12);
            this.lblPrevNext.TabIndex = 12;
            this.lblPrevNext.Text = "이전 / 이후 시트";
            // 
            // lblRefresh
            // 
            this.lblRefresh.AutoSize = true;
            this.lblRefresh.Location = new System.Drawing.Point(2, 74);
            this.lblRefresh.Name = "lblRefresh";
            this.lblRefresh.Size = new System.Drawing.Size(53, 12);
            this.lblRefresh.TabIndex = 11;
            this.lblRefresh.Text = "새로고침";
            // 
            // BtnCfg
            // 
            this.BtnCfg.BackgroundImage = global::AddIns.Properties.Resources.Cfg;
            this.BtnCfg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCfg.Location = new System.Drawing.Point(200, 0);
            this.BtnCfg.Name = "BtnCfg";
            this.BtnCfg.Size = new System.Drawing.Size(23, 24);
            this.BtnCfg.TabIndex = 30;
            this.BtnCfg.UseVisualStyleBackColor = true;
            this.BtnCfg.Click += new System.EventHandler(this.BtnCfg_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.BackgroundImage = global::AddIns.Properties.Resources.Refresh;
            this.BtnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnRefresh.Location = new System.Drawing.Point(6, 30);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(44, 40);
            this.BtnRefresh.TabIndex = 11;
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.BackgroundImage = global::AddIns.Properties.Resources.Arrow_Right_Gray;
            this.BtnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnNext.Enabled = false;
            this.BtnNext.ImageKey = "(없음)";
            this.BtnNext.Location = new System.Drawing.Point(169, 30);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(40, 40);
            this.BtnNext.TabIndex = 13;
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnPrev
            // 
            this.BtnPrev.BackgroundImage = global::AddIns.Properties.Resources.Arrow_Left_Gray;
            this.BtnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPrev.Enabled = false;
            this.BtnPrev.ImageKey = "(없음)";
            this.BtnPrev.Location = new System.Drawing.Point(118, 30);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(40, 40);
            this.BtnPrev.TabIndex = 12;
            this.BtnPrev.UseVisualStyleBackColor = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // SheetNavi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SheetList);
            this.Controls.Add(this.GrpTblCtrl);
            this.Controls.Add(this.BtnCfg);
            this.Controls.Add(this.GrpSheetCtrl);
            this.Name = "SheetNavi";
            this.Size = new System.Drawing.Size(223, 395);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SheetNavi_Paint);
            this.GrpTblCtrl.ResumeLayout(false);
            this.GrpSheetCtrl.ResumeLayout(false);
            this.GrpSheetCtrl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox SheetList;
        private System.Windows.Forms.GroupBox GrpTblCtrl;
        private System.Windows.Forms.Button btnReleaseFilter;
        private System.Windows.Forms.GroupBox GrpSheetCtrl;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnPrev;
        private System.Windows.Forms.Button BtnCfg;
        private System.Windows.Forms.Label lblPrevNext;
        private System.Windows.Forms.Label lblRefresh;
    }
}
