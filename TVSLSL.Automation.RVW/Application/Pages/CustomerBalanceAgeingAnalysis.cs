namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class CustomerBalanceAgeingAnalysis : Page
    {
        private string iframe;        

        public CustomerBalanceAgeingAnalysis()
        {
            InitialisePage();
        }

        public InputBox AsOnDate { get; private set; }

        public InputBox CurrencyOption { get; private set; }

        public InputBox FinanceBook { get; private set; }

        public Button ViewCustomerBalanceAgeing { get; private set; }

        public CustomerBalanceAgeingAnalysisRow GetItemRow(int index)
        {
            return new CustomerBalanceAgeingAnalysisRow(index);
        }        

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            AsOnDate = new InputBox("As On Date", By.Id("cilboasondate"), name, iframe);
            CurrencyOption = new InputBox("Currency Option", By.Id("cilboreportcur"), name, iframe);
            FinanceBook = new InputBox("To PO Date", By.Id("cmbfinancebook"), name, iframe);
            ViewCustomerBalanceAgeing = new Button("View Customer Balance Ageing", By.Id("ext-gen41"), name, iframe);


        }
    }
}
