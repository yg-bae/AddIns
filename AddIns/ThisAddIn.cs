using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Office.Tools.Excel;
using Office = Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using Workbook = Microsoft.Office.Interop.Excel.Workbook;
using Worksheet = Microsoft.Office.Interop.Excel.Worksheet;

using CustomPane = Microsoft.Office.Tools.CustomTaskPane;

namespace AddIns
{
    public partial class ThisAddIn
    {
        #region 이전 / 다음시트 선택기
        private Dictionary<string, Stack<string>> SheetHistoryDict_Prev = new Dictionary<string, Stack<string>>();
        private Dictionary<string, Stack<string>> SheetHistoryDict_Next = new Dictionary<string, Stack<string>>();
        private string GotoSheet = null;

        public int NumOfNext
        {
            get
            {
                string wbName = Application.ActiveWorkbook.Name;
                return (SheetHistoryDict_Next.ContainsKey(wbName)) ? SheetHistoryDict_Next[wbName].Count : 0;
            }
        }
        public int NumOfPrev
        {
            get
            {
                string wbName = Application.ActiveWorkbook.Name;
                return (SheetHistoryDict_Prev.ContainsKey(wbName)) ? SheetHistoryDict_Prev[wbName].Count : 0;
            }
        }

        public void PrevSheet()
        {
            if (SheetHistoryDict_Prev[Application.ActiveWorkbook.Name].Count > 0)
            {
                SheetHistoryDict_Next[Application.ActiveWorkbook.Name].Push(this.Application.ActiveSheet.Name);
                GotoSheet = SheetHistoryDict_Prev[Application.ActiveWorkbook.Name].Pop();
                this.Application.ActiveWorkbook.Sheets[GotoSheet].Select();
            }
        }
        public void NextSheet()
        {
            if (SheetHistoryDict_Next[Application.ActiveWorkbook.Name].Count > 0)
            {
                SheetHistoryDict_Prev[Application.ActiveWorkbook.Name].Push(this.Application.ActiveSheet.Name);
                GotoSheet = SheetHistoryDict_Next[Application.ActiveWorkbook.Name].Pop();
                this.Application.ActiveWorkbook.Sheets[GotoSheet].Select();
            }
        }

        public void SetCallBack_RibonButtonEnDisable(Func<int, int> func) => pFuncRibonButtonEnDisable = func;

        private void CreateNewSheetHistoryStack(Workbook wb)
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
        }
        #endregion 이전 / 다음시트 선택기


        #region Sheet Navigation
        private Dictionary<string, CustomPane> SheetNaviPaneDict = new Dictionary<string, CustomPane>();
        private Dictionary<string, SheetNavi> SheetNaviObjDict = new Dictionary<string, SheetNavi>();
        private Func<int, int> pFuncRibonButtonEnDisable;

        public void ShowSheetNavi()
        {
            CreateNewSheetNaviPane();
            SheetNaviPaneDict[Application.ActiveWorkbook.Name].Width = 250;
            SheetNaviObjDict[Application.ActiveWorkbook.Name].BtnEnDisableChk();
            SheetNaviPaneDict[Application.ActiveWorkbook.Name].Visible = true;
        }

        public void CreateNewSheetNaviPane()
        {
            Workbook wb = Application.ActiveWorkbook;
            if (!SheetNaviPaneDict.ContainsKey(wb.Name))
            {
                SheetNavi obj = new SheetNavi(wb);
                SheetNaviObjDict[wb.Name] = obj;
                SheetNaviPaneDict[wb.Name] = this.CustomTaskPanes.Add(obj, "Sheet Navigation");
                SheetNaviPaneDict[wb.Name].DockPosition = Properties.Settings.Default.SheetNavi_DockPosition;
                SheetNaviObjDict[wb.Name].RefreshSheetList();
            }
        }
        #endregion Sheet Navigation


        #region Event Function
        private void WorkbookActivate(Excel.Workbook wb)
        {
            CreateNewSheetHistoryStack(wb);
            CreateNewSheetNaviPane();
            pFuncRibonButtonEnDisable(0);
            SheetNaviObjDict[wb.Name].BtnEnDisableChk();
            if (Properties.Settings.Default.SheetNavi_AlwaysShow)
                ShowSheetNavi();
        }

        private void WorksheetActivate(object sh)
        {
            Worksheet sht = (Worksheet)sh;
            Workbook wb = sht.Parent;
            SheetNaviObjDict[wb.Name].SelectItem(sht.Name);
        }

        private void WorksheetDeactivate(object sh)
        {
            Worksheet sht = (Worksheet)sh;
            CreateNewSheetHistoryStack(sht.Parent);

            if (string.IsNullOrEmpty(GotoSheet))
            {
                SheetHistoryDict_Next[Application.ActiveWorkbook.Name].Clear();
                SheetHistoryDict_Prev[Application.ActiveWorkbook.Name].Push(sht.Name);
            }
            GotoSheet = null;
            pFuncRibonButtonEnDisable(0);

            if (SheetNaviObjDict.ContainsKey(Application.ActiveWorkbook.Name))
            {
                SheetNaviObjDict[Application.ActiveWorkbook.Name].BtnEnDisableChk();
            }
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.WorkbookActivate += WorkbookActivate;
            this.Application.SheetActivate += WorksheetActivate;
            this.Application.SheetDeactivate += WorksheetDeactivate;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        #endregion Evetn Function


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
