using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Mobile.More;

namespace ATframework3demo.PageObjects.Mobile
{
    /// <summary>
    /// Главная панель приложения
    /// </summary>
    public class MobileMainPanel
    {
        public MobileTasksListPage SelectTasks()
        {
            var tasksTab = new MobileItem("//android.widget.TextView[@resource-id=\"com.bitrix24.android:id/bb_bottom_bar_title\" and @text=\"Tasks\"]",
                "Таб 'Задачи'");
            tasksTab.Click();

            return new MobileTasksListPage();
        }

        public MobileMoreListPage SelectMore()
        {
            Waiters.StaticWait_s(10);
            var tasksTab = new MobileItem("//android.widget.FrameLayout[@content-desc=\"bottombar_tab_more\"]/android.widget.LinearLayout/android.widget.ImageView",
                "Таб 'Еще'");
            tasksTab.Click();
            tasksTab.Click();

            return new MobileMoreListPage();
        }
    }
}