using OpenQA.Selenium;
using ATframework3demo.PageObjects.SkillMap.Components;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.BaseFramework;

namespace ATframework3demo.PageObjects.SkillMap.Components
{
    /// <summary>
    /// Класс для страниц с гридами
    /// </summary>
    public class BaseGridPage
    {
        public IWebDriver Driver { get; }

        public TopToolbar Toolbar { get; }

        public BaseGridPage(IWebDriver driver = default)
        {
            Driver = driver;
            Toolbar = new TopToolbar(driver);
        }

        public int CurrentPage { get; set; } = 1;

        public int NumOfPages
        {
            get
            {
                try
                {
                    var text = new WebItem(
                        "//span[@class='main-grid-panel-content-text']",
                        "Количество элементов в гриде").InnerText();

                    if (int.TryParse(text, out var pages))
                        return pages;

                    return 1; // Если не удалось распарсить — по умолчанию 1
                }
                catch
                {
                    return 1; // Если элемент отсутствует — по умолчанию 1
                }
            }
        }

        /// <summary>
        /// Проверяет, включена ли пагинация или нет
        /// </summary>
        public bool PaginationIsEnabled { get; set; } = true;

        /// <summary>
        /// Включает/выключает пагинацию на странице
        /// </summary>
        public void TogglePagination()
        {
            var switcher = new WebItem(
                "//a[@class='main-ui-pagination-arrow']",
                "Переключатель все/по_страницам снизу грида");
            Waiters.StaticWait_s(3);
            switcher.Click();

            PaginationIsEnabled = !PaginationIsEnabled;
        }

        /// <summary>
        /// Следующая страница грида
        /// </summary>
        public void NextPage()
        {
            var nextBtn = new WebItem(
                "//a[@class='main-ui-pagination-arrow main-ui-pagination-next']",
                "Кнопка 'следующая' снизу грида");
            Waiters.StaticWait_s(3);
            nextBtn.Click();
            CurrentPage++;
        }

        /// <summary>
        /// Предыдущая страница грида
        /// </summary>
        public void PreviousPage()
        {
            var prevBtn = new WebItem(
                "//a[@class='main-ui-pagination-arrow main-ui-pagination-prev']",
                "Кнопка 'предыдущая' снизу грида");
            Waiters.StaticWait_s(3);
            prevBtn.Click();
            CurrentPage--;
        }

        /// <summary>
        /// Перейти на выбранную страницу (не реализовано)
        /// </summary>
        public void GoToPageByNum(int num)
        {
            throw new NotImplementedException();
        }
    }
}
