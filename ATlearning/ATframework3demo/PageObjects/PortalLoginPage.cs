using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ATframework3demo.PageObjects;

namespace atFrameWork2.PageObjects
{
    class PortalLoginPage : BaseLoginPage
    {
        IWebDriver Driver { get; }

        public PortalLoginPage(PortalInfo portal, IWebDriver driver = default) : base(portal)
        {
            Driver = driver;
        }

        public PortalHomePage Login(User admin)
        {
            WebDriverActions.OpenUri(portalInfo.PortalUri, Driver);
            var loginField = new WebItem("//input[@id='login' or @name='USER_LOGIN']", "Поле для ввода логина");
            var pwdField = new WebItem("//input[@id='password' or @name='USER_PASSWORD']", "Поле для ввода пароля");
            loginField.SendKeys(admin.LoginAkaEmail, Driver);
            if (!pwdField.WaitElementDisplayed(1, Driver))
                loginField.SendKeys(Keys.Enter, Driver);
            pwdField.SendKeys(admin.Password, Driver, logInputtedText: false);
            pwdField.SendKeys(Keys.Enter, Driver);
            return new PortalHomePage(Driver);
        }
    }
}
