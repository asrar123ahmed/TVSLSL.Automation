namespace TVSLSL.Automation.RVW.Application.Pages.Sections
{    
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;

    public class EditPurchaseOrderItemRow : Section
    {
        private string iframe;

        public EditPurchaseOrderItemRow(int rowIndex)
        {
            InitialiseSection(rowIndex);
        }

        public InputBox ACUsage { get; private set; }

        private void InitialiseSection(int rowIndex)
        {
            iframe = "ilboinnerframe";

            string locatorTextPrefix = "Item Details Table Row {0} ({1})";


            ACUsage = new InputBox(string.Format(locatorTextPrefix, rowIndex, "AC Usage"),
                                BuildDynamicLocator("//*[@id='mltpoedtmain_cell_c{0}_r{1}']/div", 35, rowIndex),
                                name, iframe);
        }
    }
}
