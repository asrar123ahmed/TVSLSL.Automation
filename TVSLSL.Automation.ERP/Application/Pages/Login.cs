namespace TVSLSL.Automation.ERP.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.ERP.Tests.Data.Accounts;

    public class Login : Page
    {
        public Login()
        {
            InitialisePage();
        }

        public InputBox Password { get; private set; }

        public Button Submit { get; private set; }

        public InputBox UserName { get; private set; }

        public void SignIntoAccount(string user, string password)
        {
            UserName.InputText(user);
            Password.InputText(password);
            Submit.Click();
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
            Password = new InputBox("Password", By.Id("PASSWORD"), name);
            Submit = new Button("Sign In", By.Id("SUBMIT"), name);
            UserName = new InputBox("User Name", By.Id("USERNAME"), name);

        }
    }
}
