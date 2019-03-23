namespace TVSLSL.Automation.RVW.Tests
{
    using Common;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Tests.Utilities;
    using TVSLSL.Automation.RVW.Application;

    public class CustomerBalanceAgeingAnalysisTests : RVWTests
    {
        [Test]
        [Category("UserGroup")]
        [Order(1)]

        public void ViewCustomerBalanceAgeing()
        {
            //Test to verify that user able to view customer balance ageing           

            RVWWebApp.Login.SignIntoAccountWIthTestUser();
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.HeaderSearchBox.InputTextKeyByKey("Customer Balance Ageing Analysis");
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.FirstHeaderSearchSuggestionOption.Click();
            WaitSeconds(5);

            RVWWebApp.CustomerBalanceAgeingAnalysis.AsOnDate.ClearText();
            RVWWebApp.CustomerBalanceAgeingAnalysis.AsOnDate.InputText("30/04/2018");
            RVWWebApp.CustomerBalanceAgeingAnalysis.CurrencyOption.ClearText();
            RVWWebApp.CustomerBalanceAgeingAnalysis.CurrencyOption.InputText("BASE");
            RVWWebApp.CustomerBalanceAgeingAnalysis.FinanceBook.ClearText();
            RVWWebApp.CustomerBalanceAgeingAnalysis.FinanceBook.InputText("LSLPFB");

            RVWWebApp.CustomerBalanceAgeingAnalysis.GetItemRow(1).BucketRange.Click();
            RVWWebApp.CustomerBalanceAgeingAnalysis.GetItemRow(1).BucketRange.InputTextByCoordinates("1");
            RVWWebApp.CustomerBalanceAgeingAnalysis.GetItemRow(1).DaysFrom.Click();
            RVWWebApp.CustomerBalanceAgeingAnalysis.GetItemRow(1).DaysFrom.InputTextByCoordinates("0");
            RVWWebApp.CustomerBalanceAgeingAnalysis.GetItemRow(1).DaysTo.Click();
            RVWWebApp.CustomerBalanceAgeingAnalysis.GetItemRow(1).DaysTo.InputTextByCoordinates("30");
            //RVWWebApp.CustomerBalanceAgeingAnalysis.GetItemRow(1).DaysFrom.Click();
            //RVWWebApp.CustomerBalanceAgeingAnalysis.GetItemRow(1).DaysFrom.InputTextByCoordinates("0");

            RVWWebApp.CustomerBalanceAgeingAnalysis.ViewCustomerBalanceAgeing.Click();
            WaitSeconds(1000);
        }        
    }
}
