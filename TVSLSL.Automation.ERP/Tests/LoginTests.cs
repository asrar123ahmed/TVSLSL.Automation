namespace TVSLSL.Automation.ERP.Tests
{
     using Common;
    using NUnit.Framework;
    using TVSLSL.Automation.ERP.Application;

    public class LoginTests : ERPTests
    {
        [Test]
        public void LoginTest()
        {
            //Test to verify user able to login successfully

            WaitSeconds(30);
            ERPWebApp.Login.SignIntoAccountWithMyAccount();
            //add assertion here 
            WaitSeconds(30);
        }
    }
}
