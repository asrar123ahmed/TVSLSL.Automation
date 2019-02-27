namespace TVSLSL.Automation.RVW.Tests
{
    using Common;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.RVW.Application;

    public class CreateSundryPaymentTests : RVWTests
    {        

        [Test]
        [Category("UserGroup")]
        [Order(1)]

        public void CreateVoucher()
        {
            //Test to verify that user can create vouchers
            RVWWebApp.Login.SignIntoAccountWIthTestUser();
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.HeaderSearchBox.InputTextKeyByKey("Create Voucher");
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.FirstHeaderSearchSuggestionOption.Click();
            WaitSeconds(5);

            RVWWebApp.CreateVoucher.Payee.InputText("Govt Of India - ESI", true);
            RVWWebApp.CreateVoucher.BankCashCode.ClearText();
            RVWWebApp.CreateVoucher.BankCashCode.InputText("HDFC-PA-11746", true);
            RVWWebApp.CreateVoucher.PayAmount.InputText("12000", true);
            RVWWebApp.CreateVoucher.PayMode.ClearText();
            RVWWebApp.CreateVoucher.PayMode.InputText("Others", true);

            RVWWebApp.CreateVoucher.GetItemRow(1).UsageId.Click();
            RVWWebApp.CreateVoucher.GetItemRow(1).UsageId.InputTextByCoordinates("ESIPYBLLSL");
            RVWWebApp.CreateVoucher.GetItemRow(1).UsageId.InputTextByCoordinates(Keys.Enter);
            RVWWebApp.CreateVoucher.GetItemRow(1).Amount.Click();
            RVWWebApp.CreateVoucher.GetItemRow(1).Amount.InputTextByCoordinates("12000");
            RVWWebApp.CreateVoucher.GetItemRow(1).Amount.InputTextByCoordinates(Keys.Enter);
            WaitSeconds(3);
            RVWWebApp.CreateVoucher.GetItemRow(1).Remarks.Click();
            RVWWebApp.CreateVoucher.GetItemRow(1).Remarks.InputTextByCoordinates("ESI for the month of Jan19-RENIGUNDA-ESI");
            RVWWebApp.CreateVoucher.GetItemRow(1).Remarks.InputTextByCoordinates(Keys.Enter);
            RVWWebApp.CreateVoucher.GetItemRow(1).AnalysisCode.Click();
            RVWWebApp.CreateVoucher.GetItemRow(1).AnalysisCode.InputTextByCoordinates("FEB18");
            RVWWebApp.CreateVoucher.GetItemRow(1).AnalysisCode.InputTextByCoordinates(Keys.Enter);

            RVWWebApp.CreateVoucher.CreateVoucherBtn.Click();
            WaitSeconds(10);
            RVWWebApp.CreateVoucher.CreateVoucherPopupClose.Click();

            RVWWebApp.CreateVoucher.EditVoucher.Click();
            RVWWebApp.EditVoucher.EditVoucherBtn.Click();
            WaitSeconds(10);            
            RVWWebApp.EditVoucher.EditPopupClose.Click();
            RVWWebApp.EditVoucher.EditAndAuthorizeVoucher.Click();
            WaitSeconds(10);

            RVWWebApp.EditVoucher.VoucherAuthorizedMessage.IsVisible();
        }
    }
}
