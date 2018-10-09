namespace TVSLSL.Automation.ERP.Tests.Common
{
    using NUnit.Framework;
    using System.Threading;
    using System.Xml;
    using TVSLSL.Automation.Common.Tests;
    using TVSLSL.Automation.Common.Tests.Utilities;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.ERP.Application;
        
    public class ERPTests
    {
        [SetUp]
        public void Setup()
        {
            TestLogger.LogTestCaseStart();
            WebDriverHelper.InitialiseDriver();
            WebDriverHelper.LaunchUrl(TestRun.SelectedEnvironment);
            WebDriverHelper.Maximise();
        }

        [OneTimeSetUp]
        public void SuiteSetup()
        {
            XmlDocument config = new XmlDocument();
            config.Load(@"C:\Users\asrar.ahmed\source\repos\TVSLSL.Automation\TVSLSL.Automation.ERP\Tests\Data\Config\Test Run Config.xml");

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
    }
}
