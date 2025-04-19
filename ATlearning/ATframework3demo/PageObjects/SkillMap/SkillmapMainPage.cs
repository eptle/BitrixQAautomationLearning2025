using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.SkillMap.Analytics;
using ATframework3demo.PageObjects.SkillMap.Components;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.SkillMap
{
    public class SkillmapMainPage : BaseGridPage
    {
        public IWebDriver Driver { get; }

        public TopToolbar Toolbar { get; }

        public SkillmapMainPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }

        /// <summary>
        /// Выбираем профиль по названию, кликаем по бургеру и после переходим во вкладку с выбранным номером (1-4)
        /// </summary>
        /// <param name="profileName">Название профиля</param>
        /// <param name="listItemNumber">Номер элемента в списке</param>
        /// <returns></returns>
        /// <exception cref="NoSuchElementException"></exception>
        public object ChooseActionToProfile(string profileName, int listItemNumber)
        {
            var burger = new WebItem(
                $"//span[contains(text(), '{profileName}')]/../../..//a", 
                $"Бургер напротив элемента с именем {profileName}");

            var getID = new WebItem(
                $"//span[contains(text(), '{profileName}')]/../../../td[2]//span",
                $"ID профиля {profileName}");

            string ID = getID.InnerText();

            var PopupLink = new WebItem(
            $"(//div[@class='menu-popup-items']/a[contains(@href, '/{ID}/')])[{listItemNumber}]",
            $"Ссылка номер {listItemNumber} в попапе 'Аналитика и отчеты'");

            try
            {
                PopupLink.Click();
            }
            catch (NoSuchElementException)
            {
                Log.Error($"В бургере слева от профиля выбран неверный пункт (нет элемента под номером {listItemNumber}), либо ID '{ID}' неверный");
            }

            switch (listItemNumber)
            {
                case 1:
                    return new ProfileViewPage();

                case 2:
                    return new EditProfilePage();

                case 3:
                    return new CertificationResultPage();

                case 4:
                    return new CertificationListPage();

                default:
                    throw new NoSuchElementException();
            }
        }      
    }
}
