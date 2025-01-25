using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_Settings : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Настрйка адресации всем по умолчанию", homePage => SendToAllByDefault(homePage)));
            return caseCollection;
        }

        void SendToAllByDefault(PortalHomePage homePage)
        {
            string assertPhrase = "Всем сотрудникам";
            //Подготовка к кейсу, если галочка снята, то надо её установить обратно
            if (new NewsPage().AddPost().IsRecipientPresent(assertPhrase) == false)
            {
                homePage
                    .LeftMenu
                    .OpenSettings()
                    .EnableDefaultSendToAll()
                    .Save();

                bool isAllRecipientsDisplayed2 = homePage
                    .LeftMenu
                    .OpenNews()
                    .AddPost()
                    .IsRecipientPresent(assertPhrase);

                if (!isAllRecipientsDisplayed2)
                {
                    Log.Error("Не Отображается 'Всем сотрудникам' в получателях поста," +
                        " но при этом галочка в настройках установлена");
                }
            }

            //перейти в настройки
            //снять галочку адресовать всем по умолчанию
            //сохранить настройки
            //пойти в ленту
            //начать создавать пост и проверить что получатель ВСЕ пропал
            homePage
                .LeftMenu
                .OpenSettings()
                .DisableDefaultSendToAll()
                .Save();

            bool isAllRecipientsDisplayed = homePage
                .LeftMenu
                .OpenNews()
                .AddPost()
                .IsRecipientPresent(assertPhrase);

            if (isAllRecipientsDisplayed)
            {
                Log.Error("Отображается 'Всем сотрудникам' в получателях поста," +
                    " но не должно, потому что галочка в настройках снята");
            }
        }
    }
}
