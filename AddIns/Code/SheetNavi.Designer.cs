
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
            this.LstSheetList = new System.Windows.Forms.ListBox();
            this.GrpTblCtrl = new System.Windows.Forms.GroupBox();
            this.btnReleaseFilter = new System.Windows.Forms.Button();
            this.GrpSheetCtrl = new System.Windows.Forms.GroupBox();
            this.CboSheetList = new System.Windows.Forms.ComboBox();
            this.lblPrevNext = new System.Windows.Forms.Label();
            this.lblRefresh = new System.Windows.Forms.Label();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnPrev = new System.Windows.Forms.Button();
            this.BtnCfg = new System.Windows.Forms.Button();
            this.tblSheetListPane = new System.Windows.Forms.TableLayoutPanel();
            this.GrpTblCtrl.SuspendLayout();
            this.GrpSheetCtrl.SuspendLayout();
            this.tblSheetListPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // LstSheetList
            // 
            this.LstSheetList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstSheetList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LstSheetList.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LstSheetList.FormattingEnabled = true;
            this.LstSheetList.Location = new System.Drawing.Point(3, 123);
            this.LstSheetList.Name = "LstSheetList";
            this.LstSheetList.Size = new System.Drawing.Size(226, 253);
            this.LstSheetList.TabIndex = 1;
            this.LstSheetList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LstSheetList_DrawItem);
            this.LstSheetList.DoubleClick += new System.EventHandler(this.SheetList_DoubleClick);
            this.LstSheetList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SheetList_KeyDown);
            this.LstSheetList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SheetList_MouseMove);
            // 
            // GrpTblCtrl
            // 
            this.GrpTblCtrl.Controls.Add(this.btnReleaseFilter);
            this.GrpTblCtrl.Location = new System.Drawing.Point(3, 382);
            this.GrpTblCtrl.Name = "GrpTblCtrl";
            this.GrpTblCtrl.Size = new System.Drawing.Size(128, 52);
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
            this.GrpSheetCtrl.Controls.Add(this.BtnCfg);
            this.GrpSheetCtrl.Controls.Add(this.lblPrevNext);
            this.GrpSheetCtrl.Controls.Add(this.lblRefresh);
            this.GrpSheetCtrl.Controls.Add(this.BtnRefresh);
            this.GrpSheetCtrl.Controls.Add(this.BtnNext);
            this.GrpSheetCtrl.Controls.Add(this.BtnPrev);
            this.GrpSheetCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpSheetCtrl.Location = new System.Drawing.Point(3, 3);
            this.GrpSheetCtrl.Name = "GrpSheetCtrl";
            this.GrpSheetCtrl.Size = new System.Drawing.Size(226, 89);
            this.GrpSheetCtrl.TabIndex = 10;
            this.GrpSheetCtrl.TabStop = false;
            this.GrpSheetCtrl.Text = "시트제어";
            // 
            // CboSheetList
            // 
            this.CboSheetList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CboSheetList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CboSheetList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CboSheetList.FormattingEnabled = true;
            this.CboSheetList.Location = new System.Drawing.Point(3, 98);
            this.CboSheetList.Name = "CboSheetList";
            this.CboSheetList.Size = new System.Drawing.Size(226, 20);
            this.CboSheetList.TabIndex = 14;
            this.CboSheetList.SelectedValueChanged += new System.EventHandler(this.CboSheetList_SelectedValueChanged);
            // 
            // lblPrevNext
            // 
            this.lblPrevNext.AutoSize = true;
            this.lblPrevNext.Location = new System.Drawing.Point(146, 72);
            this.lblPrevNext.Name = "lblPrevNext";
            this.lblPrevNext.Size = new System.Drawing.Size(63, 12);
            this.lblPrevNext.TabIndex = 12;
            this.lblPrevNext.Text = "전/후 시트";
            // 
            // lblRefresh
            // 
            this.lblRefresh.AutoSize = true;
            this.lblRefresh.Location = new System.Drawing.Point(2, 72);
            this.lblRefresh.Name = "lblRefresh";
            this.lblRefresh.Size = new System.Drawing.Size(53, 12);
            this.lblRefresh.TabIndex = 11;
            this.lblRefresh.Text = "새로고침";
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.BackgroundImage = global::AddIns.Properties.Resources.Refresh;
            this.BtnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnRefresh.Location = new System.Drawing.Point(6, 29);
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
            this.BtnNext.Location = new System.Drawing.Point(179, 29);
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
            this.BtnPrev.Location = new System.Drawing.Point(138, 29);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(40, 40);
            this.BtnPrev.TabIndex = 12;
            this.BtnPrev.UseVisualStyleBackColor = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // BtnCfg
            // 
            this.BtnCfg.BackgroundImage = global::AddIns.Properties.Resources.Cfg;
            this.BtnCfg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCfg.Location = new System.Drawing.Point(206, -2);
            this.BtnCfg.Name = "BtnCfg";
            this.BtnCfg.Size = new System.Drawing.Size(23, 23);
            this.BtnCfg.TabIndex = 30;
            this.BtnCfg.UseVisualStyleBackColor = true;
            this.BtnCfg.Click += new System.EventHandler(this.BtnCfg_Click);
            // 
            // tblSheetListPane
            // 
            this.tblSheetListPane.ColumnCount = 1;
            this.tblSheetListPane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSheetListPane.Controls.Add(this.GrpSheetCtrl, 0, 0);
            this.tblSheetListPane.Controls.Add(this.GrpTblCtrl, 0, 3);
            this.tblSheetListPane.Controls.Add(this.CboSheetList, 0, 1);
            this.tblSheetListPane.Controls.Add(this.LstSheetList, 0, 2);
            this.tblSheetListPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSheetListPane.Location = new System.Drawing.Point(0, 0);
            this.tblSheetListPane.Name = "tblSheetListPane";
            this.tblSheetListPane.RowCount = 4;
            this.tblSheetListPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tblSheetListPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tblSheetListPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSheetListPane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tblSheetListPane.Size = new System.Drawing.Size(232, 437);
            this.tblSheetListPane.TabIndex = 31;
            // 
            // SheetNavi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblSheetListPane);
            this.Name = "SheetNavi";
            this.Size = new System.Drawing.Size(232, 437);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SheetNavi_Paint);
            this.GrpTblCtrl.ResumeLayout(false);
            this.GrpSheetCtrl.ResumeLayout(false);
            this.GrpSheetCtrl.PerformLayout();
            this.tblSheetListPane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox LstSheetList;
        private System.Windows.Forms.GroupBox GrpTblCtrl;
        private System.Windows.Forms.Button btnReleaseFilter;
        private System.Windows.Forms.GroupBox GrpSheetCtrl;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnPrev;
        private System.Windows.Forms.Button BtnCfg;
        private System.Windows.Forms.Label lblPrevNext;
        private System.Windows.Forms.Label lblRefresh;
        private System.Windows.Forms.ComboBox CboSheetList;
        private System.Windows.Forms.TableLayoutPanel tblSheetListPane;
    }
}
