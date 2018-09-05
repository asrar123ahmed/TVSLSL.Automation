namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class ViewPurchaseRequest : Page
    {
        private string iframe;        

        public ViewPurchaseRequest()
        {
            InitialisePage();
        }

        public Button GoBack { get; private set; }

        public InputBox PRDateFrom { get; private set; }

        public InputBox PRDateTo { get; private set; }

        public InputBox PRNumber { get; private set; }

        public InputBox PRNumberFrom { get; private set; }

        public InputBox PRNumberTo { get; private set; }

        public Button Search { get; private set; }

        public Button ViewPurchaseRequestBtn { get; private set; }        

        public ViewPurchaseSearchResultsItemRow GetItemRow(int index)
        {
            return new ViewPurchaseSearchResultsItemRow(index);
        }
        
        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            GoBack = new Button("Go Back", By.Id("ext-gen848"), name);
            PRDateFrom = new InputBox("PR Date From", By.Id("txtprdatefrom"), name, iframe);
            PRDateTo = new InputBox("PR Date To", By.Id("txtprdateto"), name, iframe);
            PRNumber = new InputBox("PR Number", By.Id("txtprno"), name, iframe);
            PRNumberFrom = new InputBox("PR Number From", By.Id("txtprnofrom"), name, iframe);
            PRNumberTo = new InputBox("PR Number To", By.Id("txtprnoto"), name, iframe);
            Search = new Button("Search", By.Id("ext-gen49"), name, iframe);
            ViewPurchaseRequestBtn = new Button("View Purchase Request", By.Id("span_prvwentpgmainpglnk"), name, iframe);            
        }
    }
}
