namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;

    public class SelectPurchaseOrder : Page
    {
        private string iframe;        

        public SelectPurchaseOrder()
        {
            InitialisePage();
        }

        public Button EditPurchaseOrder { get; private set; }

        public InputBox PONumber { get; private set; }        

        public Button ViewPurchaseOrder { get; private set; }       

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            EditPurchaseOrder = new Button("Edit Purchase Order", By.Id("span_poedtentlnk1"), name, iframe);
            PONumber = new InputBox("PO Number", By.Id("txtpono"), name, iframe);
            ViewPurchaseOrder = new Button("View Purchase Order", By.Id("span_povwentlnk1"), name, iframe);
        }
    }
}
