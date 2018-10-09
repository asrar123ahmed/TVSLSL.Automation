namespace TVSLSL.Automation.ERP.Application
{
    using TVSLSL.Automation.ERP.Application.Pages;

    public static class ERPWebApp
    {
        static ERPWebApp()
        {
            BuildPages();
        }

        public static EnviromentSelection EnviromentSelection { get; private set; }

        public static GeneralInformation GeneralInformation { get; private set; }

        public static Login Login { get; private set; }
        

        private static void BuildPages()
        {
            EnviromentSelection = new EnviromentSelection();
            GeneralInformation = new GeneralInformation();
            Login = new Login();
        }
    }
}
