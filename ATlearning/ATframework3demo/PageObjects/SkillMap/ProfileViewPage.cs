using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class ProfileViewPage
    {
        public TopToolbar Toolbar { get; }

        public IWebDriver Driver { get; }

        public ProfileViewPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }

        /// <summary>
        /// Сверяет название профиля, скиллы и оценки грейдов. Список скиллов и оценок должен идти в порядке заполнения данных при создании профиля
        /// </summary>
        /// <param name="profileName">имя профиля</param>
        /// <param name="skills">список с названиями скиллов</param>
        /// <param name="grades">список с массивами длины 3 с оценками</param>
        /// <returns></returns>
        public bool CheckProfile(string profileName, List<string> skills, List<int[]> grades)
        {
            if (skills.Count != grades.Count)
            {
                Log.Error($"Количество скиллов и количество оценок не совпадает: было передано {skills.Count} скиллов и {grades.Count} пачек оценок");
                throw new Exception();
            }
            return CheckProfileName(profileName) && CheckSkills(skills) && CheckGrades(grades);

        }

        private bool CheckProfileName(string profileName)
        {
            var name = new WebItem(
                "(//input[@class='ui-ctl-element ui-ctl-textbox ui-ctl-input' and @type='text'])[1]",
                "Название профиля");

            if (name.GetAttribute("value") == profileName)
                return true;

            return false;
        }

        private bool CheckSkills(List<string> skills)
        {
            for (int i = 2; i <= skills.Count + 1; i++) // ублюдская реализация, надо будет переделать
            {
                var skillName = new WebItem(
                    $"(//input[@class='ui-ctl-element ui-ctl-textbox ui-ctl-input' and @type='text'])[{i}]",
                    $"Скилл номер {i - 1}");

                if (skillName.GetAttribute("value") != skills[i - 2])
                {
                    Log.Error($"скилл '{skillName.GetAttribute("value")}' не совпадает с введенным скиллом '{skills[i - 2]}'");
                    return false;
                }
            }

            return true;
        }

        private bool CheckGrades(List<int[]> grades)
        {
            int numOfGrades = 3;

            for (int i = 0; i < grades.Count; i++)
                for (int j = 0; j < numOfGrades; j++)
                {
                    var grade = new WebItem(
                        $"//input[@name='skills[{i}][scores][{j}][value]']",
                        $"оценка номер {i + 1} для профиля номер {j + 1}");

                    if (Convert.ToInt32(grade.GetAttribute("value")) != (grades[i][j]))
                    {
                        Log.Error($"В строке номер {i + 1} не совпадает оценка номер {j + 1}");
                        return false;
                    }
                }

            return true;
        }

        public WebItem EditProfileBtn { get; } = new WebItem(
                "//a[@class='ui-btn ui-btn-success-light skillmap-btn']",
                "Кнопка 'редактировать'");

        public WebItem GoBackBtn { get; } = new WebItem(
                "//a[@class='ui-btn ui-btn-light-border skillmap-btn']",
                "Кнопка 'вернуться'");

        public EditProfilePage EditProfile()
        {
            EditProfileBtn.Click();
            return new EditProfilePage();
        }

        public SkillmapMainPage GoToSkillmapMain()
        {
            GoBackBtn.Click();
            return new SkillmapMainPage();
        }
    }
}
