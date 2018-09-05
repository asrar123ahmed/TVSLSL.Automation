namespace TVSLSL.Automation.Common.Web
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Threading;
    using Tests.Utilities;
    using TVSLSL.Automation.Common.Tests;

    public static class WebDriverHelper
    {
        public static IWebDriver Driver { get; private set; }

        static WebDriverHelper()
        {
            Driver = null;
        }

        public static void AcceptAlert()
        {
            int i = 0;
            while (i++ < 5)
            {
                try
                {
                    Driver.SwitchTo().Alert().Accept();
                    break;
                }
                catch (NoAlertPresentException)
                {
                    Thread.Sleep(2000);
                    continue;
                }
            }            
        }

        public static void DismissAlert()
        {
            int i = 0;
            while (i++ < 5)
            {
                try
                {
                    Driver.SwitchTo().Alert().Dismiss();
                    break;
                }
                catch (NoAlertPresentException)
                {
                    Thread.Sleep(2000);
                    continue;
                }
            }
        }

        public static object ExecuteJavascript(string script, params object[] args)
        {
            return ((IJavaScriptExecutor)Driver).ExecuteScript(script, args);
        }

        public static string GetAlertText()
        {
            string alertText = string.Empty;

            int i = 0;
            while (i++ < 5)
            {
                try
                {
                    alertText = Driver.SwitchTo().Alert().Text;
                    break;
                }
                catch (NoAlertPresentException)
                {
                    Thread.Sleep(2000);
                    continue;
                }
            }

            if (alertText.Equals(string.Empty))
            {
                string exceptionMessage = string.Format("Could not get text from alert");
                throw new Exception(exceptionMessage);
            }

            return alertText;
        }

        public static string GetCurrentURL()
        {
            return Driver.Url;
        }

        public static long GetLastResponseTime()
        {
            return (long)ExecuteJavascript("return performance.timing.loadEventEnd - performance.timing.navigationStart;");
        }

        public static void InitialiseDriver()
        {
            bool initSuccess = false;
            int retries = 0;

            do
            {
                try
                {
                    StartDriver();
                    initSuccess = true;
                }
                catch (WebDriverException ex)
                {
                    if (retries++ >= 3)
                    {
                        throw ex;
                    }
                    else
                    {
                        KillDriver();
                        Thread.Sleep(10000);
                        continue;
                    }                    
                }
            }
            while (initSuccess == false);

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public static void KillDriver()
        {          
            if (Driver != null)
            {
                try
                {
                    Driver.Close();
                    Driver.Quit();                    
                }
                catch (Exception e)
                {
                    TestLogger.LogException(e.Message, e.StackTrace);
                }
                finally
                {
                    Driver = null;
                    KillDriverProcesses();
                }
            }
        }

        public static void LaunchUrl(string url)
        {
            TestLogger.CreateTestStep(string.Concat("Navigating to URL: ", url));
            Driver.Navigate().GoToUrl(url);
        }

        public static void Maximise()
        {
            Driver.Manage().Window.Maximize();
        }

        public static void SwitchWindow()
        {
            string initialHandle = Driver.CurrentWindowHandle;

            int i = 0;
            while (i++ < 5)
            {
                try
                {
                    int lastIndex = Driver.WindowHandles.Count - 1;
                    Driver.SwitchTo().Window(Driver.WindowHandles[lastIndex]);

                    if (Driver.CurrentWindowHandle.Equals(initialHandle) 
                        && Driver.WindowHandles.Count > 1)
                    {
                        Thread.Sleep(2000);
                        continue;
                    }
                    return;
                }
                catch (NoSuchWindowException)
                {
                    Thread.Sleep(2000);
                    continue;
                }
            }

            string exceptionMessage = string.Format("Could not switch window");
            throw new Exception(exceptionMessage);            
        }

        public static void WaitUntilURLContains(string url)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(url));
        }

        private static ChromeOptions BuildChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();

            if (TestRun.SelectedPlatform.Equals(WebPlatformType.DESKTOP))
            {
                options.AddArguments("--start-maximized");
            }
            else if (TestRun.SelectedPlatform.Equals(WebPlatformType.MOBILE))
            {
                //Set to iPhone 6 Plus dimensions
                options.AddArguments("--window-size=414,736");
            }

            options.AddArguments("--whitelisted-ips");

            return options;
        }


        private static void KillDriverProcesses()
        {
            //IF RELEASE
#if (!DEBUG)
            //There is an issue where driver denies the Agent access to the EPC/bin folder,
            //thus preventing it from building after a test suite has finished. This will 
            //ensure that any left over driver processes or sessions are killed so that the agent
            //can execute a successful clean & build

            if (TestRun.GetSelectedBrowser().Equals(BrowserType.CHROME))
            {
                KillProcess("chromedriver.exe");
                KillProcess("chrome.exe");
            }
            else if (TestRun.GetSelectedBrowser().Equals(BrowserType.FIREFOX))
            {
                KillProcess("firefox.exe");
                KillProcess("geckodriver.exe");
            }
            else if (TestRun.GetSelectedBrowser().Equals(BrowserType.IE))
            {
                KillProcess("iexplore.exe");
                KillProcess("IEDriverServer.exe");
            }
            else if (TestRun.GetSelectedBrowser().Equals(BrowserType.EDGE))
            {
                KillProcess("MicrosoftWebDriver.exe");
            }
#endif
        }

#if (!DEBUG)
        private static void KillProcess(string processName)
        {
            string argument = string.Format("taskkill /F /IM {0}", processName);
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/C " + argument);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = true;

            Process process = Process.Start(processInfo);
        }
#endif
        private static void SetWindowSize()
        {
            //Not including chrome driver, window is size is determined by the chrome options parameter passed into the contructor

            if (TestRun.SelectedPlatform.Equals(WebPlatformType.DESKTOP))
            {
                Driver.Manage().Window.Maximize();
            }
            else if (TestRun.SelectedPlatform.Equals(WebPlatformType.MOBILE))
            {
                //Set to iPhone 6 Plus dimensions
                Driver.Manage().Window.Size = new Size(414, 736);
            }
        }

        private static void StartChromeDriver()
        {
            ChromeOptions options = BuildChromeOptions();
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.Port = 4444;

            Driver = new ChromeDriver(service, options);
        }

        private static void StartEdgeDriver()
        {
            EdgeOptions options = new EdgeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;

            Driver = new EdgeDriver();
        }

        private static void StartIEDriver()
        {
            //*** DO NOT DELETE ***//
            //There seems to be an issue with the IE Driver where by it must be provided a default url 
            //or any interactions with controls thrown an exception
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.InitialBrowserUrl = "http://www.google.co.uk";
            //********************//

            options.BrowserAttachTimeout = TimeSpan.FromSeconds(120);

            Driver = new InternetExplorerDriver(options);
        }

        private static void StartFirefoxDriver()
        {
            Driver = new FirefoxDriver();
        }

        private static void StartDriver()
        {
            if (TestRun.GetSelectedBrowser().Equals(BrowserType.CHROME))
            {
                StartChromeDriver();
            }
            else if (TestRun.GetSelectedBrowser().Equals(BrowserType.FIREFOX))
            {
                StartFirefoxDriver();
                SetWindowSize();
            }
            else if (TestRun.GetSelectedBrowser().Equals(BrowserType.IE))
            {
                StartIEDriver();
                SetWindowSize();
            }
            else if (TestRun.GetSelectedBrowser().Equals(BrowserType.EDGE))
            {
                StartEdgeDriver();
                SetWindowSize();
            }
            else
            {
                string exceptionMessage = string.Format("Browser '{0}' is not recognised, please use one of the supported browser types (chrome, firefox, ie or edge)", TestRun.GetSelectedBrowser());
                throw new Exception(exceptionMessage);
            }
        }
    }
}