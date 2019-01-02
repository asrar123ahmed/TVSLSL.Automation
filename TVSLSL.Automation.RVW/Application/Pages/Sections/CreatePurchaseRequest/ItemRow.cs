namespace TVSLSL.Automation.RVW.Application.Pages.Sections
{    
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;  

    public class ItemRow : Section
    {
        private string iframe;

        public ItemRow(int rowIndex)
        {
            InitialiseSection(rowIndex);
        }

        public InputBox ACUsage { get; private set; }

        public InputBox Cost { get; private set; }

        public InputBox ItemCode { get; private set; }

        public InputBox NeedDate { get; private set; }

        public InputBox Per { get; private set; }

        public InputBox PreferredSupplierCode { get; private set; }

        public InputBox RequiredQuantity { get; private set; }

        public InputBox UOM { get; private set; }        

        private void InitialiseSection(int rowIndex)
        {
            iframe = "ilboinnerframe";

            string locatorTextPrefix = "Item Details Table Row {0} ({1})";

            ACUsage = new InputBox(string.Format(locatorTextPrefix, rowIndex, "AC Usage"),
                                BuildDynamicLocator("//*[@id='mltprcrtmain_cell_c{0}_r{1}']", 32, rowIndex),
                                name, iframe);

            Cost = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Cost"),
                                BuildDynamicLocator("//*[@id='mltprcrtmain_cell_c{0}_r{1}']", 6, rowIndex),
                                name, iframe);

            ItemCode = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Item Code"),
                                BuildDynamicLocator("//*[@id='mltprcrtmain_cell_c{0}_r{1}']", 1, rowIndex),
                                name, iframe);            

            NeedDate = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Need Date"),
                                BuildDynamicLocator("//*[@id='mltprcrtmain_cell_c{0}_r{1}']", 9, rowIndex),
                                name, iframe);

            Per = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Per"),
                                BuildDynamicLocator("//*[@id='mltprcrtmain_cell_c{0}_r{1}']", 6, rowIndex),
                                name, iframe);

            PreferredSupplierCode = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Supplier Code"),
                                BuildDynamicLocator("//*[@id='mltprcrtmain_cell_c{0}_r{1}']", 12, rowIndex),
                                name, iframe);

            RequiredQuantity = new InputBox(string.Format(locatorTextPrefix, rowIndex, "Required Quantity"),
                                BuildDynamicLocator("//*[@id='mltprcrtmain_cell_c{0}_r{1}']", 4, rowIndex),
                                name, iframe);

            UOM = new InputBox(string.Format(locatorTextPrefix, rowIndex, "UOM"),
                                BuildDynamicLocator("//*[@id='mltprcrtmain_cell_c{0}_r{1}']", 5, rowIndex),
                                name, iframe);
        }
    }
}
