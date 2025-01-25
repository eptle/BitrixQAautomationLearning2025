using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects.Mobile
{
    public class MobileTasksListPage
    {
        public MobileTasksListPage CreateTask(Bitrix24Task task)
        {
            var createNewTaskBtn = new MobileItem("//android.view.ViewGroup[@content-desc=\"task-list_ADD_BTN\"]",
                "Кнопка добавления новой задачи");
            createNewTaskBtn.Click();

            var taskNameField = new MobileItem("//android.view.ViewGroup[@content-desc=\"title_FIELD\"]//android.widget.EditText",
                "Поле названия задачи");
            var createBtn = new MobileItem("//android.view.ViewGroup[@content-desc=\"taskCreateToolbar_createButton\"]",
                "Кнопка подтверждения создания задачи");
            taskNameField.SendKeys(task.Title);
            createBtn.Click();

            return this;
        }

        public bool IsTaskPresent(Bitrix24Task task)
        {
            var taskTitle = new MobileItem($"//android.widget.TextView[@content-desc=\"task-list_SECTION_TITLE\" and @text=\"{task.Title}\"]",
                $"Заголовок задачи с текстом {task.Title}");

            bool isTaskPresent = Waiters.WaitForCondition(() => taskTitle.WaitElementDisplayed(), 2, 6,
                $"Ожидание появления задачи '{task.Title}' в списке задач");
            return isTaskPresent;
        }
    }
}
