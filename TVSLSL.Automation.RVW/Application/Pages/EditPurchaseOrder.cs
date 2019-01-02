namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class EditPurchaseOrder : Page
    {
        private string iframe;        

        public EditPurchaseOrder()
        {
            InitialisePage();
        }

        public InputBox AnalysisCode { get; private set; }

        public Button Default { get; private set; }

        public Button EditAndApprovePO { get; private set; }

        public Button GoBack { get; private set; }

        public Label PONumber { get; private set; }

        public Button PopupClose { get; private set; }

        public Button Refresh { get; private set; }

        public Link SpecifyPOPRCoverage { get; private set; }

        public Link SpecifyScheduleAndDistribution { get; private set; }

        public Link SpecifyTermsAndConditions { get; private set; }

        public Link TaxCalculationSummary { get; private set; }

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            AnalysisCode = new InputBox("Analysis Code", By.Id("txtanalysiscode"), name, iframe);
            Default = new Button("Default", By.Id("ext-gen97"), name, iframe);
            EditAndApprovePO = new Button(" Edit And Approve PR", By.XPath("//button[@id='ext-gen118']"), name, iframe);
            PONumber = new Label("PO Number", By.XPath("//div[@id='span_txtpono']//div"), name, iframe);
            GoBack = new Button("Go back", By.Id("ext-gen848"), name);
            PopupClose = new Button("Popup Close", By.XPath("//button[text()='Close']"), name);
            Refresh = new Button("Refresh", By.XPath("refresh"), name, iframe);
            SpecifyPOPRCoverage = new Link("Specify PO - PR Coverage", By.Id("span_poedtmainlnk9"), name, iframe);
            SpecifyScheduleAndDistribution = new Link("Specify Schedule And Distribution", By.Id("span_poedtmainlnk2"), name, iframe);
            SpecifyTermsAndConditions = new Link("Specify Terms And Conditions", By.Id("span_poedtmainlnk3"), name, iframe);
            TaxCalculationSummary = new Link("Tax Calculation Summary", By.Id("span_poedtmaintaxlnk"), name, iframe);
        }
    }
}
