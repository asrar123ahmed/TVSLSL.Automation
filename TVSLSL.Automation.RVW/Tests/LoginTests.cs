namespace TVSLSL.Automation.RVW.Tests
{
    using Common;
    using NUnit.Framework;
    using TVSLSL.Automation.RVW.Application;

    public class LoginTests : RVWTests
    {
        [Test]
        public void LoginTest()
        {
            //Test to verify user able to login successfully

            WaitSeconds(30);
            RVWWebApp.Login.UserID.ClearText();
            RVWWebApp.Login.SignIntoAccountWIthTestUser();
            //add assertion here 
            WaitSeconds(30);
        }
    }
}
