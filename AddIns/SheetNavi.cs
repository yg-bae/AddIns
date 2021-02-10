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
using ListObject = Microsoft.Office.Interop.Excel.ListObject;

namespace AddIns
{
    public partial class SheetNavi : UserControl
    {
        const string NAME_IDX_TBL = "T_Index";
        const string NAME_SHEETS = "Sheet";
        const string NAME_NOTE = "Note";

        private Workbook Wb;
        private ListObject IndexTblObj;
        private Dictionary<string, string> ToolTipDics;

        public SheetNavi(Workbook wb)
        {
            InitializeComponent();
            Wb = wb;
        }

        private void MenuList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {   // 두개의 workbook이 열려 있을 때 deactive된 workbook에 있는 SheetList를 double-click 하면 Error 발생함
                Worksheet ws = Wb.Worksheets[SheetList.SelectedItem];
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
            SheetList.Items.Clear();

            IndexTblObj = GetTblObj(NAME_IDX_TBL);
            if (IndexTblObj != null)
            {
                ToolTipDics = new Dictionary<string, string>();
                int idxSheetName = GetColumnIdx(IndexTblObj, NAME_SHEETS);
                int idxNote = GetColumnIdx(IndexTblObj, NAME_NOTE);
                if((idxSheetName != -1) && (idxNote != -1))
                {
                    Excel.ListColumn listSheetNames = IndexTblObj.ListColumns[idxSheetName];
                    Excel.ListColumn listNotes = IndexTblObj.ListColumns[idxNote];

                    for(int i = 1; i <= listSheetNames.DataBodyRange.Rows.Count; i++)
                    {
                        string key = IndexTblObj.DataBodyRange[i, idxSheetName].Value;
                        string value = IndexTblObj.DataBodyRange[i, idxNote].Value;
                        ToolTipDics[key] = value;
                        SheetList.Items.Add(key);
                    }
                }
            }
            else
            {
                try
                {
                    foreach (Worksheet sht in Wb.Worksheets)
                    {
                        SheetList.Items.Add(sht.Name);
                    }
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                }
            }
        }

        private int GetColumnIdx(ListObject obj, string colName)
        {
            foreach(Excel.ListColumn col in obj.ListColumns)
            {
                if (col.Name == colName)
                    return col.Index;
            }
            return -1;
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

        private ListObject GetTblObj(string tblName)
        {
            ListObject tblObj = null;
            foreach (Worksheet ws in Wb.Worksheets)
            {
                try
                {
                    tblObj = ws.ListObjects[tblName];
                }
                catch (Exception)
                {
                }
            }
            return tblObj;
        }

        int hoveredIndex = -1;  // Class variable to keep track of which row is currently selected:
        ToolTip toolTip;

        private void SheetList_MouseMove(object sender, MouseEventArgs e)
        {
            // See which row is currently under the mouse:
            int newHoveredIndex = SheetList.IndexFromPoint(e.Location);

            // If the row has changed since last moving the mouse:
            if (hoveredIndex != newHoveredIndex)
            {
                if(toolTip != null) toolTip.Dispose();
                toolTip = new ToolTip();
                // Change the variable for the next time we move the mouse:
                hoveredIndex = newHoveredIndex;

                // If over a row showing data (rather than blank space):
                
                if (hoveredIndex > -1)
                {
                    string dicKey = SheetList.Items[hoveredIndex].ToString();
                    if((ToolTipDics != null) && (ToolTipDics.ContainsKey(dicKey) == true))
                    {
                        toolTip.InitialDelay = 1;
                        toolTip.Active = false;
                        toolTip.SetToolTip(SheetList, ToolTipDics[dicKey]);
                        toolTip.Active = true;
                    }
                }
            }
        }
    }
}
