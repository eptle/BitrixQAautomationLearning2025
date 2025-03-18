using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.Mobile.More.CRM
{
    public class CRMpopup
    {
        public DealWizard SelectDeal()
        {
            var dealBtn = new MobileItem(
                "//android.widget.TextView[@content-desc=\"CRM_ENTITY_TAB_DEAL_CONTEXT_MENU_2_title\"]",
                "Кнопка сделки");
            dealBtn.Click();
            return new DealWizard();
        }
    }
}
