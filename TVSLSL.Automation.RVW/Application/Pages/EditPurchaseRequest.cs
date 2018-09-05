namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class EditPurchaseRequest : Page
    {
        private string iframe;        

        public EditPurchaseRequest()
        {
            InitialisePage();
        }

        public Button EditAndApprovePR { get; private set; }

        public Button GoBack { get; private set; }

        public Button PopupClose { get; private set; }

        public void GoBackBtnClick()
        {
            GoBack.Click();
            WaitSeconds(3);
            GoBack.Click();
            WaitSeconds(5);
        }

        public ViewPurchaseSearchResultsItemRow GetItemRow(int index)
        {
            return new ViewPurchaseSearchResultsItemRow(index);
        }
                
        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            EditAndApprovePR = new Button(" Edit And Approve PR", By.XPath("//button[@id='ext-gen106']"), name, iframe);
            GoBack = new Button("Go back", By.Id("ext-gen848"), name);
            PopupClose = new Button("Popup Close", By.XPath("//button[text()='Close']"), name);            
        }
    }
}
