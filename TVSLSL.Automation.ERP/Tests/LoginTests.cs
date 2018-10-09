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

            WaitSeconds(30); // Page upload
            ERPWebApp.Login.SignIntoAccountWithMyAccount();
            //add assertion here 
            ERPWebApp.EnviromentSelection.ITGHDQ.Click();
            ERPWebApp.GeneralInformation.Menus.Click();
        }
    }
}
