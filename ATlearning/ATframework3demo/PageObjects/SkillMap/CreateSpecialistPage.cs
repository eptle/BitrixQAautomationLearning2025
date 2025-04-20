using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;
using System.ComponentModel;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class CreateSpecialistPage
    {
        public IWebDriver Driver { get; }

        public TopToolbar Toolbar { get; }

        public CreateSpecialistPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar();
        }

        public WebItem ProfileNameField { get; } = new WebItem(
            "//input[@id='specialistName']",
            "инпут 'Введите название профиля'");

        public WebItem AddProfileBtn { get; } = new WebItem(
            "//div[@id='addSkillBtn']",
            "кнопка Добавить компетенцию");

        public WebItem CreateProfileBtn { get; } = new WebItem(
            "//button[@class='ui-btn ui-btn-success skillmap-btn']",
            "кнопка 'Создать' внизу формы");

        public WebItem CancelBtn { get; } = new WebItem(
            "//a[@class='ui-btn ui-btn-light-border skillmap-btn']",
            "кнопка 'Отмена' внизу формы");

        public CreateSpecialistPage InputProfileName(string profileName)
        {
            ProfileNameField.SendKeys(profileName);
            return new CreateSpecialistPage();
        }

        public CreateSpecialistPage ClickOnAddProfileBtn()
        {
            AddProfileBtn.Click();
            return new CreateSpecialistPage();
        }

        public CreateSpecialistPage ClickOnCreateProfileBtn()
        {
            CreateProfileBtn.Click();
            return new CreateSpecialistPage();
        }

        public CreateSpecialistPage ClickOnCancelBtn()
        {
            CancelBtn.Click();
            return new CreateSpecialistPage();
        }

        /// <summary>
        /// Нажимает на крестик напротив компетенции
        /// </summary>
        /// <param name="num">Номер крестика</param>
        /// <returns></returns>
        public CreateSpecialistPage ClickOnRemoveSkillBtn(int num)
        {
            var CreateProfileBtn = new WebItem(
            $"(//div[@class='remove-skill-btn ui-btn ui-icon-set --cross-40'])[{num}]",
            $"крестик напротив скилла номер {num}");

            return new CreateSpecialistPage();
        }

        /// <summary>
        /// Заполнение формы компетеции и оценки этой компетеции
        /// </summary>
        /// <param name="numOfSkill">Каким скилл идется по счету в форме</param>
        /// <param name="skillName">Название компетенции</param>
        /// <param name="skillGrades">Массив с оценками компетеции</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public CreateSpecialistPage FillSkillForm(int numOfSkill, string skillName, int[] skillGrades)
        {   
            if (skillGrades.Length != 3)
            {
                Log.Error($"При заполнении оценок скилла {skillName} было передано не три оценки");
                throw new ArgumentException("Требуется массив из трех чисел");
            }

            var SkillNameField = new WebItem(
                $"//input[@name='skills[{numOfSkill - 1}][name]']",
                $"инпут 'Введите название профиля' номер {numOfSkill}");
            SkillNameField.SendKeys(skillName);

            for (int i = 0; i < 3; i++)
            {
                var grade = new WebItem(
                    $"//label/input[@name='skills[{numOfSkill}][scores][{skillGrades[i]}][value]']",
                    $"оценка номер {i + 1} для профиля {skillName}");
                grade.SendKeys(Convert.ToString(skillGrades[i]));
            }
            return new CreateSpecialistPage();
        }


    }
}
