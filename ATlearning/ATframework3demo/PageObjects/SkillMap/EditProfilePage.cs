using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class EditProfilePage
    {
        public TopToolbar Toolbar { get; }

        public IWebDriver Driver { get; }

        public EditProfilePage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }

        public WebItem ProfileNameField { get; } = new WebItem(
            "//input[@id='specialistName']",
            "инпут 'Введите название профиля'");

        public WebItem SaveChangesBtn{ get; } = new WebItem(
            "//button[@class='ui-btn ui-btn-success skillmap-btn']",
            "кнопка 'Сохранить' внизу формы");

        public WebItem CancelBtn { get; } = new WebItem(
            "//a[@class='ui-btn ui-btn-light-border skillmap-btn']",
            "кнопка 'Отмена' внизу формы");

        public EditProfilePage InputProfileName(string profileName)
        {
            ProfileNameField.Clear();
            ProfileNameField.SendKeys(profileName);
            return new EditProfilePage();
        }

        public ProfileViewPage ClickOnSaveChangesBtn()
        {
            SaveChangesBtn.Click();
            return new ProfileViewPage();
        }

        public EditProfilePage CancelBtnChangesBtn()
        {
            CancelBtn.Click();
            return new EditProfilePage();
        }

        /// <summary>
        /// Заполнение поля компетеции и оценок этой компетеции
        /// </summary>
        /// <param name="numOfSkill">Каким скилл идется по счету в форме</param>
        /// <param name="skillName">Название компетенции</param>
        /// <param name="skillGrades">Массив с оценками компетеции</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public EditProfilePage FillSkillForm(int numOfSkill, string skillName, int[] skillGrades)
        {
            if (skillGrades.Length != 3)
            {
                Log.Error($"При заполнении оценок скилла {skillName} было передано не три оценки");
                throw new ArgumentException("Требуется массив из трех чисел");
            }

            var SkillNameField = new WebItem(
                $"//input[@name='skills[{numOfSkill - 1}][name]']",
                $"инпут 'Введите название профиля' номер {numOfSkill}");
            SkillNameField.Clear();
            SkillNameField.SendKeys(skillName);

            for (int i = 0; i < 3; i++)
            {
                var grade = new WebItem(
                    $"//input[@name='skills[{numOfSkill - 1}][scores][{i}][value]']",
                    $"оценка номер {i + 1} для профиля {skillName}");
                grade.Clear();
                grade.SendKeys(Convert.ToString(skillGrades[i]));
            }
            return new EditProfilePage();
        }
    }
}
