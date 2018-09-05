namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class ApplyLeave : Page
    {
        private string iframe;

        public ApplyLeave()
        {
            InitialisePage();
        }

        public InputBox AdditionalReason { get; private set; }

        public InputBox EndDate { get; private set; }

        public InputBox EndTime { get; private set; }

        public InputBox LeaveType { get; private set; }

        public InputBox Reason { get; private set; }

        public InputBox StartDate { get; private set; }

        public InputBox StartTime { get; private set; }

        public Button SubmitRequest { get; private set; }

        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            AdditionalReason = new InputBox("Additional Reason", By.XPath("//div//input[@id='txtlv_type_addtreason']"), name, iframe);
            EndDate = new InputBox("End Date", By.XPath("//div//input[@id='txtlv_type_enddate']"), name, iframe);
            EndTime = new InputBox("End Time", By.XPath("//div//input[@id='txtlv_type_endtime']"), name, iframe);
            LeaveType = new InputBox("Leave Type", By.XPath("//div//input[@id='cmblv_type']"), name, iframe);
            Reason = new InputBox("Reason", By.XPath("//div//input[@id='cmblv_type_reasoncmb']"), name, iframe);
            StartDate = new InputBox("Start Date", By.XPath("//div//input[@id='txtlv_type_startdate']"), name, iframe);
            StartTime = new InputBox("Start Time", By.XPath("//div//input[@id='txtlv_type_starttime']"), name, iframe);
            SubmitRequest = new Button("Submit Request", By.XPath("//div//button[@id='ext-gen97']"), name, iframe);
        }
    }
}
