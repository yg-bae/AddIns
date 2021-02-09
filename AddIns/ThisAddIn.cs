using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace AddIns
{
    public partial class ThisAddIn
    {
        private Dictionary<string, Stack<string>> SheetHistoryDics_Prev = new Dictionary<string, Stack<string>>();
        private Dictionary<string, Stack<string>> SheetHistoryDics_Next = new Dictionary<string, Stack<string>>();
        private string GotoSheet = null;
        private string CurrentWb = null;
        private Func<int, int> pFuncRibonButtonEnDisable;
        private Func<int, int> pFuncSheetNaviButtonEnDisable;

        private Microsoft.Office.Tools.CustomTaskPane customPane;

        public void PrevSheet()
        {
            if (SheetHistoryDics_Prev[CurrentWb].Count > 0)
            {
                SheetHistoryDics_Next[CurrentWb].Push(this.Application.ActiveSheet.Name);
                GotoSheet = SheetHistoryDics_Prev[CurrentWb].Pop();
                this.Application.ActiveWorkbook.Sheets[GotoSheet].Select();
            }
        }

        public void NextSheet()
        {
            if (SheetHistoryDics_Next[CurrentWb].Count > 0)
            {
                SheetHistoryDics_Prev[CurrentWb].Push(this.Application.ActiveSheet.Name);
                GotoSheet = SheetHistoryDics_Next[CurrentWb].Pop();
                this.Application.ActiveWorkbook.Sheets[GotoSheet].Select();
            }
        }

        public void SetCallBack_RibonButtonEnDisable(Func<int, int> func)
        {
            pFuncRibonButtonEnDisable = func;
        }

        public void SetCallBack_SheetNaviButtonEnDisable(Func<int, int> func)
        {
            pFuncSheetNaviButtonEnDisable = func;
        }

        public int GetNumOfNext()
        {
            return SheetHistoryDics_Next[CurrentWb].Count;
        }

        public int GetNumOfPrev()
        {
            return SheetHistoryDics_Prev[CurrentWb].Count;
        }

        private void CreateNewSheetHistoryStack(Excel.Workbook wb)
        {
            if (!SheetHistoryDics_Prev.ContainsKey(wb.Name))
            {
                Stack<string> SheetOpenHistoryStack_Prev = new Stack<string>();
                SheetHistoryDics_Prev[wb.Name] = SheetOpenHistoryStack_Prev;
            }

            if (!SheetHistoryDics_Next.ContainsKey(wb.Name))
            {
                Stack<string> SheetOpenHistoryStack_Next = new Stack<string>();
                SheetHistoryDics_Next[wb.Name] = SheetOpenHistoryStack_Next;
            }

            CurrentWb = wb.Name;
        }

        private void WorkbookActivate(Excel.Workbook wb)
        {
            CreateNewSheetHistoryStack(wb);
            pFuncRibonButtonEnDisable(0);
            pFuncSheetNaviButtonEnDisable(0);
        }

        private void WorkSheetDeactivate(object sh)
        {
            CreateNewSheetHistoryStack(((Excel.Worksheet)sh).Parent);

            if (string.IsNullOrEmpty(GotoSheet))
            {
                SheetHistoryDics_Next[CurrentWb].Clear();
                SheetHistoryDics_Prev[CurrentWb].Push(((Excel.Worksheet)sh).Name);
            }
            GotoSheet = null;
            pFuncRibonButtonEnDisable(0);
            pFuncSheetNaviButtonEnDisable(0);
        }
        
        public void ShowSheetNavi()
        {
            customPane.Visible = true;
        }

        private void CreateNewSheetNavi()
        {
            SheetNavi obj = new SheetNavi();
            customPane = this.CustomTaskPanes.Add(obj, "Sheet Navigation");
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.WorkbookActivate += WorkbookActivate;
            this.Application.SheetDeactivate += WorkSheetDeactivate;
            CreateNewSheetNavi();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
