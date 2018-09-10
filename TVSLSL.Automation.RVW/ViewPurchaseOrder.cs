namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class ViewPurchaseOrder : Page
    {
        private string iframe;        

        public ViewPurchaseOrder()
        {
            InitialisePage();
        }

        public InputBox FromPONumber { get; private set; }

        public InputBox ToPONumber { get; private set; }
        
        public Button Search { get; private set; }        

        public ViewPurchaseOrderItemRow GetItemRow(int index)
        {
            return new ViewPurchaseOrderItemRow(index);
        }
        
        private void InitialisePage()
        {
            iframe = "ilboinnerframe";
            
            FromPONumber = new InputBox("From PO Number", By.Id("txtponofrom"), name, iframe);
            ToPONumber = new InputBox("To PO Number", By.Id("txtponoto"), name, iframe);            
            Search = new Button("Search", By.Id("ext-gen49"), name, iframe);            
        }
    }
}
