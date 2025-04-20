using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using ATframework3demo.BaseFramework.BitrixCPinterraction;
using ATframework3demo.PageObjects.SkillMap;

namespace ATframework3demo.TestCases.Skillmap
{
    public class Case_Bitrix24_SkillmapMainPage : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создать 25 специалистов", homePage => query(homePage)));
            caseCollection.Add(new TestCase("Прокликать гриды (след, пред, выкл)", homePage => testGrid(homePage)));
            caseCollection.Add(new TestCase("Открыть 'аттестовать сотрудника'", homePage => testBurger(homePage)));
            return caseCollection;
        }
        void query(PortalHomePage homePage)
        {
            var testPortal = TestCase.RunningTestCase.TestPortal;
            string query = File.ReadAllText(@"../../../TestEntities/queries/clear_db_and_create_25_specialists.sql");
            TestCase.RunningTestCase.ExecutePHP("global $DB;\r\n" +
                $"$res = $DB->Query(\"{query}\");" +
            @"$rows = [];
            while ($row = $res->Fetch()) 
	            $rows[] = $row;
            echo json_encode($rows);");

            homePage
                .GoToSkillmap();
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
                .ChooseActionToProfile("Project Manager", 3);   // тыкнуть на бургер напротив Project Manager и выбрать "Аттестовать сотрудника"
        }
    }
}
