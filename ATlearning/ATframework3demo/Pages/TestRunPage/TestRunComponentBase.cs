using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace ATframework3demo.Pages.TestRunPage
{
    public class TestRunComponentBase : ComponentBase
    {
        const string configFileName = "settings.txt";
        CaseCollectionGenerator caseColBuilder = new CaseCollectionGenerator();

        protected bool RunButtonDisabled { get; set; }
        protected List<TestCase> CaseCollection { get; set; }
        protected string PortalUri { get; set; }
        protected string PortalUriBgColor { get; set; }
        protected string LoginBgColor { get; set; }
        protected string DisplayedError { get; set; }
        protected string PwdBgColor { get; set; }
        protected User PortalUser { get; set; } = new User();
        [CascadingParameter] public IModalService Modal { get; set; }

        protected void ShowLog(TestCase testCase)
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(LogViewComponent.TestCase), testCase);
            Modal.Show<LogViewComponent>($"Лог кейса '{testCase.Title}'", parameters);
        }

        protected void OnInputClick()
        {
            PortalUriBgColor = HelperMethods.GetHexColor(Color.White);
            LoginBgColor = HelperMethods.GetHexColor(Color.White);
            PwdBgColor = HelperMethods.GetHexColor(Color.White);
            DisplayedError = null;
        }

        protected async void RunSelectedTests()
        {
            RunButtonDisabled = true;
            Uri portalUri = default;

            if (string.IsNullOrEmpty(PortalUri) || !Uri.TryCreate(PortalUri, UriKind.Absolute, out portalUri))
                PortalUriBgColor = HelperMethods.GetHexColor(Color.Red);
            else if (string.IsNullOrEmpty(PortalUser.LoginAkaEmail) || !IsEmail(PortalUser.LoginAkaEmail))
            {
                LoginBgColor = HelperMethods.GetHexColor(Color.Red);
                if (!IsEmail(PortalUser.LoginAkaEmail))
                    DisplayedError = "Логин должен быть email-ом";
            }
            else if (string.IsNullOrEmpty(PortalUser.Password))
                PwdBgColor = HelperMethods.GetHexColor(Color.Red);
            else
            {
                File.WriteAllText(configFileName, $"{PortalUri}\r\n{PortalUser.LoginAkaEmail}\r\n{PortalUser.Password}");
                var selectedCases = CaseCollection.FindAll(x => x.Node.IsChecked);

                if (selectedCases.Any())
                {
                    selectedCases.ForEach(x => x.Status = TestCaseStatus.waitingForExecute);
                    var portalInfo = new PortalInfo(portalUri, PortalUser);

                    foreach (var testCase in selectedCases)
                    {
                        await Task.Run(() =>
                        {
                            testCase.Execute(portalInfo, () => InvokeAsync(StateHasChanged));
                        });
                    }

                    return;
                }
            }

            RunButtonDisabled = false;
            StateHasChanged();
        }

        private bool IsEmail(string email)
        {
            return email?.Contains("@") == true && email?.Contains(".") == true;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            CaseCollection = caseColBuilder.FrameworkCaseCollection;
            OnInputClick();
            
            if(File.Exists(configFileName))
            {
                string configContent = File.ReadAllText(configFileName);
                
                if (!string.IsNullOrEmpty(configContent))
                {
                    var parts = configContent.Split("\r\n", StringSplitOptions.None);
                    
                    if(parts.Count() > 2)
                    {
                        PortalUri = parts[0];
                        PortalUser.LoginAkaEmail = parts[1];
                        PortalUser.Password = parts[2];
                    }
                }
            }
        }
    }
}
