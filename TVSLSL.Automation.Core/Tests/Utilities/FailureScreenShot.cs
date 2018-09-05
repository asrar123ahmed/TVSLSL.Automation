namespace TVSLSL.Automation.Common.Tests.Utilities
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System;
    using Web;

    public class FailureScreenShot
    {
        public static void Capture()
        {
            try
            {
                Screenshot screenShot = ((ITakesScreenshot)WebDriverHelper.Driver).GetScreenshot();

                string fileName = string.Concat(TestRun.GetCurrentTestResultDirectory(), "/", TestContext.CurrentContext.Test.Name, "_(Failure Screenshot).png");

                if (screenShot != null)
                {
                    screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
                    TestContext.AddTestAttachment(fileName);
                }
            }
            catch (Exception ex)
            {
                TestLogger.WriteToLog("Could not capture screenshot of the failure");
                TestLogger.WriteToLog(ex.Message);
            }
        }
    }
}