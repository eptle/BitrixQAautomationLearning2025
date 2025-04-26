using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Analytics;
using ATframework3demo.PageObjects.SkillMap.Components;
using ATframework3demo.PageObjects.SkillMap.Components.PopUps;
using ATframework3demo.PageObjects.SkillMap.IPR;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    /// <summary>
    /// Главная страница 
    /// </summary>
    public class SkillmapMainPage : BaseGridPage
    {
        public IWebDriver Driver { get; }

        public TopToolbar Toolbar { get; }

        public SkillmapMainPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }

        public WebItem AddProfileBtn { get; } = new WebItem(
            "//a[contains(@class, 'create-specialist-button')]",
            "Зеленая кнопка '+Добавить'");
        public WebItem IPRBtn { get; } = new WebItem(
            "//button[contains(@class, 'ipr-button')]",
            "Выпадающий список 'ИПР'");
        public WebItem AddIPRBtn { get; } = new WebItem(
            "//a[@href='/skillmap/ipr-create/']",
            "Кнопка 'Добавить ИПР'");
        public WebItem ListIPRBtn { get; } = new WebItem(
            "//a[@href='/skillmap/ipr-list/']",
            "Кнопка 'Список всех ИПР'");

        public CreateSpecialistPage ClickOnAddProfileBtn()
        {
            AddProfileBtn.Click();
            return new CreateSpecialistPage();
        }
        public SkillmapMainPage ClickOnIPR()
        {
            IPRBtn.Click();
            return new SkillmapMainPage();
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
        /// Кликаем по бургеру напротив выбранного профиля
        /// </summary>
        /// <param name="profileName">Название профиля специалиста</param>
        /// <returns></returns>
        public SkillmapMainPopup ClickOnBurger(string profileName) => new SkillmapMainPopup(profileName, Driver);     
    }
}
