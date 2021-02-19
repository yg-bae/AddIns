
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
            this.GrpButtons = new System.Windows.Forms.GroupBox();
            this.BtnOption = new System.Windows.Forms.Button();
            this.GrpPrevNext = new System.Windows.Forms.GroupBox();
            this.BtnPrev = new System.Windows.Forms.Button();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.SheetList = new System.Windows.Forms.ListBox();
            this.GrpButtons.SuspendLayout();
            this.GrpPrevNext.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpButtons
            // 
            this.GrpButtons.Controls.Add(this.BtnOption);
            this.GrpButtons.Controls.Add(this.GrpPrevNext);
            this.GrpButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpButtons.Location = new System.Drawing.Point(0, 0);
            this.GrpButtons.Name = "GrpButtons";
            this.GrpButtons.Size = new System.Drawing.Size(192, 91);
            this.GrpButtons.TabIndex = 0;
            this.GrpButtons.TabStop = false;
            // 
            // BtnOption
            // 
            this.BtnOption.Location = new System.Drawing.Point(6, 62);
            this.BtnOption.Name = "BtnOption";
            this.BtnOption.Size = new System.Drawing.Size(39, 23);
            this.BtnOption.TabIndex = 10;
            this.BtnOption.Text = "옵션";
            this.BtnOption.UseVisualStyleBackColor = true;
            this.BtnOption.Click += new System.EventHandler(this.BtnOption_Click);
            // 
            // GrpPrevNext
            // 
            this.GrpPrevNext.Controls.Add(this.BtnPrev);
            this.GrpPrevNext.Controls.Add(this.BtnRefresh);
            this.GrpPrevNext.Controls.Add(this.BtnNext);
            this.GrpPrevNext.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpPrevNext.Location = new System.Drawing.Point(3, 17);
            this.GrpPrevNext.Name = "GrpPrevNext";
            this.GrpPrevNext.Size = new System.Drawing.Size(186, 44);
            this.GrpPrevNext.TabIndex = 7;
            this.GrpPrevNext.TabStop = false;
            // 
            // BtnPrev
            // 
            this.BtnPrev.BackgroundImage = global::AddIns.Properties.Resources.Arrow_Left;
            this.BtnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPrev.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnPrev.Enabled = false;
            this.BtnPrev.ImageKey = "(없음)";
            this.BtnPrev.Location = new System.Drawing.Point(137, 17);
            this.BtnPrev.Name = "BtnPrev";
            this.BtnPrev.Size = new System.Drawing.Size(23, 24);
            this.BtnPrev.TabIndex = 9;
            this.BtnPrev.UseVisualStyleBackColor = true;
            this.BtnPrev.Click += new System.EventHandler(this.BtnPrev_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnRefresh.Location = new System.Drawing.Point(3, 17);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(75, 24);
            this.BtnRefresh.TabIndex = 8;
            this.BtnRefresh.Text = "새로고침";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.BackgroundImage = global::AddIns.Properties.Resources.Arrow_Right;
            this.BtnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnNext.Enabled = false;
            this.BtnNext.ImageKey = "(없음)";
            this.BtnNext.Location = new System.Drawing.Point(160, 17);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(23, 24);
            this.BtnNext.TabIndex = 4;
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // SheetList
            // 
            this.SheetList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SheetList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SheetList.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SheetList.FormattingEnabled = true;
            this.SheetList.Location = new System.Drawing.Point(0, 91);
            this.SheetList.Name = "SheetList";
            this.SheetList.Size = new System.Drawing.Size(192, 150);
            this.SheetList.TabIndex = 1;
            this.SheetList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.SheetList_DrawItem);
            this.SheetList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MenuList_MouseDoubleClick);
            this.SheetList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SheetList_MouseMove);
            // 
            // SheetNavi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SheetList);
            this.Controls.Add(this.GrpButtons);
            this.Name = "SheetNavi";
            this.Size = new System.Drawing.Size(192, 241);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SheetNavi_Paint);
            this.GrpButtons.ResumeLayout(false);
            this.GrpPrevNext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpButtons;
        private System.Windows.Forms.ListBox SheetList;
        private System.Windows.Forms.GroupBox GrpPrevNext;
        private System.Windows.Forms.Button BtnPrev;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnOption;
    }
}
