namespace TVSLSL.Automation.Common.Applications.Pages.WebElements
{
    using Common;
    using OpenQA.Selenium;

    public class Icon : Element
    {
        public Icon(string elementName, By locator, string pageName, string frame = "") : base(elementName, locator, pageName, frame) { }
    }
}
