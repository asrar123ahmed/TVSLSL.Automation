namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class CreateExpenseInvoice : Page
    {
        private string iframe;        

        public CreateExpenseInvoice()
        {
            InitialisePage();
        }

        public Button CreateInvoice { get; private set; }

        public InputBox SupplierCode { get; private set; }

        public InputBox SupplierAddressID { get; private set; }       

        public InputBox SupplierInvoiceNumber { get; private set; }

        public InputBox SupplierInvoiceAmount { get; private set; }

        public CreateVoucherTableRow GetItemRow(int index)
        {
            return new CreateVoucherTableRow(index);
        }      

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            CreateInvoice = new Button("Create Invoice", By.Id("ext-gen139"), name, iframe);
            SupplierCode = new InputBox("Supplier Code", By.Id("cilbosupplier"), name, iframe);
            SupplierAddressID = new InputBox("Supplier Address ID", By.Id("cmbsupplieraddressid"), name);
            SupplierInvoiceNumber = new InputBox("Supplier Invoice Number", By.Id("cilbosupinvno"), name, iframe);
            SupplierInvoiceAmount = new InputBox("Supplier Invoice Amount", By.Id("cilbosupinvamt"), name, iframe);
            
            
        }
    }
}
