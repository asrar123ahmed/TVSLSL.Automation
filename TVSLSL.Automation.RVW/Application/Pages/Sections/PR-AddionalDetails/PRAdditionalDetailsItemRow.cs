namespace TVSLSL.Automation.RVW.Application.Pages.Sections
{    
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;

    public class PRAdditionalDetailsItemRow : Section
    {
        private string iframe;

        public PRAdditionalDetailsItemRow(int rowIndex)
        {
            InitialiseSection(rowIndex);
        }

        public InputBox BillToCustomer { get; private set; }

        public InputBox BudgetDeviation { get; private set; }

        public CheckBox MassCheck { get; private set; }
        
        private void InitialiseSection(int rowIndex)
        {
            iframe = "ilboinnerframe";

            string locatorTextPrefix = "Item Details Table Row {0} ({1})";


            BillToCustomer = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Bill To Customer"),
                                BuildDynamicLocator("//*[@id='mlpradd_cell_c{0}_r{1}']", 13, rowIndex),
                                name, iframe);

            BudgetDeviation = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Budget Deviation"),
                                BuildDynamicLocator("//*[@id='mlpradd_cell_c{0}_r{1}']", 14, rowIndex),
                                name, iframe);

            MassCheck = new CheckBox(string.Format(locatorTextPrefix, rowIndex, "Budget Deviation"),
                           BuildDynamicLocator("//*[@id='mlpradd_cell_csel_r{0}']", rowIndex),
                           name, iframe);
        }
    }
}
