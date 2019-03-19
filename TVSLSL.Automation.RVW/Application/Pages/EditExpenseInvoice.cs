namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    public class EditExpenseInvoice : Page
    {
        private string iframe;        

        public EditExpenseInvoice()
        {
            InitialisePage();
        }       

        public Button EditAndAuthorizeInvoice { get; private set; }        

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            EditAndAuthorizeInvoice = new Button("Edit And Authorize Invoice", By.Id("ext-gen147"), name, iframe);            
        }
    }
}
