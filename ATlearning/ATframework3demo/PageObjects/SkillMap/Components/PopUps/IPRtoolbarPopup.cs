using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Analytics;
using ATframework3demo.PageObjects.SkillMap.IPR;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Components.PopUps
{
    public class IPRtoolbarPopup
    {
        public IWebDriver Driver { get; }

        public IPRtoolbarPopup(IWebDriver driver = default)
        {
            Driver = driver;

            var IPRbtn = new WebItem(
                "//button[contains(@class, 'ipr-button')]",
                "кнопка ИПР");


            IPRbtn.Click();
        }

        public CreateIPRpage CreateIPR()
        {
            var OpenProfileBtn = new WebItem(
                "//a[contains(@href, 'ipr-create')]",
                "Кнопка 'Добавить ИПР'");

            OpenProfileBtn.Click();

            return new CreateIPRpage();
        }

        public IPRlistPage IPRlist()
        {
            var EditProfileBtn = new WebItem(
                "//a[contains(@href, 'ipr-list')]",
                "Кнопка 'список всех ипр'");
            EditProfileBtn.Click();

            return new IPRlistPage();
        }
    }
}
