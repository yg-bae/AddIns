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
{   public partial class SheetNavi : UserControl
    {
        class SheetListItem : Dictionary<string, object>
        {
            const string ITM_NAME = "Name";
            const string ITM_FORE_COLOR = "ForeColor";
            const string ITM_BACK_COLOR = "BackColor";
            const string ITM_NOTE = "Note";

            public string Name
            {
                get => this[ITM_NAME].ToString();
                set => this[ITM_NAME] = value;
            }
            public Color? ForeColor
            {
                get => (Color?)this[ITM_FORE_COLOR];
                set => this[ITM_BACK_COLOR] = value;
            }

            public Color? BackColor
            {
                get => (Color?)this[ITM_BACK_COLOR];
                set => this[ITM_BACK_COLOR] = (Color)value;
            }

            public string Note
            {
                get => (this[ITM_NOTE] == null) ? null : this[ITM_NOTE].ToString();
                set => this[ITM_NOTE] = value;
            }

            public SheetListItem(string item, Color? foreColor = null, Color? backColor = null, string note = null)
            {
                this[ITM_NAME] = item;
                this[ITM_FORE_COLOR] = foreColor;
                this[ITM_BACK_COLOR] = backColor;
                this[ITM_NOTE] = note;
            }
        };

        const string TIDX_TBL_NAME = "T_Index";
        const string TIDX_SHEET = "Sheet";
        const string TIDX_NOTE = "Note";

        private Workbook Wb;
        private ListObject IndexTblObj;
        private Code.FrmOption Option;

        public SheetNavi(Workbook wb)
        {
            InitializeComponent();
            Wb = wb;
            Option = new Code.FrmOption();
        }

        #region Sheet Controllers
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
        #endregion Sheet Controllers

        #region Sheet List
        private void MenuList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 두개의 workbook이 열려 있을 때 deactive된 workbook에 있는 SheetList를 double-click 하면 Error 발생함
            try
            {
                SheetListItem selectedItem = SheetList.SelectedItem as SheetListItem;
                if (selectedItem != null)
                {
                    Worksheet ws = Wb.Worksheets[selectedItem.Name];
                    ws.Activate();
                }
            }
            catch (System.Runtime.InteropServices.COMException)
            {
            }
        }

        public void RefreshSheetList()
        {
            SheetList.Items.Clear();

            IndexTblObj = GetTblObj(TIDX_TBL_NAME);
            if (IndexTblObj != null)
            {
                int idxSheetName = GetColumnIdx(IndexTblObj, TIDX_SHEET);
                int idxNote = GetColumnIdx(IndexTblObj, TIDX_NOTE);
                if((idxSheetName != -1) && (idxNote != -1))
                {
                    Excel.ListColumn listSheetNames = IndexTblObj.ListColumns[idxSheetName];
                    for(int i = 1; i <= listSheetNames.DataBodyRange.Rows.Count; i++)
                    {
                        string sheetName = IndexTblObj.DataBodyRange[i, idxSheetName].Value;
                        string toolTip = IndexTblObj.DataBodyRange[i, idxNote].Value;
                        
                        Color foreColor = System.Drawing.ColorTranslator.FromOle((int)((double)IndexTblObj.DataBodyRange[i, idxSheetName].Font.Color));
                        Color backColor = System.Drawing.ColorTranslator.FromOle((int)((double)IndexTblObj.DataBodyRange[i, idxSheetName].Interior.Color));
                        SheetList.Items.Add(new SheetListItem(sheetName, foreColor, backColor, toolTip));
                    }
                }
            }
            else
            {
                try
                {
                    foreach (Worksheet sht in Wb.Worksheets)
                    {
                        SheetList.Items.Add(new SheetListItem(sht.Name));
                    }
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                }
            }
        }

        public void SelectItem(string itemName)
        {
            //myListBox.Items.Cast<EnquiryListItem>().Any(item => item.Text == ComboBox1.SelectedText.ToString())
            foreach (SheetListItem item in SheetList.Items.Cast<SheetListItem>())
            {
                //if (item.Name == itemName)
                if (item.ContainsValue(itemName))
                {
                    SheetList.SelectedItem = item;
                    break;
                }
            }
        }

        private void SheetList_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            SheetListItem sheetListItem = SheetList.Items[e.Index] as SheetListItem;
            SolidBrush foregroundBrush = new SolidBrush((((e.State & DrawItemState.Selected) != DrawItemState.Selected) && (sheetListItem.ForeColor != null)) ? (Color)sheetListItem.ForeColor : e.ForeColor);
            SolidBrush backgroundBrush = new SolidBrush((((e.State & DrawItemState.Selected) != DrawItemState.Selected) && (sheetListItem.BackColor != null)) ? (Color)sheetListItem.BackColor : e.BackColor);
            Font textFont = e.Font;
            string text = sheetListItem.Name;
            RectangleF rectangle = new RectangleF(new PointF(e.Bounds.X, e.Bounds.Y), new SizeF(e.Bounds.Width, g.MeasureString(text, textFont).Height));

            g.FillRectangle(backgroundBrush, rectangle);
            g.DrawString(text, textFont, foregroundBrush, rectangle);

            backgroundBrush.Dispose();
            foregroundBrush.Dispose();
            g.Dispose();
        }

        private void SheetNavi_Paint(object sender, PaintEventArgs e)
        {/* 여러 event를 확인해 봤으나 본 control이 visible / in-visible / re-visible될 때 모두 발생하는 유일한 event가 Paint event임.
          * 확인해본 event : SizeChanged, Load, VisibleChanged, Resize, Move, LocationChanged, Leave, Enter, EnabledChanged 
          * 하지만 본 event에서 UI를 refresh할 경우(RefreshSheetList) 시트의 개수가 많으면 refresh하면서 깜박임이 심함 
          * -> event를 통해서 refresh하는 것은 포기 */
            //   RefreshSheetList();
        }
        #endregion Sheet List

        #region Tool Tip Text
        int hoveredIndex = -1;  // Class variable to keep track of which row is currently selected:
        ToolTip toolTip;
        private void SheetList_MouseMove(object sender, MouseEventArgs e)
        {
            // See which row is currently under the mouse:
            int newHoveredIndex = SheetList.IndexFromPoint(e.Location);

            // If the row has changed since last moving the mouse:
            if (hoveredIndex != newHoveredIndex)
            {
                hoveredIndex = newHoveredIndex; // Change the variable for the next time we move the mouse:

                if (toolTip != null) toolTip.Dispose();
                toolTip = new ToolTip();

                if (hoveredIndex > -1)  // If over a row showing data (rather than blank space):
                {
                    SheetListItem sheetListItem = SheetList.Items[hoveredIndex] as SheetListItem;
                    if (sheetListItem.Note != null)
                    {
                        toolTip.InitialDelay = 1;
                        toolTip.Active = false;
                        toolTip.SetToolTip(SheetList, sheetListItem.Note);
                        toolTip.Active = true;
                    }
                }
            }
        }
        #endregion Tool Tip Text

        #region Common Library
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

        private int GetColumnIdx(ListObject obj, string colName)
        {
            foreach(Excel.ListColumn col in obj.ListColumns)
            {
                if (col.Name == colName)
                    return col.Index;
            }
            return -1;
        }
        #endregion Common Library

        #region Option
        private void BtnOption_Click(object sender, EventArgs e)
        {
            if(Option.ShowDialog() == DialogResult.OK)
            {
            }
        }
        #endregion Option

        #region Table Controllers
        private void BtnReleaseFilter_Click(object sender, EventArgs e)
        {
             try
            {
                Worksheet ws = Wb.ActiveSheet;
                foreach (ListObject tbl in ws.ListObjects)
                {
                    tbl.AutoFilter.ShowAllData(); // filter 해제
                    Globals.ThisAddIn.Application.CutCopyMode = (Microsoft.Office.Interop.Excel.XlCutCopyMode)0;// 영역 Copy 모드 해제
                    Globals.ThisAddIn.Application.Goto(tbl.Range[1.1]);  // 영역선택 해
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion Table Controllrs
    }
}
