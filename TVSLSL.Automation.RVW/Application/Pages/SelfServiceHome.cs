namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class SelfServiceHome : Page
    {
        public SelfServiceHome()
        {
            InitialisePage();
        }

        public Label FirstHeaderSearchSuggestionOption { get; private set; }
        public InputBox HeaderSearchBox { get; private set; }

        public Link HomeTickerDown { get; private set; }

        public MyLeave MyLeave { get; private set; }

        public Button TopPanelToggle { get; private set; }


        private void InitialisePage()
        {
            FirstHeaderSearchSuggestionOption = new Label("First Search Suggestion Option", By.XPath("//div[contains(@class,'x-grid3-col-bpcsearch_cell_5')]"), name);
            HeaderSearchBox = new InputBox("Header Search", By.Id("bpcsearch"), name);
            MyLeave = SectionManager.GetMyLeave();
            HomeTickerDown = new Link("Home Ticker Down", By.Id("bannerCollapse"), name);
            TopPanelToggle = new Button("Top Panel Selectable Toggle", By.XPath("//div[@id='top-panel']//em/button[contains(@class,'x-btn-text x-icon-bpc')]"), name);
        }
    }
}
