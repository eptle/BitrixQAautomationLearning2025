using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Analytics;
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

        /// <summary>
        /// Кликает по кнопке "аналитика и отчеты" и после переходит во вкладку с выбранным номером (1-5)
        /// </summary>
        /// <param name="listItemNumber">Номер элемента в списке</param>
        /// <returns></returns>
        /// <exception cref="NoSuchElementException"></exception>
        public AnalyticsToolbarPopup ClickOnAnalyticsBtn() => new AnalyticsToolbarPopup(Driver);
    }
}
