using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using ATframework3demo.BaseFramework.BitrixCPinterraction;
using ATframework3demo.PageObjects.Mobile;

namespace atFrameWork2.BaseFramework
{
    public class TestCase
    {
        public static TestCase RunningTestCase { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">Название тесткейса</param>
        /// <param name="body">Ссылка на метод тела кейса</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TestCase(string title, Action<PortalHomePage> body)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Node = new TestCaseTreeNode(title);
            EnvType = TestCaseEnvType.Web;
        }

        public TestCase(string title, Action<MobileHomePage> body)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            MobileBody = body ?? throw new ArgumentNullException(nameof(body));
            Node = new TestCaseTreeNode(title);
            EnvType = TestCaseEnvType.Mobile;
        }

        int logCounter = 0;

        public void Execute(PortalInfo testPortal, Action uiRefresher)
        {
            TestPortal = testPortal;
            Status = TestCaseStatus.running;
            uiRefresher.Invoke();
            RunningTestCase = this;
            logCounter++;
            CaseLogPath = Path.Combine(Environment.CurrentDirectory, $"caselog{DateTime.Now:ddMMyyyyHHmmss}{logCounter}.html");
            Log.WriteHtmlHeader(CaseLogPath);
            uiRefresher.Invoke();

            try
            {
                Log.Info($"---------------Запуск кейса '{Title}'---------------");
                if (TestPortal.PortalUri.Scheme == Uri.UriSchemeHttps)//не особо надёжная история, но для обучалки сойдет
                    IsCloud = true;

                if (EnvType == TestCaseEnvType.Web)
                {
                    var portalLoginPage = new PortalLoginPage(TestPortal);
                    var homePage = portalLoginPage.Login(TestPortal.PortalAdmin);
                    Body.Invoke(homePage);
                }
                else
                {
                    var loginPage = new MobileLoginPage(TestPortal);
                    var homePage = loginPage.Login(TestPortal.PortalAdmin);
                    MobileBody.Invoke(homePage);
                }

            }
            catch (Exception e)
            {
                Log.Error($"Кейс не пройден, причина:{Environment.NewLine}{e}");
            }

            Log.Info($"---------------Кейс '{Title}' завершён---------------");

            try
            {
                if (BaseItem._defaultDriver != default)
                {
                    BaseItem.DefaultDriver.Quit();
                    BaseItem.DefaultDriver = default;
                }
            }
            catch (Exception) { }

            if (CaseLog.Any(x => x is LogMessageError))
                Status = TestCaseStatus.failed;
            else
                Status = TestCaseStatus.passed;

            RunningTestCase = default;
            uiRefresher.Invoke();
        }

        /// <summary>
        /// Выполняет php код в админке портала текущего кейса через "Настройки -> Командная PHP строка"
        /// </summary>
        /// <param name="phpCode"></param>
        /// <returns>Результат выполнения кода (если код в принципе что-то выводит)</returns>
        public string ExecutePHP(string phpCode)
        {
            if (IsCloud)
                throw new Exception("Выполнение php на облаке невозможно");
            var phpExecutor = new PHPcommandLineExecutor(TestPortal.PortalUri, TestPortal.PortalAdmin.LoginAkaEmail, TestPortal.PortalAdmin.Password);
            return phpExecutor.Execute(phpCode);
        }

        /// <summary>
        /// Генерирует нового сотрудника на портале
        /// </summary>
        /// <param name="extranetUser">Если задано, то создаст пользователя эксранета</param>
        /// <returns></returns>
        public User CreatePortalTestUser(bool extranetUser)
        {
            if (IsCloud)
                throw new Exception("Генерация юзеров на облаке невозможна");
            var user = EmployeeTools.GenerateBxPortalValidUserData();
            if(extranetUser)
                EmployeeTools.AddNewExtranetUser(user, TestPortal.PortalAdmin, TestPortal.PortalUri);
            else
                EmployeeTools.AddNewIntranetUser(user, TestPortal.PortalAdmin, TestPortal.PortalUri);
            return user;
        }

        public string Title { get; set; }
        Action<PortalHomePage> Body { get; set; }
        Action<MobileHomePage> MobileBody { get; set; }
        public TestCaseTreeNode Node { get; set; }
        public string CaseLogPath { get; set; }
        public List<LogMessage> CaseLog { get; } = new List<LogMessage>();
        public TestCaseStatus Status { get; set; }
        public TestCaseEnvType EnvType { get; set; }
        public bool IsCloud { get; set; }
        public PortalInfo TestPortal { get; set; }
    }

    public enum TestCaseEnvType
    {
        Web,
        Mobile
    }
}
