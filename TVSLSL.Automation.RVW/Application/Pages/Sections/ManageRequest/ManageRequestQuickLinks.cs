namespace TVSLSL.Automation.RVW.Application.Pages.Sections
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;

    public class ManageRequestQuickLinks : Section
    {
        private string iframe;

        public ManageRequestQuickLinks()
        {
            InitialiseSection();
        }

        public Button NewRequest { get; private set; }

        private void InitialiseSection()
        {
            iframe = "ilboinnerframe";

            NewRequest = new Button("New Request", By.XPath("//table[@id='SECTION_[MAINSCREEN]_QCK_LINKS_SEC']//div[text()='New Request']"), name, iframe);
        }
    }
}
