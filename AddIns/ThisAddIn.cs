using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using CustomPane = Microsoft.Office.Tools.CustomTaskPane;

namespace AddIns
{
    public partial class ThisAddIn
    {
        private Dictionary<string, Stack<string>> SheetHistoryDict_Prev = new Dictionary<string, Stack<string>>();
        private Dictionary<string, Stack<string>> SheetHistoryDict_Next = new Dictionary<string, Stack<string>>();
        private Dictionary<string, CustomPane> SheetNavPaneiDict = new Dictionary<string, CustomPane>();
        private string GotoSheet = null;
        private string CurrentWb = null;
        private Func<int, int> pFuncRibonButtonEnDisable;
        private Func<int, int> pFuncSheetNaviActiveRefresh;

        public void PrevSheet()
        {
            if (SheetHistoryDict_Prev[CurrentWb].Count > 0)
            {
                SheetHistoryDict_Next[CurrentWb].Push(this.Application.ActiveSheet.Name);
                GotoSheet = SheetHistoryDict_Prev[CurrentWb].Pop();
                this.Application.ActiveWorkbook.Sheets[GotoSheet].Select();
            }
        }

        public void NextSheet()
        {
            if (SheetHistoryDict_Next[CurrentWb].Count > 0)
            {
                SheetHistoryDict_Prev[CurrentWb].Push(this.Application.ActiveSheet.Name);
                GotoSheet = SheetHistoryDict_Next[CurrentWb].Pop();
                this.Application.ActiveWorkbook.Sheets[GotoSheet].Select();
            }
        }

        public void SetCallBack_RibonButtonEnDisable(Func<int, int> func)
        {
            pFuncRibonButtonEnDisable = func;
        }

        public void SetCallBack_ActiveRefresh(Func<int, int> func)
        {
            pFuncSheetNaviActiveRefresh = func;
        }

        public int GetNumOfNext()
        {
            return SheetHistoryDict_Next[CurrentWb].Count;
        }

        public int GetNumOfPrev()
        {
            return SheetHistoryDict_Prev[CurrentWb].Count;
        }

        private void CreateNewSheetHistoryStack(Excel.Workbook wb)
        {
            if (!SheetHistoryDict_Prev.ContainsKey(wb.Name))
            {
                Stack<string> SheetOpenHistoryStack_Prev = new Stack<string>();
                SheetHistoryDict_Prev[wb.Name] = SheetOpenHistoryStack_Prev;
            }

            if (!SheetHistoryDict_Next.ContainsKey(wb.Name))
            {
                Stack<string> SheetOpenHistoryStack_Next = new Stack<string>();
                SheetHistoryDict_Next[wb.Name] = SheetOpenHistoryStack_Next;
            }

            CurrentWb = wb.Name;
        }
        private void CreateNewSheetNaviPane()
        {
            string activeWb = Application.ActiveWorkbook.Name;
            if (!SheetNavPaneiDict.ContainsKey(activeWb))
            {
                SheetNavi obj = new SheetNavi();
                SheetNavPaneiDict[activeWb] = this.CustomTaskPanes.Add(obj, "Sheet Navigation");
            }

        }

        private void WorkbookActivate(Excel.Workbook wb)
        {
            CreateNewSheetHistoryStack(wb);
            CreateNewSheetNaviPane();
            pFuncRibonButtonEnDisable(0);
            pFuncSheetNaviActiveRefresh(0);
        }

        private void WorkSheetDeactivate(object sh)
        {
            CreateNewSheetHistoryStack(((Excel.Worksheet)sh).Parent);
            CreateNewSheetNaviPane();

            if (string.IsNullOrEmpty(GotoSheet))
            {
                SheetHistoryDict_Next[CurrentWb].Clear();
                SheetHistoryDict_Prev[CurrentWb].Push(((Excel.Worksheet)sh).Name);
            }
            GotoSheet = null;
            pFuncRibonButtonEnDisable(0);
            pFuncSheetNaviActiveRefresh(0);
        }
        
        public void ShowSheetNavi()
        {
            SheetNavPaneiDict[Application.ActiveWorkbook.Name].Visible = true;
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.WorkbookActivate += WorkbookActivate;
            this.Application.SheetDeactivate += WorkSheetDeactivate;
            CreateNewSheetNaviPane();
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
