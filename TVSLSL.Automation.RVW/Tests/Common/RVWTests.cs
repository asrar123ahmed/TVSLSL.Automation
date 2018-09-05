namespace TVSLSL.Automation.RVW.Tests.Common
{
    using NUnit.Framework;
    using System.Threading;
    using System.Xml;
    using TVSLSL.Automation.Common.Tests;
    using TVSLSL.Automation.Common.Tests.Utilities;
    using TVSLSL.Automation.Common.Web;

    public class RVWTests
    {
        [SetUp]
        public void Setup()
        {
            TestLogger.LogTestCaseStart();
            WebDriverHelper.InitialiseDriver();
            WebDriverHelper.LaunchUrl(TestRun.SelectedEnvironment);
            if (TestRun.SelectedEnvironment.Equals("Test"))
            {
                WebDriverHelper.WaitUntilURLContains(TestRun.SelectedEnvironment);
            }
            else if (TestRun.SelectedEnvironment.Equals("Live"))
            {
                WebDriverHelper.WaitUntilURLContains("http://www.tvslogistics.com/RVW/extui/vwrt/securelaunchpanel");
                WebDriverHelper.SwitchWindow();                
                WebDriverHelper.WaitUntilURLContains("http://www.tvslogistics.com/RVW/extui/vwrt/LaunchPanel");
            }

            WebDriverHelper.Maximise();
        }

        [OneTimeSetUp]
        public void SuiteSetup()
        {
            XmlDocument config = new XmlDocument();
            config.Load(@"C:\Users\asrar.ahmed\source\repos\TVSLSL.Automation\TVSLSL.Automation.RVW\Tests\Data\Config\Test Run Config.xml");

            XmlNode rootNode = config.DocumentElement;
            TestRun.SelectedBrowser = rootNode.SelectSingleNode("//SelectedBrowser").InnerText;

            string selectedEnvironmentName = rootNode.SelectSingleNode("//SelectedEnvironment").InnerText;
            string xpath = string.Format("//Environment[@name='{0}']", selectedEnvironmentName);

            TestRun.SelectedEnvironment = rootNode.SelectSingleNode(xpath).Attributes["url"].Value; 
            TestRun.SelectedPlatform = rootNode.SelectSingleNode("//SelectedPlatform").InnerText;
        }

        [TearDown]
        public void TearDown()
        {
            TestLogger.LogTestCaseEnd();
            RunTimeTestData.ClearTestData();
            WebDriverHelper.KillDriver();
        }

        public void WaitSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
    }
}
