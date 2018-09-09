namespace TVSLSL.Automation.RVW.Tests
{
    using Common;
    using NUnit.Framework;
    using TVSLSL.Automation.Common.Tests.Utilities;
    using TVSLSL.Automation.RVW.Application;

    public class ApplyLeaveTests : RVWTests
    {
        [Test]

        public void ApplyOD()
        {
            //Test to verify that user can apply OD leave

            RVWWebApp.Login.SignIntoAccountWithLiveAccount();
            WaitSeconds(10);
            
            RVWWebApp.SelfServiceHome.MyLeave.ManageLeave.Click();

            RVWWebApp.ManageRequest.ManageRequestQuickLinks.NewRequest.Click();

            RVWWebApp.ApplyLeave.LeaveType.ClearText();
            RVWWebApp.ApplyLeave.LeaveType.InputText("ON DUTY");
            RVWWebApp.ApplyLeave.StartDate.InputText(TestHelper.GetTodaysDate("dd//MM/yyyy"));
            RVWWebApp.ApplyLeave.StartTime.InputText("09:00:00");
            RVWWebApp.ApplyLeave.EndDate.InputText(TestHelper.GetTodaysDate("dd//MM/yyyy"));
            RVWWebApp.ApplyLeave.EndTime.InputText("17:30:00");
            RVWWebApp.ApplyLeave.Reason.InputText("OTHERS");
            RVWWebApp.ApplyLeave.AdditionalReason.InputText("Addintional Information");
            //RVWWebApp.ApplyLeave.SubmitRequest.Click();
        }

        [Test]

        public void ApplySickLeave()
        {
            //Test to verify that user can apply sick leave

            RVWWebApp.Login.SignIntoAccountWithLiveAccount();
            WaitSeconds(10);

            RVWWebApp.SelfServiceHome.MyLeave.ManageLeave.Click();

            RVWWebApp.ManageRequest.ManageRequestQuickLinks.NewRequest.Click();

            RVWWebApp.ApplyLeave.LeaveType.ClearText();
            RVWWebApp.ApplyLeave.LeaveType.InputText("Sick Leave");
            RVWWebApp.ApplyLeave.StartDate.InputText(TestHelper.GetTodaysDate("dd//MM/yyyy"));
            RVWWebApp.ApplyLeave.StartTime.InputText("09:00:00");
            RVWWebApp.ApplyLeave.EndDate.InputText(TestHelper.GetTodaysDate("dd//MM/yyyy"));
            RVWWebApp.ApplyLeave.EndTime.InputText("17:30:00");
            RVWWebApp.ApplyLeave.Reason.InputText("OTHERS");
            RVWWebApp.ApplyLeave.AdditionalReason.InputText("Addintional Information");
            //RVWWebApp.ApplyLeave.SubmitRequest.Click();
        }

        [Test]

        public void ApplyCasualLeave()
        {
            //Test to verify that user can apply casual leave

            RVWWebApp.Login.SignIntoAccountWithLiveAccount();
            WaitSeconds(10);

            RVWWebApp.SelfServiceHome.MyLeave.ManageLeave.Click();

            RVWWebApp.ManageRequest.ManageRequestQuickLinks.NewRequest.Click();

            RVWWebApp.ApplyLeave.LeaveType.ClearText();
            RVWWebApp.ApplyLeave.LeaveType.InputText("Casual Leave");
            RVWWebApp.ApplyLeave.StartDate.InputText(TestHelper.GetTodaysDate("dd//MM/yyyy"));
            RVWWebApp.ApplyLeave.StartTime.InputText("09:00:00");
            RVWWebApp.ApplyLeave.EndDate.InputText(TestHelper.GetTodaysDate("dd//MM/yyyy"));
            RVWWebApp.ApplyLeave.EndTime.InputText("17:30:00");
            RVWWebApp.ApplyLeave.Reason.InputText("OTHERS");
            RVWWebApp.ApplyLeave.AdditionalReason.InputText("Addintional Information");
            //RVWWebApp.ApplyLeave.SubmitRequest.Click();
        }

        [Test]

        public void ApplyPrivilegeLeave()
        {
            //Test to verify that user can apply privilege leave

            RVWWebApp.Login.SignIntoAccountWithLiveAccount();
            WaitSeconds(10);

            RVWWebApp.SelfServiceHome.MyLeave.ManageLeave.Click();

            RVWWebApp.ManageRequest.ManageRequestQuickLinks.NewRequest.Click();

            RVWWebApp.ApplyLeave.LeaveType.ClearText();
            RVWWebApp.ApplyLeave.LeaveType.InputText("Privilege Leave");
            RVWWebApp.ApplyLeave.StartDate.InputText(TestHelper.GetTodaysDate("dd//MM/yyyy"));
            RVWWebApp.ApplyLeave.StartTime.InputText("09:00:00");
            RVWWebApp.ApplyLeave.EndDate.InputText(TestHelper.GetTodaysDate("dd//MM/yyyy"));
            RVWWebApp.ApplyLeave.EndTime.InputText("17:30:00");
            RVWWebApp.ApplyLeave.Reason.InputText("OTHERS");
            RVWWebApp.ApplyLeave.AdditionalReason.InputText("Addintional Information");
            //RVWWebApp.ApplyLeave.SubmitRequest.Click();
        }
    }
}
