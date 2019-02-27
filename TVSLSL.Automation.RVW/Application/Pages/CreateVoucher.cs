namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class CreateVoucher : Page
    {
        private string iframe;        

        public CreateVoucher()
        {
            InitialisePage();
        }

        public InputBox BankCashCode { get; private set; }

        public Button CreateVoucherBtn { get; private set; }

        public Button CreateVoucherPopupClose { get; private set; }

        public Link EditVoucher { get; private set; }

        public InputBox PayAmount { get; private set; }

        public InputBox PayMode { get; private set; }

        public InputBox Payee { get; private set; } 

        public CreateVoucherTableRow GetItemRow(int index)
        {
            return new CreateVoucherTableRow(index);
        }      

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            BankCashCode = new InputBox("Bank Cash Code", By.Id("cilbobankcash"), name, iframe);
            CreateVoucherBtn = new Button("Create Voucher", By.Id("ext-gen90"), name, iframe);
            CreateVoucherPopupClose = new Button("Create Voucher Popup Close", By.XPath("//button[text()='Close']"), name);
            EditVoucher = new Link("Edit Voucher", By.Id("span_snpaddmainlnk2"), name, iframe);
            PayAmount = new InputBox("Pay Amount", By.Id("cilbopayamount"), name, iframe);
            PayMode = new InputBox("Pay Mode", By.Id("cilbopaymode"), name, iframe);
            Payee = new InputBox("Payee", By.Id("cilbopayee"), name, iframe);
            
        }
    }
}
