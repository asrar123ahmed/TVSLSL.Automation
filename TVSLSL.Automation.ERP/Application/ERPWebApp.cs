namespace TVSLSL.Automation.ERP.Application
{
    using TVSLSL.Automation.ERP.Application.Pages;

    public static class ERPWebApp
    {
        static ERPWebApp()
        {
            BuildPages();
        }

        public static Login Login { get; private set; }

        private static void BuildPages()
        {
            Login = new Login();
        }
    }
}
