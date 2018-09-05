namespace TVSLSL.Automation.Common.Tests.Utilities
{
    using NUnit.Framework;
    using System;
    using System.IO;

    public static class TestLogger
    {
        private static TestStep currentTestStep;
        private static string fileName = string.Empty;

        static TestLogger()
        {
            currentTestStep = null;            
        }

        public static TestStep CurrentTestStep
        {
            get
            {
                if (currentTestStep == null)
                {
                    CreateTestStep("Undefined Action");
                }

                return currentTestStep;
            }
        }

        public static void CreateTestStep(string description)
        {
            currentTestStep = new TestStep(description);
            AppendTextToLog(description);
        }

        public static string CreateTestStep(string action, string element, string page)
        {
            string stepDescription = BuildTestStepMessage(action, element, page);
            CreateTestStep(stepDescription);

            return stepDescription;
        }

        public static void LogException(string exceptionMessage, string stackTrace)
        {
            AppendTextToLog(exceptionMessage);
            AppendTextToLog(stackTrace);
        }

        public static void LogTestCaseEnd()
        {
            string entryText = string.Concat("TEST CASE ENDED: ", TestContext.CurrentContext.Test.Name);

            AppendTextToLog(entryText);
            TestContext.AddTestAttachment(fileName);
        }

        public static void LogTestCaseStart()
        {
            fileName = string.Concat(TestRun.GetCurrentTestResultDirectory(), "/", TestContext.CurrentContext.Test.Name, "_(TestCaseLog).txt");
            string entryText = string.Concat("TEST CASE STARTED: ", TestContext.CurrentContext.Test.Name);
            AppendTextToLog(entryText);
        }

        public static void WriteToLog(string text)
        {
            AppendTextToLog(text);
        }

        private static void AppendTextToLog(string entryText)
        {
            File.AppendAllLines(fileName, new string[] { string.Concat(DateTime.Now.ToString(), " ", entryText) });
        }

        private static string BuildTestStepMessage(string action, string element, string page)
        {
            string stepDescription = "{0} (element '{1}' on page '{2}')";
            return string.Format(stepDescription, action, element, page);
        }
    }
}