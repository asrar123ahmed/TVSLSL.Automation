namespace TVSLSL.Automation.ERP.Tests.Data.Accounts
{
    public class Account
    {
        public Account(string password, string userName)
        {
            Password = password;
            UserName = userName;
        }

        public string Password { get; private set; }

        public string UserName { get; private set; }
    }
    
}
