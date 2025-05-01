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

        /// <summary>
        /// Сортирует данные в гриде по заданному параметру
        /// </summary>
        /// <param name="dbField">значение аргумента data-name в теге th</param>
        public void SortBy(string dbField)
        {
            var tableHeader = new WebItem(
                $"//th[@data-name='{dbField}']",
                $"Заголовок колонки {dbField}");

            tableHeader.Click();
        }

        // можно еще сделать чтобы она пробегалась по страницам (???)
        /// <summary>
        /// Проверяет наличие записи с переданными данными в таблице
        /// </summary>
        /// <param name="record">Список значений в строке таблицы</param>
        /// <returns></returns>
        public bool IsDataCorrect(List<string> record)
        {
            var gridRows = new WebItem(
                "//tr[@class='main-grid-row main-grid-row-body']",
                "Записи в гриде");

            var gridCols = new WebItem(
                    $"//thead[@class='main-grid-header']//th[@class='main-grid-cell-head main-grid-cell-left main-grid-col-sortable main-grid-draggable ']",
                    "Колонки");

            int numOfRows = gridRows.XPathLocators.Count();
            int numOfCols = gridCols.XPathLocators.Count();

            for (int i = 1;  i <= numOfRows; i++)
            {
                string xpath = $"(//tr[@class='main-grid-row main-grid-row-body'])[{i}]";
                bool flag = true;
                
                for (int j = 1; j <= numOfCols; j++)
                {
                    var cell = new WebItem(
                    $"({xpath}/td[@class='main-grid-cell main-grid-cell-left'])[{j}]//span",
                    "Запись в ячейке");
                    if (cell.InnerText() == record[j])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                    return true;
            }

            return false;
        }
    }
}
