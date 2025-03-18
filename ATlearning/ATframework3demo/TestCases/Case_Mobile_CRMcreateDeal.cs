using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.Mobile;
using atFrameWork2.BaseFramework.LogTools;
using ATframework3demo.BaseFramework;

namespace ATframework3demo.TestCases
{
    public class Case_Mobile_Tasks2 : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(
                new TestCase("Создания сделки в CRM, к которой будет привязан контакт", mobileHomePage => CreateDealCRM(mobileHomePage)));
            return caseCollection;
        }

        void CreateDealCRM(MobileHomePage homePage)
        {
            string dealName = "deal_" + HelperMethods.GetDateTimeSaltString();
            
            var CRMpage = homePage
                .TabsPanel
                .SelectMore()   // выбрать "еще" снизу
                .openCRM();     // открыть CRM в меню

            var dealPage = CRMpage
                .ClickPlusBtn()         // нажать на плюсик снизу справа
                .SelectDeal()           // выбрать сделку в меню
                .EnterTitle(dealName)   // ввести название сделки
                .AddFirstContact()      // добавить контакт в сделку
                .SetSum(100)            // установить сумму сделки
                .CreateDeal();          // создать сделку
            
            // проверка того, что сделка создалась
            bool isDealCorrect = dealPage.CheckDealName(dealName);

            if (!isDealCorrect)
            {
                Log.Error($"Созданная сделка с названием {dealName} не отображается");
            }
        }
    }
}
