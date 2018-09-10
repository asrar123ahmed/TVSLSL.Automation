namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class C1MarginReport : Page
    {
        private string iframe;

        public C1MarginReport()
        {
            InitialisePage();
        }

        public Button ExportToCsv { get; private set; }

        public Button ExportToExcel { get; private set; }

        public Button ExportToText { get; private set; }

        public InputBox From { get; private set; }

        public InputBox InputPagination { get; private set; }

        public Button NextRowSet { get; private set; }

        public Label TableRecord { get; private set; }

        public InputBox To { get; private set; }

        public Button Submit { get; private set; }

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            ExportToCsv = new Button("ExportToCsv", By.XPath("//button[@class='x-btn-text x-tool-root'][@id='ext-gen201']"), name, iframe);
            ExportToExcel = new Button("ExportToExcel", By.XPath("//button[@class='x-btn-text x-tool-root'][@id='ext-gen193']"), name, iframe);
            ExportToText = new Button("ExportToText", By.XPath("//button[@class='x-btn-text x-tool-root'][@id='ext-gen209']"), name, iframe);
            From = new InputBox("From Date", By.Id("frmdt4"), name, iframe);
            InputPagination = new InputBox("Input Pagination", By.Id("c1_h_pageText_c1_grd"), name, iframe);
            TableRecord = new Label("Table Records Display Per Pagination", By.XPath("//*[@class='x-btn-text'][@id='ext-gen70']"), name, iframe);
            NextRowSet = new Button("Next Row Set", By.XPath("//*[@class='x-btn-text x-tool-root'][@id='ext-gen78']"), name, iframe);
            To = new InputBox("To Date", By.Id("tdt2"), name, iframe);
            Submit = new Button("Submit", By.Id("ext-gen31"), name, iframe);
        }
    }
}
