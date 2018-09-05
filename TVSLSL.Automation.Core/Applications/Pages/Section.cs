using OpenQA.Selenium;
using System.Threading;

namespace TVSLSL.Automation.Common.Applications.Pages
{
    public class Section
    {
        protected string name;

        protected Section()
        {
            name = GetType().Name;
        }

        protected By BuildDynamicLocator(string xpath, params object[] args)
        {
            string locator = string.Format(xpath, args);
            return By.XPath(locator);
        }

        protected void WaitSeconds(string seconds)
        {
            Thread.Sleep(int.Parse(seconds) * 1000);
        }

        protected void WaitSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }
    }
}