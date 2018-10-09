namespace TVSLSL.Automation.ERP.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.ERP.Tests.Data.Accounts;

    public class Login : Page
    {
        private string iframe;
        public Login()
        {
            InitialisePage();
        }

        public InputBox Password { get; private set; }

        public Button SignIn { get; private set; }

        public InputBox UserName { get; private set; }

        public void SignIntoAccount(string user, string password)
        {
            UserName.InputText(user);
            Password.InputText(password);
            SignIn.Click();
        }

        public void SignIntoAccount(Account account)
        {
            SignIntoAccount(account.UserName, account.Password);
        }

        public void SignIntoAccountWithMyAccount()
        {
            SignIntoAccount(Accounts.GetAccount().UserName, Accounts.GetAccount().Password);
            WaitSeconds(4); //Wait for home page to load
        }

        private void InitialisePage()
        {
            iframe = "WEBUI";
            
            Password = new InputBox("Password", By.Id("PASSWORD"), name, iframe);
            SignIn = new Button("Sign In", By.Id("SUBMIT"), name, iframe);
            UserName = new InputBox("User Name", By.Id("USERNAME"), name, iframe);
        }
    }
}
