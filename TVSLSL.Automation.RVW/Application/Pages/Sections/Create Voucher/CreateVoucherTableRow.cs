namespace TVSLSL.Automation.RVW.Application.Pages.Sections
{    
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;

    public class CreateVoucherTableRow : Section
    {
        private string iframe;

        public CreateVoucherTableRow(int rowIndex)
        {
            InitialiseSection(rowIndex);
        }

        public InputBox AccountCode { get; private set; }

        public InputBox Amount { get; private set; }

        public InputBox Remarks { get; private set; }

        public InputBox UsageId { get; private set; }

        private void InitialiseSection(int rowIndex)
        {
            iframe = "ilboinnerframe";

            string locatorTextPrefix = "Item Details Table Row {0} ({1})";

            AccountCode = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Account Code"),
                                BuildDynamicLocator("//*[@id='mlaccinfo_cell_c{0}_r{1}']/div", 2, rowIndex),
                                name, iframe);

            Amount = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Amount"),
                                BuildDynamicLocator("//*[@id='mlaccinfo_cell_c{0}_r{1}']/div", 4, rowIndex),
                                name, iframe);

            Remarks = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Remarks"),
                                BuildDynamicLocator("//*[@id='mlaccinfo_cell_c{0}_r{1}']/div", 8, rowIndex),
                                name, iframe);

            UsageId = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Usage Id"),
                                BuildDynamicLocator("//*[@id='mlaccinfo_cell_c{0}_r{1}']/div", 1, rowIndex),
                                name, iframe);            
        }
    }
}
