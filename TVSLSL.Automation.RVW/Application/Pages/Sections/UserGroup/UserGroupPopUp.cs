namespace TVSLSL.Automation.RVW.Application.Pages.Sections
{    
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;

    public class UserGroupPopUp : Section
    {
        private string iframe;

        public UserGroupPopUp()
        {
            InitialiseSection();
        }

        public InputBox OUInstanceDesc { get; private set; }

        public Button ChangeDefaultPopUpClose { get; private set; } 

        public Button SaveDefaults { get; private set; }

        public Button SavedRecordPopUpClose { get; private set; }

        private void InitialiseSection()
        {
            iframe = "childilboinnerframe";

            ChangeDefaultPopUpClose = new Button("Change Default PopUp Close", By.Id("ext-gen498"), name);
            OUInstanceDesc = new InputBox("OU Instance Desc.", By.Id("cmbouinstance"), name, iframe);
            SaveDefaults = new Button("Save Defaults", By.XPath("//em/button[@id='ext-gen23']"), name, iframe);
            SavedRecordPopUpClose = new Button("Saved Record PopUp Close", By.Id("ext-gen1249"), name);
        }
    }
}
