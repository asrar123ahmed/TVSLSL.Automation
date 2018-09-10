namespace TVSLSL.Automation.RVW.Application.Pages.Sections.C1MarginRepot
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;

    public class C1MarginItemRow : Section
    {
        private string iframe;

        public C1MarginItemRow(int rowIndex)
        {
            InitialiseSection(rowIndex);
        }

      

        private void InitialiseSection(int rowIndex)
        {
            iframe = "ilboinnerframe";

            string locatorTextPrefix = "Item Details Table Row {0} ({1})";

        }
    }
}
