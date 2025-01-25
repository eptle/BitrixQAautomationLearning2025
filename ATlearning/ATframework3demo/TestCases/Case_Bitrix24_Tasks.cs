using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework.BitrixCPinterraction;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace atFrameWork2.TestCases
{
    public class Case_Bitrix24_Tasks : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            return new List<TestCase>
            {
                new TestCase("Создание задачи", homePage => CreateTask(homePage)),
                new TestCase("Редактирование задачи", (PortalHomePage homePage) => throw new NotImplementedException("Заглушка теста редактирования задачи")),
                new TestCase("Удаление задачи", (PortalHomePage homePage) => { Thread.Sleep(5000); Log.Error("kukus"); }),
            };
        }

        public static void CreateTask(PortalHomePage homePage)
        {
            //пример использования апишки c инвайтом юзеров и использованием второго драйвера
            var intranetUser = TestCase.RunningTestCase.CreatePortalTestUser(false);
            var extranetUser = TestCase.RunningTestCase.CreatePortalTestUser(true);
            foreach (var user in new[] { intranetUser, extranetUser })
            {
                var driver2 = WebDriverActions.GetNewDriver();
                var homePage2 = new PortalLoginPage(TestCase.RunningTestCase.TestPortal, driver2).Login(user);
                homePage2.LeftMenu.OpenTasks();
            }

            //пример кода кейса здорового человека:
            homePage
                .LeftMenu
                .OpenTasks();

            //пример кода кейса курильщика:
            var btnAddTask = new WebItem("//a[@id='tasks-buttonAdd']", "Кнопка добавления задачи");
            btnAddTask.Click();
            //свичнуться в слайдер
            var sliderFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм слайдера");
            sliderFrame.SwitchToFrame();
            //ввести тайтл и описание
            var inputTaskTitle = new WebItem("//input[@data-bx-id='task-edit-title']", "Текстбокс названия задачи");
            var task = new Bitrix24Task("testTasks" + DateTime.Now.Ticks) { Description = "Какой то дескрипгш" + +DateTime.Now.Ticks };
            inputTaskTitle.SendKeys(task.Title);
            var editorFrame = new WebItem("//iframe[@class='bx-editor-iframe']", "Фрейм редактора текста");
            editorFrame.SwitchToFrame();
            var body = new WebItem("//body", "Это просто бади какой то");
            body.SendKeys(task.Description);
            WebDriverActions.SwitchToDefaultContent();
            sliderFrame.SwitchToFrame();
            //сохранить 
            var btnSaveTask = new WebItem("//button[@data-bx-id='task-edit-submit' and @class='ui-btn ui-btn-success']", "Кнопка сохранения задачи");
            btnSaveTask.Click();
            WebDriverActions.SwitchToDefaultContent();
            var gridTaskLink = new WebItem($"//a[contains(text(), '{task.Title}') and contains(@class, 'task-title')]",
                $"Ссылка на задачу '{task.Title}' в гриде");
            gridTaskLink.WaitElementDisplayed();
            gridTaskLink.Click();
            sliderFrame.SwitchToFrame();
            //открыть задачу, ассертнуть тайтл и дескрипшн
            var taskTitleArea = new WebItem($"//div[@class='tasks-iframe-header']//span[@id='pagetitle']",
                "Область заголовка задачи");
            taskTitleArea.WaitElementDisplayed(10);
            taskTitleArea.AssertTextContains(task.Title, "Название задачи отображается неверно");
            var taskDescriptionArea = new WebItem($"//div[@id='task-detail-description']",
                "Область описания задачи");
            taskDescriptionArea.AssertTextContains(task.Description, "Название задачи отображается неверно");
        }
    }
}
