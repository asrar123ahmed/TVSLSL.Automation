namespace TVSLSL.Automation.ERP.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.ERP.Tests.Data.Accounts;

    public class GeneralInformation : Page
    {
        private string iframe;
        public GeneralInformation()
        {
            InitialisePage();
        }       

        public Button Cancel { get; private set; }

        public Button CommandLine { get; private set; }

        public Button Exit { get; private set; }

        public Button Functions { get; private set; }

        public Button Lock { get; private set; }

        public Button Menus { get; private set; }

        public Button OK { get; private set; }

        private void InitialisePage()
        {
            iframe = "WEBUI";

            Cancel = new Button("Cancel", By.Id("BUTTON_CANCEL"), name, iframe);
            CommandLine = new Button("Command Line", By.Id("BUTTON_FKEYS01"), name, iframe);
            Exit = new Button("Exit", By.Id("BUTTON_EXIT"), name, iframe);
            Functions = new Button("Functions", By.Id("BUTTON_USER1"), name, iframe);
            Lock = new Button("Lock", By.Id("BUTTON_FKEYS02"), name, iframe);
            Menus = new Button("Menus", By.Id("BUTTON_FKEYS03"), name, iframe);
            OK = new Button("OK", By.Id("BUTTON_OK"), name, iframe);
        }
    }
}
