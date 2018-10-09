namespace TVSLSL.Automation.ERP.Tests.Data.Accounts
{
    public class Accounts
    {
        private static Account Account;        

        static Accounts()
        {
            Account = new Account("welcome8", "AA49985");         

        }

        public static Account GetAccount()
        {
            return Account;
        }        
    }
}
