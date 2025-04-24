using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.BaseFramework;
using ATframework3demo.PageObjects.CRM;
using ATframework3demo.PageObjects.NewsFeed;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_Toolbar : CaseCollectionBuilder
    {

        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Открыть 'создание профиля'", homePage => openProfilesPage(homePage)));
            caseCollection.Add(new TestCase("Открыть 'skillmap'", homePage => openSkillmapMainPage(homePage)));
            caseCollection.Add(new TestCase("Открыть 'мой прогресс'", homePage => openMyProgressPage(homePage)));
            caseCollection.Add(new TestCase("Прокликать ссылки в попапе 'ИПР'", homePage => checkIPRpopup(homePage)));
            caseCollection.Add(new TestCase("Прокликать ссылки в попапе 'отчеты'", homePage => checkAnalyticsPopup(homePage)));
            return caseCollection;
        }
        void openProfilesPage(PortalHomePage homePage)
        {

            homePage
                .GoToSkillmap() // перейти во вкладу skillmap по uri
                .ClickOnAddProfileBtn();       // кликнуть на кнопку добавить 
        }

        void openSkillmapMainPage(PortalHomePage homePage)
        {
            homePage
                .GoToSkillmap()                     // перейти во вкладу skillmap по uri
                .Toolbar                            // объект тулбара
                .ClickOnSpecialistProfilesBtn();    // кликнуть на кнопку профили специалистов
        }

        void openMyProgressPage(PortalHomePage homePage)
        {
            homePage
                .GoToSkillmap()             // перейти во вкладу skillmap по uri
                .Toolbar                    // объект тулбара
                .ClickOnMyProgressBtn();    // кликнуть на кнопку мой прогресс
        }

        void checkIPRpopup(PortalHomePage homePage)
        {
            homePage
                .GoToSkillmap()             // перейти во вкладу skillmap по uri
                .Toolbar                    // объект тулбара
                .ClickOnIPRBtn()
                .CreateIPR()
                .Toolbar
                .ClickOnIPRBtn()
                .IPRlist()
                .Toolbar
                .ClickOnSpecialistProfilesBtn();
        }

        void checkAnalyticsPopup(PortalHomePage homePage)
        {
            homePage
                .GoToSkillmap()             // перейти во вкладу skillmap по uri
                .Toolbar                    // объект тулбара
                .ClickOnAnalyticsBtn()      // кликнуть на кнопку аналитика и отчеты -> все аттестации
                .AllAttestations()
                .Toolbar
                .ClickOnAnalyticsBtn()
                .CertificationRelevance()
                .Toolbar
                .ClickOnAnalyticsBtn()
                .StatByProfiles()
                .Toolbar
                .ClickOnSpecialistProfilesBtn();

        }
    }
}