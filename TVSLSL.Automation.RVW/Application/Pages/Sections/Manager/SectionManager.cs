namespace TVSLSL.Automation.RVW.Application.Pages.Sections
{
    public static class SectionManager
    {        
        private static MyLeave MyLeave;
        private static ManageRequestQuickLinks ManageRequestQuickLinks;

        static SectionManager()
        {
            ManageRequestQuickLinks = null;
            MyLeave = null;

        }        

        public static ManageRequestQuickLinks GetManageRequestQuickLinks()
        {
            if (ManageRequestQuickLinks == null)
            {
                ManageRequestQuickLinks = new ManageRequestQuickLinks();
            }

            return ManageRequestQuickLinks;
        }

        public static MyLeave GetMyLeave()
        {
            if (MyLeave == null)
            {
                MyLeave = new MyLeave();
            }

            return MyLeave;
        }        
    }
}
