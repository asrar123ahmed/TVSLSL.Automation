namespace TVSLSL.Automation.RVW.Tests
{
    using Common;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Tests.Utilities;
    using TVSLSL.Automation.RVW.Application;

    public class ReportTests : RVWTests
    {
        [Test]

        public void C1MarginReportCompare()
        {
            //Test to verify that C1 margin report downloaded matches with the reports display in UI grid

            string dateFrom = TestHelper.GetTodaysDate("dd/MM/yyyy", -30);
            string dateTo = TestHelper.GetTodaysDate("dd/MM/yyyy", 1);

            RVWWebApp.Login.SignIntoAccountWIthTestUser();
            RVWWebApp.SelfServiceHome.HeaderSearchBox.InputTextKeyByKey("C1 Margin Report");
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.FirstHeaderSearchSuggestionOption.Click();
            WaitSeconds(5);

            RVWWebApp.C1MarginReport.From.InputText(dateFrom, true);
            RVWWebApp.C1MarginReport.To.InputText(dateTo, true);
            RVWWebApp.C1MarginReport.Submit.Click();
            WaitSeconds(10);

            string Records = RVWWebApp.C1MarginReport.TableRecord.GetElementText().Remove(0,6);
        }

    }
}
