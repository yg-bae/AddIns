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
        private Workbook Wb;

        public SheetNavi(Workbook wb)
        {
            InitializeComponent();
            Wb = wb;
        }

        private void MenuList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {   // 두개의 workbook이 열려 있을 때 deactive된 workbook에 있는 SheetList를 double-click 하면 Error 발생함
                Worksheet ws = Wb.Worksheets[MenuList.SelectedItem];
                ws.Activate();
            }
            catch (System.Runtime.InteropServices.COMException)
            {
            }
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
            MenuList.Items.Clear();
            try
            {
                foreach (Worksheet sht in Wb.Worksheets)
                {
                    MenuList.Items.Add(sht.Name);
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {
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
