namespace TVSLSL.Automation.RVW.Tests
{
    using Common;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.RVW.Application;

    public class CreateExpenseInvoiceTests : RVWTests
    {        

        [Test]
        [Category("UserGroup")]
        [Order(1)]

        public void CreateExpenseInvoice()
        {
            //Test to verify that user can create expense invoice

            int randomNumber = GetRandomNumber(9999, 99999);
            string supplierInvoiveNumber = string.Concat("PDLK", randomNumber);

            RVWWebApp.Login.SignIntoAccountWIthTestUser();
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.HeaderSearchBox.InputTextKeyByKey("Create Expense Invoice");
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.FirstHeaderSearchSuggestionOption.Click();
            WaitSeconds(5);

            RVWWebApp.CreateExpenseInvoice.SupplierCode.InputText("PANEXOKH88", true);
            RVWWebApp.CreateExpenseInvoice.SupplierInvoiceNumber.InputTextKeyByKey(supplierInvoiveNumber);
            RVWWebApp.CreateExpenseInvoice.SupplierInvoiceNumber.InputText(Keys.Enter);
            RVWWebApp.CreateExpenseInvoice.SupplierInvoiceAmount.InputText("11800", true);            
            RVWWebApp.CreateExpenseInvoice.SupplierAddressID.ClearText();
            RVWWebApp.CreateExpenseInvoice.SupplierAddressID.InputText("LUDHA7", true);

            RVWWebApp.CreateExpenseInvoice.GetItemRow(1).UsageID.Click();
            RVWWebApp.CreateExpenseInvoice.GetItemRow(1).UsageID.InputTextByCoordinates("SMDAYLOGDC");
            RVWWebApp.CreateExpenseInvoice.GetItemRow(1).UsageID.InputTextByCoordinates(Keys.Enter);
            RVWWebApp.CreateExpenseInvoice.GetItemRow(1).Amount.Click();
            RVWWebApp.CreateExpenseInvoice.GetItemRow(1).Amount.InputTextByCoordinates("10000");
            RVWWebApp.CreateExpenseInvoice.GetItemRow(1).Remarks.Click();
            RVWWebApp.CreateExpenseInvoice.GetItemRow(1).Remarks.InputTextByCoordinates("DEC18-Towards Courier Service");
            RVWWebApp.CreateExpenseInvoice.GetItemRow(1).CostCenter.Click();
            RVWWebApp.CreateExpenseInvoice.GetItemRow(1).CostCenter.InputTextByCoordinates("NCRSDLPB12");
            RVWWebApp.CreateExpenseInvoice.GetItemRow(1).CostCenter.InputTextByCoordinates(Keys.Enter);
            RVWWebApp.CreateExpenseInvoice.GetItemRow(1).AnalysisCode.Click();
            RVWWebApp.CreateExpenseInvoice.GetItemRow(1).AnalysisCode.InputTextByCoordinates("FEB18");
            RVWWebApp.CreateExpenseInvoice.GetItemRow(1).AnalysisCode.InputTextByCoordinates(Keys.Enter);

            RVWWebApp.CreateExpenseInvoice.CreateInvoice.Click();
            WaitSeconds(50);
            RVWWebApp.CreateExpenseInvoice.PopupClose.Click();

            RVWWebApp.CreateExpenseInvoice.TaxCalculationSummary.Click();
            WaitSeconds(5);

            RVWWebApp.ExpenseInvoiceTaxCalculationSummary.RecomputeTax.Click();
            RVWWebApp.ExpenseInvoiceTaxCalculationSummary.SaveDetails.Click();
            WaitSeconds(20);
            RVWWebApp.ExpenseInvoiceTaxCalculationSummary.PopupClose.Click();
            RVWWebApp.ExpenseInvoiceTaxCalculationSummary.GoBack.Click();
            WaitSeconds(5);

            RVWWebApp.CreateExpenseInvoice.EditExpenseInvoice.Click();
            WaitSeconds(5);

            RVWWebApp.EditExpenseInvoice.EditAndAuthorizeInvoice.Click();
        }

        private int GetRandomNumber(int minimum, int maximum)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            return random.Next(minimum, maximum);
        }
    }
}
