namespace TVSLSL.Automation.RVW.Application.Pages.Sections
{    
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;

    public class ViewPurchaseOrderItemRow : Section
    {
        private string iframe;

        public ViewPurchaseOrderItemRow(int rowIndex)
        {
            InitialiseSection(rowIndex);
        }

        public InputBox PONumber { get; private set; }

        public Label RowCount { get; private set; }

        public int GetTotalRowCount()
        {
            return RowCount.GetElementCount();
        }

        private void InitialiseSection(int rowIndex)
        {
            iframe = "ilboinnerframe";

            string locatorTextPrefix = "Item Details Table Row {0} ({1})";

            PONumber = new InputBox(string.Format(locatorTextPrefix, rowIndex, "PO Number"),
                                BuildDynamicLocator("//*[@id='mltpoviwent_cell_c{0}_r{1}']/div", 1, rowIndex),
                                name, iframe);
            RowCount = new Label("Row Count", By.XPath("//div[@id='ext-gen522']/div[contains(@class,'x-grid3-row ')]"), name, iframe);
        }
    }
}
