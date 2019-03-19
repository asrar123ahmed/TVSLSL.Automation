namespace TVSLSL.Automation.RVW.Application.Pages.Sections
{    
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;

    public class CreateExpenseInvoiceTableRow : Section
    {
        private string iframe;

        public CreateExpenseInvoiceTableRow(int rowIndex)
        {
            InitialiseSection(rowIndex);
        }

        public InputBox Amount { get; private set; }

        public InputBox AnalysisCode  { get; private set; }

        public InputBox CostCenter { get; private set; }

        public InputBox Remarks { get; private set; }        

        public InputBox UsageID { get; private set; }

        private void InitialiseSection(int rowIndex)
        {
            iframe = "ilboinnerframe";

            string locatorTextPrefix = "Item Details Table Row {0} ({1})";

            Amount = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Amount"),
                                BuildDynamicLocator("//*[@id='mlexpinfo_cell_c{0}_r{1}']/div", 8, rowIndex),
                                name, iframe);

            AnalysisCode = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Analysis Code"),
                                BuildDynamicLocator("//*[@id='mlexpinfo_cell_c{0}_r{1}']/div", 11, rowIndex),
                                name, iframe);

            CostCenter = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Cost Center"),
                                BuildDynamicLocator("//*[@id='mlexpinfo_cell_c{0}_r{1}']/div", 10, rowIndex),
                                name, iframe);

            Remarks = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Remarks"),
                                BuildDynamicLocator("//*[@id='mlexpinfo_cell_c{0}_r{1}']/div", 9, rowIndex),
                                name, iframe);

            UsageID = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Usage Id"),
                                BuildDynamicLocator("//*[@id='mlexpinfo_cell_c{0}_r{1}']/div", 3, rowIndex),
                                name, iframe);
        }
    }
}
