namespace TVSLSL.Automation.RVW.Application.Pages.Sections
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    
    public class MyLeave : Section
    {
        private string iframe;

        public MyLeave()
        {
            InitialiseSection();
        }

        public Link ManageLeave { get; private set; }

        private void InitialiseSection()
        {
            iframe = "ilboinnerframe";

            ManageLeave = new Link("My Leave Manage leave", By.XPath("//tr[@id='HIGHLEVELSECTION_ROW_002']//div[text()='Manage Leave']"), name, iframe);
        }
    }
}