namespace TVSLSL.Automation.RVW.Application.Pages.Sections
{    
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;

    public class ViewPurchaseSearchResultsItemRow : Section
    {
        private string iframe;

        public ViewPurchaseSearchResultsItemRow(int rowIndex)
        {
            InitialiseSection(rowIndex);
        }

        public InputBox PRNumber { get; private set; }

        public Label RowCount { get; private set; }

        private void InitialiseSection(int rowIndex)
        {
            iframe = "ilboinnerframe";

            string locatorTextPrefix = "Item Details Table Row {0} ({1})";


            PRNumber = new InputBox(string.Format(locatorTextPrefix, rowIndex, "PR Number"),
                                BuildDynamicLocator("//*[@id='mldatatablename_cell_c{0}_r{1}']/div", 1, rowIndex),
                                name, iframe);

            RowCount = new Label("Row Count", By.XPath("//div[@id='ext-gen474']/div[@class='x-grid3-body']/div[contains(@class,'x-grid3-row ')]"), name, iframe);                                
        }
    }
}
