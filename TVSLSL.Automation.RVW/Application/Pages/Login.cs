namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.RVW.Tests.Data.Accounts;

    public class Login : Page
    {
        private string iframe;

        public Login()
        {
            InitialisePage();
        }

        public InputBox Password { get; private set; }

        public Button SignIn { get; private set; }

        public InputBox UserID { get; private set; }

        public DropDown UserType { get; private set; }

        public void SignIntoAccount(string user, string password)
        {
            UserID.InputText(user);
            Password.InputText(password);
            UserType.SelectDropDownOptionByText("Default");
            WaitSeconds(3);
            SignIn.Click();
        }
                
        public void SignIntoAccount(Account account)
        {
            SignIntoAccount(account.UserName, account.Password);
        }

        public void SignIntoAccountWithLiveAccount()
        {
            SignIntoAccount(Accounts.GetAccount().UserName, Accounts.GetAccount().Password);
            WaitSeconds(4); //Wait for home page to load
        }

        public void SignIntoAccountWIthTestUser()
        {
            SignIntoAccount(Accounts.GetTestAccount().UserName, Accounts.GetTestAccount().Password);
            WaitSeconds(4); //Wait for home page to load
        }

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            Password = new InputBox("Password", By.Id("ide_password"), name, iframe);          
            SignIn = new Button("Sign In", By.XPath("//div[@onclick='login()']"), name, iframe);
            UserID = new InputBox("User ID", By.Id("ide_username"), name, iframe);
            UserType = new DropDown("User Type", By.Id("ldapauthBox"), name, iframe);
        }
    }
}
