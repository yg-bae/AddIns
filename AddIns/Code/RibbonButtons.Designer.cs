
namespace AddIns
{
    partial class RibbonButtons : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonButtons()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            this.TabAddIns = this.Factory.CreateRibbonTab();
            this.GrpNextPrev = this.Factory.CreateRibbonGroup();
            this.ShowSheetListBtn = this.Factory.CreateRibbonButton();
            this.PrevBtn = this.Factory.CreateRibbonButton();
            this.NextBtn = this.Factory.CreateRibbonButton();
            this.TabAddIns.SuspendLayout();
            this.GrpNextPrev.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabAddIns
            // 
            this.TabAddIns.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.TabAddIns.Groups.Add(this.GrpNextPrev);
            this.TabAddIns.Label = "Add-In";
            this.TabAddIns.Name = "TabAddIns";
            // 
            // GrpNextPrev
            // 
            this.GrpNextPrev.Items.Add(this.ShowSheetListBtn);
            this.GrpNextPrev.Items.Add(this.PrevBtn);
            this.GrpNextPrev.Items.Add(this.NextBtn);
            this.GrpNextPrev.Label = "시트이동";
            this.GrpNextPrev.Name = "GrpNextPrev";
            // 
            // ShowSheetListBtn
            // 
            this.ShowSheetListBtn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ShowSheetListBtn.Label = "시트 리스트";
            this.ShowSheetListBtn.Name = "ShowSheetListBtn";
            this.ShowSheetListBtn.OfficeImageId = "ZoomOnePage";
            this.ShowSheetListBtn.ShowImage = true;
            this.ShowSheetListBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShowSheetListBtn_Click);
            // 
            // PrevBtn
            // 
            this.PrevBtn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.PrevBtn.Enabled = false;
            this.PrevBtn.Image = global::AddIns.Properties.Resources.Arrow_Left;
            this.PrevBtn.Label = "이전시트";
            this.PrevBtn.Name = "PrevBtn";
            this.PrevBtn.ShowImage = true;
            this.PrevBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.PrevBtn_Click);
            // 
            // NextBtn
            // 
            this.NextBtn.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.NextBtn.Enabled = false;
            this.NextBtn.Image = global::AddIns.Properties.Resources.Arrow_Right;
            this.NextBtn.Label = "다음시트";
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.ShowImage = true;
            this.NextBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.NextBtn_Click);
            // 
            // RibbonButtons
            // 
            this.Name = "RibbonButtons";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.TabAddIns);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonButton_Load);
            this.TabAddIns.ResumeLayout(false);
            this.TabAddIns.PerformLayout();
            this.GrpNextPrev.ResumeLayout(false);
            this.GrpNextPrev.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabAddIns;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpNextPrev;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton PrevBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton NextBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShowSheetListBtn;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonButtons Ribbon1
        {
            get { return this.GetRibbon<RibbonButtons>(); }
        }
    }
}
