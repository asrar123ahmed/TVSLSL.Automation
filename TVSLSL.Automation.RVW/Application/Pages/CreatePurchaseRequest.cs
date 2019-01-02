namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class CreatePurchaseRequest : Page
    {
        private string iframe;

        public CreatePurchaseRequest()
        {
            InitialisePage();
        }

        public InputBox AccountingUnit { get; private set; }

        public InputBox ACUsage { get; private set; }

        public InputBox AnalysisCode { get; private set; }

        public InputBox ApprovalDate { get; private set; }

        public InputBox BudgetId { get; private set; }

        public InputBox CCUsage { get; private set; }

        public Button CreateAndApprovePR { get; private set; }

        public InputBox CreatedAtOU { get; private set; }

        public Button CreatePR { get; private set; }

        public InputBox Currency { get; private set; }

        public InputBox CustomerCode { get; private set; }

        public Button Default { get; private set; }

        public InputBox DropshipId { get; private set; }

        public Link EditPurchaseRequest { get; private set; }        

        public InputBox Folder { get; private set; }

        public Button GetItemDetails { get; private set; }

        public Button GoBackBtn { get; private set; }

        public CheckBox Hold { get; private set; }

        public ItemRow ItemRow { get; private set; }

        public InputBox Mode { get; private set; }

        public Button MoveToFirstRow { get; private set; }

        public InputBox NeedDate { get; private set; }

        public InputBox NumberingSeries { get; private set; }

        public InputBox OrderAt { get; private set; }

        public Link PRAdditionalDetails { get; private set; }

        public Button PRCreatePopupClose { get; private set; }

        public Label PRCreatePopupMessage { get; private set; }

        public InputBox PRDate { get; private set; }

        public Button PrintPR { get; private set; }

        public InputBox PRNumber { get; private set; }

        public InputBox ProjectCode { get; private set; }

        public InputBox ProposalNumber { get; private set; }

        public InputBox ReceiptAt { get; private set; }

        public InputBox Remarks { get; private set; }

        public  InputBox RequesterId { get; private set; }

        public InputBox RequesterName { get; private set; }

        public InputBox SubAnalysisCode { get; private set; }

        public InputBox Type { get; private set; }

        public Link ViewItemPurchaseInformation { get; private set; }

        public Link ViewSupplier { get; private set; }

        public Link ViewWarehouseInformation { get; private set; }

        public void CreatePurchaseReq()
        {
            CreatePR.Click();
            WebDriverHelper.DismissAlert();
            WaitSeconds(3);
        }

        public ItemRow GetItemRow(int index)
        {
            return new ItemRow(index);
        }

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            AccountingUnit = new InputBox("Accounting Unit", By.Id("ext-gen156"), name, iframe);
            ACUsage = new InputBox("AC Usage", By.Id("ext-gen174"), name, iframe);
            AnalysisCode = new InputBox("Analysis Code", By.Id("txtanalcode"), name, iframe);
            ApprovalDate = new InputBox("Approval Date", By.Id("txtapprovaldate"), name, iframe);
            BudgetId = new InputBox("Budget Id", By.Id("txtbudgetid"), name, iframe);
            CCUsage = new InputBox("CC Usage", By.Id("ext-gen192"), name, iframe);
            CreateAndApprovePR = new Button("Create And Approve PR", By.Id("ext-gen106"), name, iframe);
            CreatedAtOU = new InputBox("Created At OU", By.Id("ext-gen300"), name, iframe);
            CreatePR = new Button("Create PR", By.Id("ext-gen99"), name, iframe);
            Currency = new InputBox("Currency", By.Id("ext-gen210"), name, iframe);
            CustomerCode = new InputBox("Customer Code", By.Id("txtcustomercode"), name, iframe);
            Default = new Button("Default", By.Id("ext-gen85"), name, iframe);
            DropshipId = new InputBox("Dropship Id", By.Id("txtdropshipid"), name, iframe);
            EditPurchaseRequest = new Link("Edit Purchase Request", By.Id("span_prcrtmainpgedtmainlnk"), name, iframe);            
            Folder = new InputBox("Folder", By.Id("ext-gen228"), name, iframe);
            GetItemDetails = new Button("Get Item Details", By.Id("ext-gen92"), name, iframe);
            GoBackBtn = new Button("Go Back", By.XPath("//button[@id='ext-gen848']"), name);
            Hold = new CheckBox("Hold", By.Id("ext-gen746"), name, iframe);      
            Mode = new InputBox("Mode", By.Id("ext-gen282"), name, iframe);
            MoveToFirstRow = new Button("Move To First Row", By.XPath("//*[@qtip='Move to first row [Home]']"), name);
            NeedDate = new InputBox("NeedDate", By.Id("txtneeddate"), name, iframe);
            NumberingSeries = new InputBox("Numbering Series", By.XPath("//img[@id='ext-gen246']"), name, iframe);
            OrderAt = new InputBox("Order At", By.Id("ext-gen264"), name, iframe);
            PRAdditionalDetails = new Link("PR Additional Details", By.Id("span__lnkprcrtmainpgadddetails"), name, iframe);
            PRCreatePopupClose = new Button("PR Create Popup Close", By.Id("ext-gen1159"), name);
            PRCreatePopupMessage = new Label("PR Create Popup Message", By.Id("msgRoot"), name);
            PRDate = new InputBox("PR Date", By.XPath("//input[@id='txtprdate']"), name, iframe);
            PrintPR = new Button("Print PR", By.XPath("//button[@id='ext-gen113' and @class='x-btn-text x-form-buttontext']"), name, iframe);
            PRNumber = new InputBox("PRNumber", By.Id("txtprno"), name, iframe);
            ProjectCode = new InputBox("Project Code", By.Id("txtproject_code"), name, iframe);
            ProposalNumber = new InputBox("Proposal Number", By.Id("txtproposalid"), name, iframe);
            ReceiptAt = new InputBox("Receipt At", By.Id("ext-gen336"), name, iframe);
            Remarks = new InputBox("Remarks", By.Id("txtremarks"), name, iframe);
            RequesterId = new InputBox("Requester Id", By.Id("txtrequesterid"), name, iframe);
            RequesterName = new InputBox("Requester Name", By.Id("dsprequestername"), name, iframe);
            SubAnalysisCode = new InputBox("Sub Analysis Code", By.Id("txtsubanalcode"), name, iframe);
            Type = new InputBox("Type", By.Id("cmbprtype"), name, iframe);
            ViewItemPurchaseInformation = new Link("View Item Purchase Information", By.Id("span_prcrtmainpgitemlnk2"), name, iframe);
            ViewSupplier = new Link("View Supplier", By.Id("span_prcrtmainpgvwsupplnk2"), name, iframe);
            ViewWarehouseInformation = new Link("View Warehouse Information", By.Id("span_prcrtmainpgvwwhlnk"), name, iframe);            
        }

    }
}
