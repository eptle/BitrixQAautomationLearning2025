using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Mobile.More.CRM;

namespace ATframework3demo.PageObjects.Mobile.More
{
    public class MobileMoreListPage
    {
        public CRMpage openCRM()
        {
            var crmBtn = new MobileItem(
                "//android.widget.TextView[@resource-id=\"com.bitrix24.android:id/title\" and @text=\"CRM\"]",
                "кнопка CRM");
            crmBtn.Click();
            return new CRMpage();
        }
    }
}
