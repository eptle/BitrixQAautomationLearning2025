using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Components;
using ATframework3demo.PageObjects.SkillMap.Components.PopUps;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class CertificationListPage : BaseGridPage
    {
        public TopToolbar Toolbar { get; }

        public IWebDriver Driver { get; }

        public CertificationListPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }

        /// <summary>
        /// Проверка грейда у пользователя
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="grade">Грейд пользователя (пример: "Junior (100%)")</param>
        /// <returns></returns>
        public bool CheckCertification(string username, string grade)
        {
            var generalGrade = new WebItem(
                $"//span[@class='main-grid-cell-content' and contains(text(), '{username}')]/../../..//span[contains(text(), '{grade}')]",
                $"Грейд {grade} сотрудника {username}");

            string realGrade = generalGrade.InnerText();

            if (realGrade != grade)
            {
                Log.Error($"Грейды {realGrade} и {grade} не совпадают");
                return false;
            }
            return true;
        }

        public StatByProfilesPopup ClickOnBurger(string profileName) => new StatByProfilesPopup(profileName, Driver);
    }
}
