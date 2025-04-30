using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Analytics;
using ATframework3demo.PageObjects.SkillMap.Components.PopUps;
using ATframework3demo.PageObjects.SkillMap.IPR;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Components
{
    /// <summary>
    /// Класс описывает работу тулбара сверху всех страниц модуля SkillMap. 
    /// В дальнейшем класс подключается к другим страницам, где присутствует этот тулбар
    /// </summary>
    public class TopToolbar
    {
        public IWebDriver Driver { get; }

        public TopToolbar(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public WebItem SpecialistProfilesBtn { get; } = new WebItem(
            "//a[contains(@class, 'specialist-profiles-button')]",
            "Кнопка 'Профили специалистов'");

        public WebItem MyProgressBtn { get; } = new WebItem(
            "//a[contains(@class, 'my-progress-button')]",
            "Кнопка 'Мой прогресс'");
        public WebItem IPRBtn { get; } = new WebItem(
            "//button[contains(@class, 'ipr-button')]",
            "Выпадающий список 'ИПР'");
        public WebItem AddIPRBtn { get; } = new WebItem(
            "//a[@href='/skillmap/ipr-create/']",
            "Кнопка 'Добавить ИПР'");
        public WebItem ListIPRBtn { get; } = new WebItem(
            "//a[@href='/skillmap/ipr-list/']",
            "Кнопка 'Список всех ИПР'");

        public SkillmapMainPage ClickOnSpecialistProfilesBtn()
        {
            SpecialistProfilesBtn.Click();
            return new SkillmapMainPage();
        }

        public MyProgressPage ClickOnMyProgressBtn()
        {
            MyProgressBtn.Click();
            return new MyProgressPage();
        }

        public TopToolbar ClickOnIPR()
        {
            IPRBtn.Click();
            return new TopToolbar();
        }
        public IPRstatPage ClickOnAddIPR()
        {
            AddIPRBtn.Click();
            return new IPRstatPage();
        }
        public IPRlistPage ClickOnListIPR()
        {
            ListIPRBtn.Click();
            return new IPRlistPage();
        }

        /// <summary>
        /// Кликает по кнопке "аналитика и отчеты"
        /// </summary>
        /// <returns></returns>
        public AnalyticsToolbarPopup ClickOnAnalyticsBtn() => new AnalyticsToolbarPopup(Driver);

        /// <summary>
        /// Кликает по кнопке "ИПР"
        /// </summary>
        /// <returns></returns>
        public IPRtoolbarPopup ClickOnIPRBtn() => new IPRtoolbarPopup(Driver);
    }
}
