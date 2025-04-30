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

        public CreateSpecialistPage ClickOnAddProfileBtn()
        {
            AddProfileBtn.Click();
            return new CreateSpecialistPage();
        }
        
        /// <summary>
        /// Кликаем по бургеру напротив выбранного профиля
        /// </summary>
        /// <param name="profileName">Название профиля специалиста</param>
        /// <returns></returns>
        public SkillmapMainPopup ClickOnBurger(string profileName) => new SkillmapMainPopup(profileName, Driver);

        public bool IsProfileExists(string profileName)
        {
            var profile = new WebItem(
                $"//span[@class='main-grid-cell-content' and contains(text(), '{profileName}')]",
                $"Профиль с именем {profileName}");
            try
            {
                profile.InnerText();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
