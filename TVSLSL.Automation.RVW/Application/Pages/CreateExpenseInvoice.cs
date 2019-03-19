namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using System;
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

        public Link EditExpenseInvoice { get; private set; }

        public Button PopupClose { get; private set; }

        public InputBox SupplierCode { get; private set; }

        public InputBox SupplierAddressID { get; private set; }

        public InputBox SupplierInvoiceAmount { get; private set; }

        public InputBox SupplierInvoiceNumber { get; private set; }

        public Link TaxCalculationSummary { get; private set; }

        public CreateExpenseInvoiceTableRow GetItemRow(int index)
        {
            return new CreateExpenseInvoiceTableRow(index);
        }        

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            CreateInvoice = new Button("Create Invoice", By.Id("ext-gen139"), name, iframe);
            EditExpenseInvoice = new Link("Edit Expense Invoice", By.Id("span_sdinaddexpmodlnk1"), name, iframe);
            PopupClose = new Button("Popup Close", By.XPath("//button[text()='Close']"), name);
            SupplierCode = new InputBox("Supplier Code", By.Id("cilbosupplier"), name, iframe);
            SupplierAddressID = new InputBox("Supplier Address ID", By.Id("cmbsupplieraddressid"), name, iframe);
            SupplierInvoiceAmount = new InputBox("Supplier Invoice Amount", By.Id("cilbosupinvamt"), name, iframe);
            SupplierInvoiceNumber = new InputBox("Supplier Invoice Number", By.Id("cilbosupinvno"), name, iframe);
            TaxCalculationSummary = new Link("Tax Calculation Summary", By.Id("span_g1sdinaddexptxlnk1"), name, iframe);
        }
    }
}
