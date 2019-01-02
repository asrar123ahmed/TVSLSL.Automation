namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class SpecifyPO_PRCoverage : Page
    {
        private string iframe;        

        public SpecifyPO_PRCoverage()
        {
            InitialisePage();
        }        

        public Button GoBack { get; private set; }

        public Button PopupClose { get; private set; }

        public Button CoverPR { get; private set; }

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";
            
            GoBack = new Button("Go back", By.Id("ext-gen848"), name);            
            PopupClose = new Button("Popup Close", By.XPath("//button[text()='Close']"), name);
            CoverPR = new Button("Cover PR", By.XPath("ext-gen57"), name, iframe);            
        }
    }
}
