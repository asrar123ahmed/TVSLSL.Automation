namespace TVSLSL.Automation.RVW.Tests
{
    using Common;
    using NUnit.Framework; 
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
        }
    }
}
