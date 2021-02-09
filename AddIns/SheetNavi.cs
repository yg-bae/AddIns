using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Workbook = Microsoft.Office.Interop.Excel.Workbook;
using Worksheet = Microsoft.Office.Interop.Excel.Worksheet;

namespace AddIns
{
    public partial class SheetNavi : UserControl
    {
        public SheetNavi()
        {
            InitializeComponent();
        }

        private void MenuList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Workbook wb = Globals.ThisAddIn.Application.ActiveWorkbook;
            Worksheet ws = wb.Worksheets[MenuList.SelectedItem];
            ws.Activate();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshSheetList();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.PrevSheet();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.NextSheet();
        }

        private void RefreshSheetList()
        {
            Workbook wb = Globals.ThisAddIn.Application.ActiveWorkbook;
            MenuList.Items.Clear();
            foreach (Worksheet sht in wb.Worksheets)
            {
                MenuList.Items.Add(sht.Name);
            }
        }

        private int ActiveRefresh(int a)
        {
            BtnEnDisableChk();
            RefreshSheetList();
            return 0;
        }

        private void BtnEnDisableChk()
        {
            if (Globals.ThisAddIn.GetNumOfNext() > 0)
                BtnNext.Enabled = true;
            else
                BtnNext.Enabled = false;

            if (Globals.ThisAddIn.GetNumOfPrev() > 0)
                BtnPrev.Enabled = true;
            else
                BtnPrev.Enabled = false;
        }

        private void SheetNavi_Load(object sender, EventArgs e)
        {
            Globals.ThisAddIn.SetCallBack_ActiveRefresh(ActiveRefresh);
        }

        private void SheetNavi_VisibleChanged(object sender, EventArgs e)
        {
            RefreshSheetList();
        }
    }
}
