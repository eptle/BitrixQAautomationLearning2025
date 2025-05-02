using OpenQA.Selenium;
using ATframework3demo.PageObjects.SkillMap.Components;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;

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

                    return 1;
                }
                catch
                {
                    return 1;
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
            nextBtn.Click();
            Waiters.StaticWait_s(3);
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
            prevBtn.Click();
            Waiters.StaticWait_s(3);
            CurrentPage--;
        }

        /// <summary>
        /// Перейти на выбранную страницу (не реализовано)
        /// </summary>
        public void GoToPageByNum(int num)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Сортирует данные в гриде по заданному параметру (значение аттрибута data-name)
        /// </summary>
        /// <param name="dbField">значение аргумента data-name в теге th</param>
        public void SortBy(string dbField)
        {
            var tableHeader = new WebItem(
                $"//th[@data-name='{dbField}']",
                $"Заголовок колонки {dbField}");

            tableHeader.Click();
            Waiters.StaticWait_s(3);
        }

        /// <summary>
        /// Проверяет наличие записи с переданными данными в таблице. 
        /// Колонки, не требующие проверки, записать пустой строкой.
        /// </summary>
        /// <param name="record">Список значений в строке таблицы</param>
        /// <returns></returns>
        public bool IsDataCorrect(List<string> record)
        {
            int numOfCols = record.Count();

            for (int page = 1; page <= NumOfPages; page++)
            {
                var gridRows = new WebItem(
                "//tr[@class='main-grid-row main-grid-row-body']",
                "Записи в гриде");

                int numOfRows = gridRows.Count();

                for (int i = 1; i <= numOfRows; i++)
                {
                    string xpath = $"(//tr[@class='main-grid-row main-grid-row-body'])[{i}]";
                    bool isMatch = true;

                    for (int j = 1; j <= numOfCols; j++)
                    {
                        var cell = new WebItem(
                        $"({xpath}/td[@class='main-grid-cell main-grid-cell-left'])[{j}]//span",
                        "Запись в ячейке");
                        string innerText = cell.InnerText();
                        if (!innerText.Contains(record[j - 1]))
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    if (isMatch)
                        return true;
                }

                try
                {
                    NextPage();
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
