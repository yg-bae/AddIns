using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
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

        private void CreateSheetHistoryStack(Workbook wb)
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

        private void DeleteSheetHistoryStack(Workbook wb)
        {
            if (SheetHistoryDict_Prev.ContainsKey(wb.Name)) 
                SheetHistoryDict_Prev.Remove(wb.Name);
            if (SheetHistoryDict_Next.ContainsKey(wb.Name))
                SheetHistoryDict_Next.Remove(wb.Name);
        }
        #endregion 이전 / 다음시트 선택기


        #region Sheet Navigation
        private Dictionary<string, CustomPane> SheetNaviPaneDict = new Dictionary<string, CustomPane>();
        private Dictionary<string, SheetNavi> SheetNaviObjDict = new Dictionary<string, SheetNavi>();
        private Func<int, int> pFuncRibonButtonEnDisable;

        public void CreateSheetNaviPane(bool ShowPane, Workbook workbook = null)
        {
            if (workbook == null)
            {
                if (Application.ActiveWorkbook != null)
                    workbook = Application.ActiveWorkbook;
                else
                    return;
            }

            if (!SheetNaviPaneDict.ContainsKey(workbook.Name))
            {
                SheetNavi obj = new SheetNavi(workbook);
                SheetNaviObjDict[workbook.Name] = obj;
                SheetNaviObjDict[workbook.Name].BtnEnDisableChk();

                SheetNaviPaneDict[workbook.Name] = CustomTaskPanes.Add(obj, "Sheet Navigation");
                SheetNaviPaneDict[workbook.Name].DockPosition = Properties.Settings.Default.SheetNavi_DockPosition;
                SheetNaviPaneDict[workbook.Name].Width = 250;
            }

            if(ShowPane)
            {
                SheetNaviObjDict[workbook.Name].RefreshSheetList();
                SheetNaviPaneDict[workbook.Name].Visible = true;
            }
            else
            {
                ;    // false라고 해서 굳이 pane을 끄지는 않는다.
            }
        }

        public void DeleteSheetNaviPane(Workbook workbook = null)
        {
            if (SheetNaviObjDict.ContainsKey(workbook.Name))
            {
                SheetNaviObjDict[workbook.Name].Dispose();
                SheetNaviObjDict.Remove(workbook.Name);
            }

            if (SheetNaviPaneDict.ContainsKey(workbook.Name))
            {
                SheetNaviPaneDict[workbook.Name].Dispose();
                SheetNaviPaneDict.Remove(workbook.Name);
            }
        }
        #endregion Sheet Navigation


        #region Event Function

        private void WorkbookOpen(Excel.Workbook wb)
        {
            CreateSheetHistoryStack(wb);

            // WorkbookOpen 이벤트에서는 excel만 실행시킨 경우에는 pane이 생성안됨
            // RibbonButton_Load 이벤트에서 excel만 실행시킨 경우 pane이 생성됨
            CreateSheetNaviPane(Properties.Settings.Default.SheetNavi_AlwaysShow, wb);

            pFuncRibonButtonEnDisable(0);
            SheetNaviObjDict[wb.Name].BtnEnDisableChk();
        }
        private void WorkbookBeforeClose(Excel.Workbook wb, ref bool cancel)
        {
            DeleteSheetHistoryStack(wb);
            DeleteSheetNaviPane(wb);
        }

        private void WorksheetActivate(object sh)
        {
            Worksheet sht = (Worksheet)sh;
            Workbook wb = sht.Parent;

            CreateSheetNaviPane(false, wb);
            SheetNaviObjDict[wb.Name].SelectItem(sht.Name);
        }

        private void WorksheetDeactivate(object sh)
        {
            Worksheet sht = (Worksheet)sh;
            CreateSheetHistoryStack(sht.Parent);

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
            Application.WorkbookOpen += WorkbookOpen;
            Application.WorkbookBeforeClose += WorkbookBeforeClose;

            Application.SheetActivate += WorksheetActivate;
            Application.SheetDeactivate += WorksheetDeactivate;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        #endregion Event Function


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
