namespace TVSLSL.Automation.Common.Applications.Pages.WebElements
{
    using Common;
    using OpenQA.Selenium;

    public class Button : Element
    {
        public Button(string elementName, By locator, string pageName, string frame = "") : base(elementName, locator, pageName, frame) { }
    }
}
