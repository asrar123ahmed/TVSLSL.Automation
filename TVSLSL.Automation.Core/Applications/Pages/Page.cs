namespace TVSLSL.Automation.Common.Applications.Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System.Threading;
    using Tests.Utilities;
    using Web;

    public abstract class Page
    {
        protected string name;

        protected Page()
        {
            name = GetType().Name;
        }

        public string Name
        {
            get { return name; }
        }

        public void AssertTitleIsCorrect(string expectedTitle)
        {
            string stepDescription = string.Format("Assert page title equals '{0}'", expectedTitle);

            string actualTitle = GetTitle();
            Asserter.AssertThat(actualTitle, Is.EqualTo(expectedTitle), stepDescription);
        }

        public void AssertUrlContains(string expectedUrl)
        {
            string stepDescription = string.Format("Assert URL contains '{0}'", expectedUrl);

            string actualUrl = GetCurrentUrl();
            Asserter.AssertThat(actualUrl, Does.Contain(expectedUrl), stepDescription);
        }

        public void AssertUrlEquals(string expectedUrl)
        {
            string stepDescription = string.Format("Assert URL equals '{0}'", expectedUrl);

            string actualUrl = GetCurrentUrl();
            Asserter.AssertThat(actualUrl, Is.EqualTo(expectedUrl), stepDescription);
        }

        public void NavigateBack()
        {
            // Move back a single entry in the browser's history.
            WebDriverHelper.Driver.Navigate().Back();
        }

        public void NavigateForward()
        {
            // Does nothing if we are on the latest page viewed.
            WebDriverHelper.Driver.Navigate().Forward();
        }

        public void RefreshPage()
        {
            WebDriverHelper.Driver.Navigate().Refresh();
        }

        public void ScrollDown()
        {
            WebDriverHelper.ExecuteJavascript("window.scrollTo(0, document.body.scrollHeight - 150)");
        }

        public void WaitSeconds(string seconds)
        {
            Thread.Sleep(int.Parse(seconds) * 1000);
        }

        public void WaitSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        private string GetCurrentUrl()
        {
            return WebDriverHelper.Driver.Url;
        }

        private string GetTitle()
        {
            return WebDriverHelper.Driver.Title;
        }
    }
}