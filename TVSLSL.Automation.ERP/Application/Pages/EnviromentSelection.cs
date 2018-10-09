namespace TVSLSL.Automation.ERP.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.ERP.Tests.Data.Accounts;

    public class EnviromentSelection : Page
    {
        private string iframe;
        public EnviromentSelection()
        {
            InitialisePage();
        }       

        public Button ITGHDQ { get; private set; }

        private void InitialisePage()
        {
            iframe = "WEBUI";           
            
            ITGHDQ = new Button("ITGHDQ", By.XPath("//div[contains(@style,'top: 5px; width: 136px; height: 19px')]"), name, iframe);            
        }
    }
}
