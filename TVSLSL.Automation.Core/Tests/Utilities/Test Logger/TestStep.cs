namespace TVSLSL.Automation.Common.Tests.Utilities
{
    using NUnit.Framework;
    using System;

    public class TestStep
    {
        private string description;
        private string exceptionMessage;
        private string result;
        private string stackTrace;
        private string testcase;

        private DateTime dateTime;

        public TestStep(string description)
        {
            exceptionMessage = string.Empty;
            dateTime = DateTime.Now;
            this.description = description;
            result = "PASS";
            testcase = TestContext.CurrentContext.Test.Name;
            stackTrace = string.Empty;
        }

        public DateTime DateTime
        {
            get { return dateTime; }
        }

        public string Description
        {
            get { return description; }
        }

        public string ExceptionMessage
        {
            get { return exceptionMessage; }
        }

        public string Result
        {
            get { return result; }
        }

        public string StackTrace
        {
            get { return stackTrace; }
        }

        public string TestCase
        {
            get { return testcase; }
        }

        public void MarkAsFailure(Exception exception)
        {
            FailureScreenShot.Capture();

            result = "FAIL";
            exceptionMessage = string.Concat("EXCEPTION MESSAGE: ", TestHelper.RemoveNewlineCharacters(exception.Message));
            stackTrace = string.Concat("STACK TRACE: ", TestHelper.RemoveNewlineCharacters(exception.StackTrace));

            TestLogger.LogException(exceptionMessage, stackTrace);
        }
    }
}