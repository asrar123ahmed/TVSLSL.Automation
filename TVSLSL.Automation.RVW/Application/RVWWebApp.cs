namespace TVSLSL.Automation.RVW.Application
{
    using TVSLSL.Automation.RVW.Application.Pages;
   
    public static class RVWWebApp
    {
        static RVWWebApp()
        {
            BuildPages();
        }

        public static ApplyLeave ApplyLeave { get; private set; }

        public static C1MarginReport C1MarginReport { get; private set; }

        public static CustomerBalanceAgeingAnalysis CustomerBalanceAgeingAnalysis { get; private set; }

        public static ConvertPurchaseRequestToOrder ConvertPurchaseRequestToOrder { get; private set; }

        public static CreatePurchaseRequest CreatePurchaseRequest { get; private set; }

        public static CreateExpenseInvoice CreateExpenseInvoice { get; private set; }

        public static CreateVoucher CreateVoucher { get; private set; }

        public static EditExpenseInvoice EditExpenseInvoice { get; private set; }

        public static EditPurchaseOrder EditPurchaseOrder { get; private set; }        

        public static EditPurchaseRequest EditPurchaseRequest { get; private set; }

        public static EditVoucher EditVoucher { get; private set; }

        public static ExpenseInvoiceTaxCalculationSummary ExpenseInvoiceTaxCalculationSummary { get; private set; }

        public static Login Login { get; private set; }

        public static ManageRequest ManageRequest { get; private set; }

        public static PRAdditionalDetails PRAdditionalDetails { get; private set; }

        public static SelectPurchaseOrder SelectPurchaseOrder { get; private set; }

        public static SelfServiceHome SelfServiceHome { get; private set; }

        public static SpecifyPOPRCoverage SpecifyPOPRCoverage { get; private set; }

        public static SpecifyTermsAndCondition SpecifyTermsAndCondition { get; private set; }

        public static SpecifyScheduleAndDistribution SpecifyScheduleAndDistribution { get; private set; }

        public static TaxCalculationSummary TaxCalculationSummary { get; private set; }

        public static ViewPurchaseOrder ViewPurchaseOrder { get; private set; }

        public static ViewPurchaseRequest ViewPurchaseRequest { get; private set; }

        private static void BuildPages()
        {
            ApplyLeave = new ApplyLeave();
            C1MarginReport = new C1MarginReport();
            CustomerBalanceAgeingAnalysis = new CustomerBalanceAgeingAnalysis();
            ConvertPurchaseRequestToOrder = new ConvertPurchaseRequestToOrder();
            CreateExpenseInvoice = new CreateExpenseInvoice();
            CreateVoucher = new CreateVoucher();
            CreatePurchaseRequest = new CreatePurchaseRequest();
            EditExpenseInvoice = new EditExpenseInvoice();
            EditPurchaseOrder = new EditPurchaseOrder();
            EditPurchaseRequest = new EditPurchaseRequest();
            EditVoucher = new EditVoucher();
            ExpenseInvoiceTaxCalculationSummary = new ExpenseInvoiceTaxCalculationSummary();
            Login = new Login();
            ManageRequest = new ManageRequest();
            PRAdditionalDetails = new PRAdditionalDetails();
            SelectPurchaseOrder = new SelectPurchaseOrder();
            SelfServiceHome = new SelfServiceHome();
            SpecifyPOPRCoverage = new SpecifyPOPRCoverage();
            SpecifyTermsAndCondition = new SpecifyTermsAndCondition();
            SpecifyScheduleAndDistribution = new SpecifyScheduleAndDistribution();
            TaxCalculationSummary = new TaxCalculationSummary();
            ViewPurchaseOrder = new ViewPurchaseOrder();
            ViewPurchaseRequest = new ViewPurchaseRequest();
        }
    }
}