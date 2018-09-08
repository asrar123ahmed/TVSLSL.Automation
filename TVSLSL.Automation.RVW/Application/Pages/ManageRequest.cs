namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class ManageRequest : Page
    {
        private string iframe;

        public ManageRequest()
        {
            InitialisePage();
        }

        public Button GoBack { get; private set; }

        public ManageRequestQuickLinks ManageRequestQuickLinks { get; private set; }
        public Button MyPreferenceSetting { get; private set; }

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            GoBack = new Button("Go Back", By.Id("span_lnkpreferences"), name, iframe);
            ManageRequestQuickLinks = SectionManager.GetManageRequestQuickLinks();
            MyPreferenceSetting = new Button("My Preference Setting", By.XPath("//td[@id='ext-gen834']//div[@qtip='Go back']"), name);
        }
    }
}
