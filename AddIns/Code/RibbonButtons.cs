using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddIns
{
    public partial class RibbonButtons
    {
        private void RibbonButton_Load(object sender, RibbonUIEventArgs e)
        {
            Globals.ThisAddIn.SetCallBack_RibonButtonEnDisable(BtnEnDisableChk);

            /* WorkbookOpen 이벤트에서는 excel만 실행시킨 경우에는 pane이 생성안됨
             * RibbonButton_Load 이벤트에서 excel만 실행시킨 경우 pane이 생성됨
             * 현 위치에서 CreateSheetNaviPane()를 호출하면
             *  excel 파일을 열어서 excel을 실행시킨 경우 아직 workbook이 activate 완료되지 않은 상태에서 ActvieWorkbook을 받아오는데 실패하여
             *  RiboonButton_Load가 실패하게됨 Try-Catch도 동작하지 않음.
             */
            //Globals.ThisAddIn.CreateSheetNaviPane(Properties.Settings.Default.SheetNavi_AlwaysShow);
        }

        private void NextBtn_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.NextSheet();
        }

        private void PrevBtn_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.PrevSheet();
        }
        
        private int BtnEnDisableChk(int a)
        {
            if (Globals.ThisAddIn.NumOfNext > 0)
                NextBtn.Enabled = true;
            else
                NextBtn.Enabled = false;

            if (Globals.ThisAddIn.NumOfPrev > 0)
                PrevBtn.Enabled = true;
            else
                PrevBtn.Enabled = false;
            return 0;
        }

        private void ShowSheetListBtn_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.CreateSheetNaviPane(true);
        }

    }
}
