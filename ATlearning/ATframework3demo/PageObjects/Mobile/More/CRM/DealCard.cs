using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.Mobile.More.CRM
{
    public class DealCard
    {
        public bool CheckDealName(string dealName)
        {
            var taskTitle = new MobileItem($"//android.widget.TextView[@content-desc=\"{dealName}\"]",
                $"Заголовок сделки с текстом {dealName}");

            bool isDealPresent = Waiters.WaitForCondition(() => taskTitle.WaitElementDisplayed(), 2, 6,
                $"Ожидание появления сделки '{dealName}' в списке задач");
            return isDealPresent;
        }
    }
}
