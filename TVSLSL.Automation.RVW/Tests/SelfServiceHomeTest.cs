namespace TVSLSL.Automation.RVW.Tests
{
    using Common;
    using NUnit.Framework;
    using TVSLSL.Automation.RVW.Application;

    public class SelfServiceHomeTest : RVWTests
    {
        [Test]

        public void AccessApplyLeaveOnMyLeave()
        {
            //Test to verify that user able to access the apply leave link in My Apply section

            RVWWebApp.Login.SignIntoAccountWithLiveAccount();
            WaitSeconds(10);

            RVWWebApp.SelfServiceHome.MyLeave.ManageLeave.Click();
        }

        [Test]

        public void HomeTickerDownClick()
        {
            //Test to verify that user able to click the homw ticker down

            RVWWebApp.Login.SignIntoAccountWithLiveAccount();
            WaitSeconds(10);

            RVWWebApp.SelfServiceHome.HomeTickerDown.Click();
            RVWWebApp.SelfServiceHome.TopPanelToggle.AssertElementHasAttribute("ext-gen565");
        }


    }
}
