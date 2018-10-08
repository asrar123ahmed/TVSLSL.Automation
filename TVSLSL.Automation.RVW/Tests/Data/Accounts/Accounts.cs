namespace TVSLSL.Automation.RVW.Tests.Data.Accounts
{
    public class Accounts
    {
        private static Account Account;
        private static Account TestAccount;

        static Accounts()
        {
            Account = new Account("smita@20186", "049985");
            TestAccount = new Account("PASS12*", "tvsuser");

        }

        public static Account GetAccount()
        {
            return Account;
        }

        public static Account GetTestAccount()
        {
            return TestAccount;
        }
    }
}
