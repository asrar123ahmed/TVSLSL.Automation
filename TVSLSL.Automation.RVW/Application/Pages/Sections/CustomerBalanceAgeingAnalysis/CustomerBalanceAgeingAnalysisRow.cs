namespace TVSLSL.Automation.RVW.Application.Pages.Sections
{    
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;

    public class CustomerBalanceAgeingAnalysisRow : Section
    {
        private string iframe;

        public CustomerBalanceAgeingAnalysisRow(int rowIndex)
        {
            InitialiseSection(rowIndex);
        }

        public InputBox BucketRange { get; private set; }

        public InputBox DaysFrom { get; private set; }

        public InputBox DaysTo { get; private set; }        

        private void InitialiseSection(int rowIndex)
        {
            iframe = "ilboinnerframe";

            string locatorTextPrefix = "Ageing Analysis Table Row {0} ({1})";

            BucketRange = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Bucket Range"),
                                BuildDynamicLocator("//*[@id='mlmlageinganalysis_cell_c{0}_r{1}']/div", 1, rowIndex),
                                name, iframe);

            DaysFrom = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Days From"),
                                BuildDynamicLocator("//*[@id='mlmlageinganalysis_cell_c{0}_r{1}']/div", 2, rowIndex),
                                name, iframe);

            DaysTo = new InputBox(string.Format(locatorTextPrefix, rowIndex, "DaysTo"),
                                BuildDynamicLocator("//*[@id='mlmlageinganalysis_cell_c{0}_r{1}']/div", 3, rowIndex),
                                name, iframe);            
        }
    }
}
