using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V133.Profiler;
using static System.Net.Mime.MediaTypeNames;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class MyProgressPage
    {
        public TopToolbar Toolbar { get; }

        public IWebDriver Driver { get; }

        public MyProgressPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }

        /// <summary>
        /// Проверяет правильность статистики по профилю.
        /// Обязательный параметр - profileName
        /// </summary>
        /// <param name="profileName">профиль специалиста</param>
        /// <param name="grade">грейд сотрудника по профилю (без %)</param>
        /// <param name="skills">список скиллов сотрудника</param>
        /// <param name="scores">список оценок за каждый скилл</param>
        /// <returns></returns>
        public bool CheckProgress(string profileName, string grade = null, List<string> skills = null, List<int> scores = null)
        {
            string gridXpath = "//div[@class='grid-element']";

            var profile = new WebItem(
                $"{gridXpath}/div[@class='profile-title']/label[contains(text(), '{profileName}')]",
                $"Карточка прогресса профиля {profileName}");

            if (profile.Count() == 0)
            {
                Log.Info($"Профиль '{profileName}' не найден");
                return false;
            }

            string currGridXpath = $"//label[contains(text(), '{profileName}')]/../../div[@class='overall-grade-block']";

            return CheckGrade(currGridXpath, grade) 
                && CheckSkills(currGridXpath, skills) 
                && CheckScores(currGridXpath, skills, scores);
        }

        private bool CheckGrade(string xpath, string grade)
        {
            if (grade == null)
                return true;

            var currGrade = new WebItem(
                $"{xpath}/div[@class='ui-progressbar ui-progressbar-lg']/span[contains(text(), '{grade}')]",
                $"");

            if (currGrade.Count() == 0)
                return false;
            else if (currGrade.Count() == 1)
                return true;

            Log.Error("Xpath нашел несколько элементов. Обнови xpath");
            return false;
        }
        private bool CheckSkills(string xpath, List<string> skills)
        {
            if (skills == null || skills.Count() == 0)
                return true;

            bool flag = true;

            for (int i = 1; i <= skills.Count(); i++)
            {
                var skill = new WebItem(
                    $"({xpath}/ul/li)[{i}]",
                    $"Скилл под номером {i}");

                if (!skill.InnerText().Contains(skills[i-1]))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        private bool CheckScores(string xpath, List<string> skills, List<int> scores)
        {
            if (skills == null || skills.Count() == 0)
                return true;

            bool flag = true;

            for (int i = 1; i <= skills.Count(); i++)
            {
                var skill = new WebItem(
                    $"({xpath}/ul/li)[{i}]",
                    $"Скилл под номером {i}");

                if (!skill.InnerText().Contains($"{skills[i - 1]} — {scores[i - 1]}"))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
    }
}
