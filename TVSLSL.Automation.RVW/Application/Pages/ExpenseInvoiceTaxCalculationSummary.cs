namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class ExpenseInvoiceTaxCalculationSummary : Page
    {
        private string iframe;        

        public ExpenseInvoiceTaxCalculationSummary()
        {
            InitialisePage();
        }        

        public Button GoBack { get; private set; }

        public Button PopupClose { get; private set; }

        public Button RecomputeTax { get; private set; }

        public Button SaveDetails { get; private set; }

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";
            
            GoBack = new Button("Go back", By.Id("ext-gen896"), name);            
            PopupClose = new Button("Popup Close", By.XPath("//button[text()='Close']"), name);
            RecomputeTax = new Button("Recompute Tax", By.Id("ext-gen37"), name, iframe);
            SaveDetails = new Button("Save Details", By.Id("ext-gen44"), name, iframe);            
        }
    }
}
