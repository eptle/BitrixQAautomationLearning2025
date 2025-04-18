using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Analytics;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap.Components
{
    /// <summary>
    /// Класс описывает работу тулбара сверху всех страниц модуля. 
    /// В дальнейшем класс подключается к другим пейджам, где присутствует этот тулбар
    /// </summary>
    public class TopToolbar
    {
        public IWebDriver Driver { get; }

        public TopToolbar(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public WebItem AddProfileBtn { get; } = new WebItem(
            "//a[contains(@class, 'create-specialist-button')]",
            "Зеленая кнопка 'Добавить'");

        public WebItem SpecialistProfilesBtn { get; } = new WebItem(
            "//a[contains(@class, 'specialist-profiles-button')]",
            "Кнопка 'Профили специалистов'");

        public WebItem MyProgressBtn { get; } = new WebItem(
            "//a[contains(@class, 'my-progress-button')]",
            "Кнопка 'Мой прогресс'");

        public WebItem AnalyticsBtn { get; } = new WebItem(
            "//button[contains(@class, 'analytics-button')]",
            "Кнопка 'Аналитика и отчёты'");

        public CreateSpecialistPage ClickOnAddProfileBtn()
        {
            AddProfileBtn.Click();
            return new CreateSpecialistPage();
        }

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

        public object ClickOnAnalyticsBtn(int listItemNumber)
        {
            AnalyticsBtn.Click();

            var PopupLink = new WebItem(
            $"(//div[@class='menu-popup-items']/a)[{listItemNumber}]",
            $"Ссылка номер {listItemNumber}");

            PopupLink.Click();

            switch(listItemNumber)
            {
                case 1:
                    return new AllAttestationsPage();

                case 2:
                    return new IPRlistPage();

                case 3:
                    return new UsersWithoutCertificationPage();

                case 4:
                    return new StatByProfilesGridPage();

                case 5:
                    return new StatByProfilesGraphPage();

                default:
                    Log.Error("В тулбаре в попапе 'Аналитика и отчеты' выбран неверный пункт меню");
                    throw new NoSuchElementException();
            }
        }
    }
}
