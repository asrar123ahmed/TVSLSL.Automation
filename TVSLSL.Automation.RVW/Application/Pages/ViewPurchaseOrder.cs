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

        public InputBox FromPODate { get; private set; }

        public InputBox ToPODate { get; private set; }

        public InputBox FromPONumber { get; private set; }

        public Button GoBack { get; private set; }

        public InputBox ToPONumber { get; private set; }

        public Label RowCount { get; private set; }

        public Button Search { get; private set; }        

        public ViewPurchaseOrderItemRow GetItemRow(int index)
        {
            return new ViewPurchaseOrderItemRow(index);
        }

        public int GetTotalRowCount()
        {
            return RowCount.GetElementCount();
        }

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            FromPODate = new InputBox("From PO Date", By.Id("txtpodatefrom"), name, iframe);
            GoBack = new Button("Go Back", By.Id("ext-gen848"), name);
            ToPODate = new InputBox("To PO Date", By.Id("txtpodateto"), name, iframe);
            FromPONumber = new InputBox("From PO Number", By.Id("txtponofrom"), name, iframe);
            ToPONumber = new InputBox("To PO Number", By.Id("txtponoto"), name, iframe);
            RowCount = new Label("Row Count", By.XPath("//div[@id='ext-gen522']/div[contains(@class,'x-grid3-row ')]"), name, iframe);
            Search = new Button("Search", By.XPath("//em/button[contains(.,'Search')]"), name, iframe);            
        }
    }
}
