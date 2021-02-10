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

        public void RefreshSheetList()
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

        public void BtnEnDisableChk()
        {
            if (Globals.ThisAddIn.NumOfNext > 0)
                BtnNext.Enabled = true;
            else
                BtnNext.Enabled = false;

            if (Globals.ThisAddIn.NumOfPrev > 0)
                BtnPrev.Enabled = true;
            else
                BtnPrev.Enabled = false;
        }

        private void SheetNavi_Paint(object sender, PaintEventArgs e)
        {/* 여러 event를 확인해 봤으나 본 control이 visible / in-visible / re-visible될 때 모두 발생하는 유일한 event가 Paint event임.
          * 확인해본 event : SizeChanged, Load, VisibleChanged, Resize, Move, LocationChanged, Leave, Enter, EnabledChanged 
          * 하지만 본 event에서 UI를 refresh할 경우(RefreshSheetList) 시트의 개수가 많으면 refresh하면서 깜박임이 심함 
          * -> event를 통해서 refresh하는 것은 포기 */
            //   RefreshSheetList();
        }
    }
}
