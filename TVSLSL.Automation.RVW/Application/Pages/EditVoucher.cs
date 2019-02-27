namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    public class EditVoucher : Page
    {
        private string iframe;        

        public EditVoucher()
        {
            InitialisePage();
        }       

        public Button EditAndAuthorizeVoucher { get; private set; }

        public Button EditVoucherBtn { get; private set; }

        public Button EditPopupClose { get; private set; }

        public Label VoucherAuthorizedMessage { get; private set; }

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";            

            EditAndAuthorizeVoucher = new Button("Edit And Authorize Voucher", By.Id("ext-gen97"), name, iframe);
            EditVoucherBtn = new Button("Edit Voucher", By.Id("ext-gen90"), name, iframe);
            EditPopupClose = new Button("Save Popup Close", By.XPath("//em/button[contains(.,'Close')]"), name);
            VoucherAuthorizedMessage = new Label("VoucherAuthorizeMessage", By.XPath("//td[@id='msgRoot']"), name);
        }
    }
}
