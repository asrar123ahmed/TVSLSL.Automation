namespace TVSLSL.Automation.RVW.Tests.Common
{
    using NUnit.Framework;
    using System.Threading;
    using System.Xml;
    using TVSLSL.Automation.Common.Tests;
    using TVSLSL.Automation.Common.Tests.Utilities;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.RVW.Application;    

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

            string filepath = System.AppDomain.CurrentDomain.BaseDirectory;

            config.Load(filepath + "Config\\Test Run Config.xml");

            //config.load("C:\Users\asrar.ahmed\source\repos\TVSLSL.Automation\TVSLSL.Automation.RVW\Tests\Data\Config\Test Run Config.xml"); //Now config file need to update in folder bin\debug\config

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

        private void TestUserGroupCheck()
        {
            string userGroup;
            string category = (string)TestContext.CurrentContext.Test.Properties.Get("Category");
            if (category != null
                && category.Equals("TestUserGroup"))
            {
                try
                {
                    WebDriverHelper.InitialiseDriver();
                    WebDriverHelper.LaunchUrl(TestRun.SelectedEnvironment);

                    RVWWebApp.Login.SignIntoAccountWIthTestUser();

                    userGroup = RVWWebApp.SelfServiceHome.UserGroup.GetElementText();

                    if (userGroup.Equals("Asrar") == false)
                    {
                        WaitSeconds(3);
                        RVWWebApp.SelfServiceHome.UserInfoClick.SelectDropDownOptionByText("Setup Defaults");
                        RVWWebApp.SelfServiceHome.UserGroupPopUp.OUInstanceDesc.InputText("", true);
                        RVWWebApp.SelfServiceHome.UserGroupPopUp.OUInstanceDesc.Click();

                        RVWWebApp.SelfServiceHome.UserGroupPopUp.SavedRecordPopUpClose.Click();
                        RVWWebApp.SelfServiceHome.UserGroupPopUp.ChangeDefaultPopUpClose.Click();
                    }

                }

                catch
                {
                    //Nothing To Do
                }

                finally
                {
                    WebDriverHelper.KillDriver();
                }
            }
        }
        public void WaitSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
    }
}
