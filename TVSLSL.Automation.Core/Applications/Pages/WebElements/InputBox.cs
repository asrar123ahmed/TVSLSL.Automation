namespace TVSLSL.Automation.Common.Applications.Pages.WebElements
{
    using Common;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using System;
    using System.Threading;
    using Tests.Utilities;
    using TVSLSL.Automation.Common.Web;

    public class InputBox : Element
    {
        public InputBox(string elementName, By locator, string pageName, string frame = "") : base(elementName, locator, pageName, frame) { }

        public void ClearText()
        {
            string stepDescription = TestLogger.CreateTestStep("Clear Text", name, pageName);

            try
            {
                FindWebElement(false).Clear();
            }
            catch (Exception ex)
            {
                TestHelper.HandleException(stepDescription, ex);
            }
        }

        public void InputText(string text, bool pressReturn = false)
        {
            string actionDescription = string.Empty;

            if (name.ToLower().Contains("password"))
            {
                actionDescription = string.Format("Input Text \"{0}\"", "*****************");
            }
            else
            {
                actionDescription = string.Format("Input Text \"{0}\"", text);
            }

            string stepDescription = TestLogger.CreateTestStep(actionDescription, name, pageName);

            int attempts = 0;

            while (attempts <= 3)
            {
                IWebElement webElement = null;

                try
                {
                    webElement = FindWebElement(false);
                    webElement.SendKeys(text);                   

                    if (pressReturn)
                    {
                        PressReturn();
                    }

                    break;
                }
                catch (Exception ex)
                {
                    attempts += 1;

                    if (ex.Message.Contains("is not reachable by keyboard")
                        || ex.Message.Contains("The element is not focusable")
                        || ex.Message.Contains("cannot focus element")
                        || ex.Message.Contains("Element cannot be interacted with")
                        && attempts < 4)
                    {
                        MoveElementToMiddleOfPage(webElement);
                        Thread.Sleep(5000);
                        continue;
                    }
                    else
                    {
                        TestHelper.HandleActionOrAssertionException(stepDescription, ex);
                    }
                }
            }
        }

        public void InputTextByCoordinates(string text, bool pressReturn = false)
        {
            string actionDescription = string.Empty;

            if (name.ToLower().Contains("password"))
            {
                actionDescription = string.Format("Input Text \"{0}\"", "*****************");
            }
            else
            {
                actionDescription = string.Format("Input Text \"{0}\"", text);
            }

            string stepDescription = TestLogger.CreateTestStep(actionDescription, name, pageName);

            try
            {
                IWebElement element = FindWebElement();
                new Actions(WebDriverHelper.Driver).MoveToElement(element).MoveByOffset(0, 0).SendKeys(text).Build().Perform();

                if (pressReturn)
                {
                    PressReturn();
                }
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDescription, ex);
            }
        }

        public void InputTextKeyByKey(string text, bool pressReturn = false)
        {
            string actionDescription = string.Empty;

            if (name.ToLower().Contains("password"))
            {
                actionDescription = string.Format("Input Text (Key-by-Key) \"{0}\"", "*****************");
            }
            else
            {
                actionDescription = string.Format("Input Text (Key-by-Key) \"{0}\"", text);
            }
 
            string stepDescription = TestLogger.CreateTestStep(actionDescription, name, pageName);

            try
            {
                IWebElement textBox = FindWebElement(false);

                char[] characters = text.ToCharArray();

                foreach (char character in characters)
                {
                    textBox.SendKeys(character.ToString());
                    Thread.Sleep(500);
                }

                if (pressReturn)
                {
                    PressReturn();
                }
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDescription, ex);
            }
        }

        private void PressReturn()
        {
            TestLogger.CreateTestStep("Press Return Key");

            try
            {
                Thread.Sleep(2000); //Wait for the text to be inputted
                FindWebElement(true).SendKeys(Keys.Enter);                
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException("Press Return Key", ex);
                throw;
            }
        }
    }
}
