namespace TVSLSL.Automation.RVW.Tests
{
    using Common;
    using NUnit.Framework;
    using TVSLSL.Automation.RVW.Application;

    public class ManageRequestTest : RVWTests
    {
        [Test]

        public void ClickNewrequestLink()
        {
            //Test to verify that user able to click the new request link

            RVWWebApp.Login.SignIntoAccountWithLiveAccount();
            WaitSeconds(10);

            RVWWebApp.SelfServiceHome.MyLeave.ManageLeave.Click();
            RVWWebApp.ManageRequest.ManageRequestQuickLinks.NewRequest.Click();
        }
    }
}
