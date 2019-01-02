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

        public static ConvertPurchaseRequestToOrder ConvertPurchaseRequestToOrder { get; private set; }

        public static CreatePurchaseRequest CreatePurchaseRequest { get; private set; }

        public static EditPurchaseOrder EditPurchaseOrder { get; private set; }        

        public static EditPurchaseRequest EditPurchaseRequest { get; private set; }

        public static Login Login { get; private set; }

        public static ManageRequest ManageRequest { get; private set; }

        public static PRAdditionalDetails PRAdditionalDetails { get; private set; }

        public static SelfServiceHome SelfServiceHome { get; private set; }

        public static ViewPurchaseOrder ViewPurchaseOrder { get; private set; }

        public static ViewPurchaseRequest ViewPurchaseRequest { get; private set; }

        private static void BuildPages()
        {
            ApplyLeave = new ApplyLeave();
            C1MarginReport = new C1MarginReport();
            ConvertPurchaseRequestToOrder = new ConvertPurchaseRequestToOrder();
            CreatePurchaseRequest = new CreatePurchaseRequest();
            EditPurchaseOrder = new EditPurchaseOrder();
            EditPurchaseRequest = new EditPurchaseRequest();
            Login = new Login();
            ManageRequest = new ManageRequest();
            PRAdditionalDetails = new PRAdditionalDetails();
            SelfServiceHome = new SelfServiceHome();
            ViewPurchaseOrder = new ViewPurchaseOrder();
            ViewPurchaseRequest = new ViewPurchaseRequest();
        }
    }
}