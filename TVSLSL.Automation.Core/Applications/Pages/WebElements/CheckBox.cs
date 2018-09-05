namespace TVSLSL.Automation.Common.Applications.Pages.WebElements
{
    using Common;
    using OpenQA.Selenium;
    using System;
    using Tests.Utilities;

    public class CheckBox : Element
    {
        public CheckBox(string elementName, By locator, string pageName, string frame = "") : base(elementName, locator, pageName, frame) { }

        public void Check()
        {
            if (IsSelected())
            {
                // do nothing
            }
            else
            {
                Click();
            }
        }

        public bool IsSelected()
        {
            bool selected = false;

            try
            {
                IWebElement element = FindWebElement();
                selected = element.Selected;
            }
            catch (Exception ex)
            {
                string stepDesciption = TestLogger.CreateTestStep("Is Selected", name, pageName);
                TestHelper.HandleActionOrAssertionException(TestLogger.CurrentTestStep.Description, ex);
            }

            return selected;
        }

        public void UnCheck()
        {
            if (IsSelected())
            {
                Click();
            }
        }
    }
}
