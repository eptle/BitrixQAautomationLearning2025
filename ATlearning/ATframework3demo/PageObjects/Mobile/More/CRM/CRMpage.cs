using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.Mobile.More.CRM
{
    public class CRMpage
    {
        public CRMpopup ClickPlusBtn()
        {
            var plusBtn = new MobileItem(
                "//android.widget.FrameLayout[@content-desc=\"KANBAN_STAGE_ADD_BTN\"]",
                "плюсик снизу справа");
            plusBtn.Click();
            return new CRMpopup();
        }
    }
}
