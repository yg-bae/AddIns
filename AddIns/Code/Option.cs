using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddIns.Code
{
    public partial class FrmOption : Form
    {
        public FrmOption()
        {
            InitializeComponent();
        }

        private void FrmOption_Shown(object sender, EventArgs e)
        {
            ChkAlwaysShow.Checked = Properties.Settings.Default.SheetNavi_AlwaysShow;
            if (Properties.Settings.Default.SheetNavi_DockPosition == Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionLeft) RdoDockLeft.Checked = true;
            else RdoDockRight.Checked = true;

            LblVersion.Text = "Ver." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SheetNavi_AlwaysShow = ChkAlwaysShow.Checked;
            Properties.Settings.Default.SheetNavi_DockPosition = (RdoDockLeft.Checked) ? Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionLeft : Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
            Properties.Settings.Default.Save();

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
