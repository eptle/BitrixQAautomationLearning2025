using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.BaseFramework;
using ATframework3demo.BaseFramework.BitrixCPinterraction;
using ATframework3demo.PageObjects.SkillMap;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;

namespace ATframework3demo.TestCases.Skillmap
{
    public class Case_Bitrix24_SkillmapMainPage : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Прокликать гриды (след, пред, выкл)", homePage => testGrid(homePage)));
            caseCollection.Add(new TestCase("Открыть 'аттестовать сотрудника'", homePage => testBurger(homePage)));
            return caseCollection;
        }

        void testGrid(PortalHomePage homePage)
        {
            SkillmapMainPage SkillmapMain = homePage
                .GoToSkillmap();                     // перейти во вкладу skillmap по uri

            SkillmapMain.NextPage();
            SkillmapMain.PreviousPage();
            SkillmapMain.TogglePagination();
            Waiters.StaticWait_s(5);
        }

        void testBurger(PortalHomePage homePage)
        {
            homePage
                .GoToSkillmap()                                 // перейти во вкладу skillmap по uri
                .ClickOnBurger("Project Manager")   // тыкнуть на бургер напротив Project Manager и выбрать "Аттестовать сотрудника"
                .CertificateEmployee();
        }
    }
}
