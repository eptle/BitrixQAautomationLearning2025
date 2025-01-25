using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects.Mobile
{
    public class MobileLoginPage : BaseLoginPage
    {
        public MobileLoginPage(PortalInfo portal) : base(portal)
        {
        }

        public MobileHomePage Login(User admin)
        {
            var enterAddresBtn = new MobileItem("//android.widget.TextView[@content-desc='authFormEnterAddressButton']",
                "Кнопка 'введите адрес'");
            var portalAddresField = new MobileItem("//android.widget.EditText[@content-desc='signInPortalInput']",
                "Поле для ввода адреса портала");
            var loginField = new MobileItem("//android.widget.EditText[@content-desc='signInPortalFormPhoneInput']",
                "Поле для ввода логина");
            var pwdField = new MobileItem("//android.widget.EditText[@content-desc='passwordFormInput']",
                "Поле для ввода пароля");
            var nextBtn = new MobileItem("//android.widget.Button[@resource-id='com.bitrix24.android:id/btnNext']",
                "Кнопка 'Далее'");

            // переходим к форме ввода адреса портала
            enterAddresBtn.Click();

            // вводим адресс портала и дальше
            portalAddresField.SendKeys(portalInfo.PortalUri.ToString());
            nextBtn.Click();

            // вводим логин и дальше
            loginField.SendKeys(admin.LoginAkaEmail);
            nextBtn.Click();

            // вводим пароль и дальше
            pwdField.SendKeys(admin.Password, logInputtedText: false);
            nextBtn.Click();

            return new MobileHomePage();
        }
    }
}
