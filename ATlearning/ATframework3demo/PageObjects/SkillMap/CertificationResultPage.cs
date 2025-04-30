using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class CertificationResultPage
    {
        public TopToolbar Toolbar { get; }

        public IWebDriver Driver { get; }

        public CertificationResultPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }

        public WebItem CertificateBtn { get; } = new WebItem(
            "//button[@class='ui-btn ui-btn-success skillmap-btn']",
            "кнопка 'Оценить' внизу формы");

        public WebItem UserSelectField { get; } = new WebItem(
            "//select[@id='userSelect']",
            "поле выбора сотрудника");

        public WebItem ProfileSelectField { get; } = new WebItem(
            "//select[@id='profileSelect']",
            "поле выбора профиля");

        public CertificationListPage ClickOnSertificateBtn()
        {
            CertificateBtn.Click();
            return new CertificationListPage();
        }

        public CertificationResultPage SelectUser(string username)
        {
            UserSelectField.Click();
            var user = new WebItem(
                $"//select[@id='userSelect']/option[contains(text(), '{username}')]",
                $"Выбрать сотрудника {username}");

            user.Click();

            return new CertificationResultPage();
        }

        public CertificationResultPage SelectProfile(string profilename)
        {
            ProfileSelectField.Click();
            var user = new WebItem(
                $"//select[@id='profileSelect']/option[contains(text(), '{profilename}')]",
                $"Выбрать профиль {profilename}");

            user.Click();
            return new CertificationResultPage();
        }

        /// <summary>
        /// Вписывает оценки по профилю в инпуты по порядку
        /// </summary>
        /// <param name="grades">Оценки пользователя по порядку</param>
        /// <returns></returns>
        public CertificationResultPage GradeUser(int[] grades)
        {
            for(int i = 1; i < grades.Length + 1; i++)
            {
                var gradeInputs = new WebItem(
                $"(//div[@id='skillsContainer']//input)[{i}]",
                "");
                gradeInputs.SendKeys(Convert.ToString(grades[i - 1]));
            }

            return new CertificationResultPage();
        }
    }
}
