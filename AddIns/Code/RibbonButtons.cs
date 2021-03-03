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

            // WorkbookOpen 이벤트에서는 excel만 실행시킨 경우에는 pane이 생성안됨
            // RibbonButton_Load 이벤트에서 excel만 실행시킨 경우 pane이 생성됨
            Globals.ThisAddIn.CreateSheetNaviPane(Properties.Settings.Default.SheetNavi_AlwaysShow);
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
