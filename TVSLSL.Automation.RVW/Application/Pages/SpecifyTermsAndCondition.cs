namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class SpecifyTermsAndCondition : Page
    {
        private string iframe;        

        public SpecifyTermsAndCondition()
        {
            InitialisePage();
        }        

        public Button GoBack { get; private set; }

        public InputBox InsuranceAmount { get; private set; }

        public Button PopupClose { get; private set; }

        public Button SpecifyTermsAndConditionBtn { get; private set; }

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";
            
            GoBack = new Button("Go back", By.Id("ext-gen848"), name);
            InsuranceAmount = new InputBox("Insurance Amount", By.Id("txtinsuranceamount"), name, iframe);
            PopupClose = new Button("Popup Close", By.XPath("//button[text()='Close']"), name);
            SpecifyTermsAndConditionBtn = new Button("Specify Terms And Condition Btn", By.Id("ext-gen79"), name, iframe);            
        }
    }
}
