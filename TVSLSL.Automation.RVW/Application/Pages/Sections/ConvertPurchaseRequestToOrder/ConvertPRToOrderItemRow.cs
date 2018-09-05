namespace TVSLSL.Automation.RVW.Application.Pages.Sections
{    
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;

    public class ConvertPRToOrderItemRow : Section
    {
        private string iframe;

        public ConvertPRToOrderItemRow(int rowIndex)
        {
            InitialiseSection(rowIndex);
        }

        public InputBox PreferredSupplierCode { get; private set; }

        public CheckBox SelectRow { get; private set; }

        private void InitialiseSection(int rowIndex)
        {   
            iframe = "ilboinnerframe";

            string locatorTextPrefix = "Item Details Table Row {0} ({1})";                       

            PreferredSupplierCode = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Preferred Supplier Code"),
                                BuildDynamicLocator("//*[@id='mltprdetail_cell_c{0}_r{1}']", 23, rowIndex),
                                name, iframe);
            SelectRow = new CheckBox(string.Format(locatorTextPrefix, rowIndex, "Select Row"),
                                BuildDynamicLocator("//*[@id='mltprdetail_cell_csel_r{0}']//img", rowIndex),
                                name, iframe);
        }
    }
}
