namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class PRAdditionalDetails : Page
    {
        private string iframe;        

        public PRAdditionalDetails()
        {
            InitialisePage();
        }

        public Button PRAdditionalPageGoBackBtn { get; private set; }

        public InputBox LineOfBusiness { get; private set; }

        public Label PRNumber { get; private set; }

        public InputBox ProjectLocation { get; private set; }

        public InputBox ProjectName { get; private set; }

        public Button Save { get; private set; }

        public Button SavePopupClose { get; private set; }

        public PRAdditionalDetailsItemRow GetItemRow(int index)
        {
            return new PRAdditionalDetailsItemRow(index);
        }

        public void SaveAdditionalDetails()
        {
            Save.Click();
            WebDriverHelper.DismissAlert();
            WaitSeconds(3);
        }

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            PRAdditionalPageGoBackBtn = new Button("GoBack Button", By.Id("ext-gen848"), name);
            LineOfBusiness = new InputBox("Line Of Business", By.Id("cmbline_of_business"), name, iframe);
            PRNumber = new Label("PR Number", By.XPath("//div[@id='span_dsppr_no']//div"), name, iframe);
            ProjectLocation = new InputBox("Project Location", By.Id("txtproject_location"), name, iframe);
            ProjectName = new InputBox("Project Name", By.Id("txtproject_name"), name, iframe);
            Save = new Button("Save", By.XPath("//*[@tabindex='8']"), name, iframe);
            SavePopupClose = new Button("Save Popup Close", By.XPath("//em/button[contains(.,'Close')]"), name);
        }
    }
}
