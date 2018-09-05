namespace TVSLSL.Automation.Common.Applications.Pages.WebElements.Common
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using TVSLSL.Automation.Common.Tests;
    using TVSLSL.Automation.Common.Tests.Utilities;
    using TVSLSL.Automation.Common.Web;

    public abstract class Element
    {
        protected By locator;

        protected string frame;
        protected string name;
        protected string pageName;

        public Element(string elementName, By locator, string pageName, string frame = "")
        {
            this.frame = frame;
            this.name = elementName;
            this.pageName = pageName;

            this.locator = locator;
        }

        public Element()
        {
            //To be used when the child contructors dont want to the call base contructor 
        }

        public string Name
        {
            get { return name; }
        }

        public string PageName
        {
            get { return pageName; }
        }

        public void AssertElementIsDisplayed()
        {
            string stepDecription = TestLogger.CreateTestStep("Assert Element is Displayed", name, pageName);
            IWebElement webElement = null;

            try
            {
                webElement = FindWebElement();
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            Asserter.AssertThat(webElement.Displayed, Is.True, stepDecription, false);            
        }

        public void AssertElementIsEnabled()
        {
            string stepDecription = TestLogger.CreateTestStep("Assert Element is Enabled", name, pageName);
            IWebElement webElement = null;

            try
            {
                webElement = FindWebElement();
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            Asserter.AssertThat(webElement.Enabled, Is.True, stepDecription, false);
        }

        public void AssertElementIsNotDisplayed()
        {
            string stepDecription = TestLogger.CreateTestStep("Assert Element is Not Displayed", name, pageName);

            bool elementFound = false;

            try
            {
                IWebElement webElement = FindWebElement();      
                elementFound = true;
            }
            catch (NoSuchElementException)
            {
                //Swallow exception - We expect FindElement() to throw NoSuchElementException if 
                //no web elements in the DOM match the By search query
            }
            catch (Exception ex)
            {
                //Throw any other unexpected exception types
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            Asserter.AssertThat(elementFound, Is.False, stepDecription, false);
        }

        public void AssertElementIsNotEnabled()
        {
            string stepDecription = TestLogger.CreateTestStep("Assert Element is Not Enabled", name, pageName);
            IWebElement webElement = null;

            try
            {
                webElement = FindWebElement();                
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            Asserter.AssertThat(webElement.Enabled, Is.False, stepDecription, false);        
        }

        public void AssertElementIsNotEditable()
        {
            string stepDecription = TestLogger.CreateTestStep("Assert Element is Not Editable", name, pageName);

            IWebElement element = null;
            string disabledAttribute = string.Empty;

            try
            {
                element = WebDriverHelper.Driver.FindElement(locator);
                disabledAttribute = element.GetAttribute("disabled");
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            bool isDisabled = bool.Parse(disabledAttribute);
            Asserter.AssertThat(isDisabled, Is.True, stepDecription, false);            
        }

        public void AssertElementAttributeContains(string attribute, string containsText)
        {
            string actionDescription = string.Format("Assert Element Attribute {0} Contains '{1}'", attribute, containsText);
            string stepDecription = TestLogger.CreateTestStep(actionDescription, name, pageName);
            string elementAttribute = string.Empty;

            try
            {
                elementAttribute = FindWebElement().GetAttribute(attribute);
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            Asserter.AssertThat(elementAttribute, Does.Contain(containsText), stepDecription, false);
        }

        public void AssertElementAttributeMatches(string attribute, string pattern)
        {
            string actionDescription = string.Format("Assert Element Text Matches Regex Pattern '{0}'", pattern);
            string stepDecription = TestLogger.CreateTestStep(actionDescription, name, pageName);

            string attributeValue = string.Empty;
            Regex regex = null;

            try
            {
                attributeValue = FindWebElement().GetAttribute(attribute);
                regex = new Regex(pattern);
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            bool matches = regex.IsMatch(attributeValue);
            Asserter.AssertThat(matches, Is.True, stepDecription, false);            
        }

        public void AssertElementHasAttribute(string attribute)
        {
            string actionDescription = string.Format("Assert Element Has Attribute '{0}'", attribute);
            string stepDecription = TestLogger.CreateTestStep(actionDescription, name, pageName);

            bool hasAttribute = false;

            try
            {
                string attributeValue = FindWebElement().GetAttribute(attribute);
                hasAttribute = (attribute != null);
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            Asserter.AssertThat(hasAttribute, Is.True, stepDecription, false);
        }

        public void AssertElementTextContains(string contains, bool caseSensitive = true)
        {
            string actionDescription = string.Format("Assert Element Text Contains '{0}'", contains);
            string stepDecription = TestLogger.CreateTestStep(actionDescription, name, pageName);
            string elementText = string.Empty;

            try
            {
                elementText = FindWebElement().Text;
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            if (caseSensitive)
            {
                Asserter.AssertThat(elementText, Does.Contain(contains), stepDecription, false);
            }
            else
            {
                Asserter.AssertThat(elementText, Does.Contain(contains).IgnoreCase, stepDecription, false);
            }
        } 

        public void AssertElementTextEquals(string expectedText, bool caseSensitive = true)
        {
            string actionDescription = string.Format("Assert Element Text Equals '{0}'", expectedText);
            string stepDecription = TestLogger.CreateTestStep(actionDescription, name, pageName);
            string actualText = string.Empty;

            try
            {
                actualText = FindWebElement().Text;
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }
            if (caseSensitive)
            {
                Asserter.AssertThat(actualText, Is.EqualTo(expectedText), stepDecription, false);
            }
            else
            {
                Asserter.AssertThat(actualText, Is.EqualTo(expectedText).IgnoreCase, stepDecription, false);
            }
        }

        public void AssertElementTextDoesNotContain(string containsText)
        {
            string actionDescription = string.Format("Assert Element Text Does Not Contain '{0}'", containsText);
            string stepDecription = TestLogger.CreateTestStep(actionDescription, name, pageName);
            string actualtext = string.Empty;

            try
            {
                actualtext = FindWebElement().Text;               
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            Asserter.AssertThat(actualtext, Does.Not.Contain(containsText), stepDecription, false);           
        }

        public void AssertElementTextContainsAlphaNumericCharacters()
        {
            string stepDecription = TestLogger.CreateTestStep("Assert Element Text Contains Alpha Numeric Characters", name, pageName);
            string actualtext = string.Empty;

            try
            {               
                actualtext = FindWebElement().Text;               
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            bool containsAlphaNumericCharacters = actualtext.Any(char.IsLetterOrDigit);

            Asserter.AssertThat(containsAlphaNumericCharacters, Is.True, stepDecription, false);
        }

        public void AssertElementTextContainsNumericCharacters()
        {
            string stepDecription = TestLogger.CreateTestStep("Assert Element Text Contains Numeric Characters", name, pageName);
            string actualtext = string.Empty;

            try
            {
                actualtext = FindWebElement().Text;
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            bool containsNumericCharacters = actualtext.Any(char.IsDigit);
            Asserter.AssertThat(containsNumericCharacters, Is.True, stepDecription, false);
        }

        public void AssertElementTextContainsValidDateFormat(string dateFormat)
        {
            string actionDescription = string.Format("Assert Element Text Contains Date Format : {0}", dateFormat);
            string stepDescription = TestLogger.CreateTestStep(actionDescription, name, pageName);           
            
            try
            {
                DateTime dateTimeOut = DateTime.Now;

                CultureInfo provider = CultureInfo.InvariantCulture;
                bool matchesFormat = DateTime.TryParseExact(FindWebElement().Text,
                                                            dateFormat,
                                                            provider,
                                                            DateTimeStyles.None, out dateTimeOut);
                Asserter.AssertThat(matchesFormat, Is.True, stepDescription, false);
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDescription, ex);
            }
        }

        public void AssertElementTextIsPopulted()
        {
            string stepDecription = TestLogger.CreateTestStep("Assert Element Text Is Populated", name, pageName);
            string actualtext = string.Empty;

            try
            {
                actualtext = FindWebElement().Text;
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            actualtext = actualtext.Replace(" ", string.Empty);
            Asserter.AssertThat(actualtext.Length > 0, Is.True, stepDecription, false);
        }

        public void AssertElementTextMatches(string pattern)
        {
            string actionDescription = string.Format("Assert Element Text Matches Regex Pattern '{0}'", pattern);
            string stepDecription = TestLogger.CreateTestStep(actionDescription, name, pageName);
            bool matches = false;

            try
            {
                Regex regex = new Regex(pattern);
                matches = regex.IsMatch(FindWebElement().Text);                
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            Asserter.AssertThat(matches, Is.True, stepDecription, false);
        }

        public void AssertElementValueEquals(string expectedValue)
        {
            string actionDescription = string.Format("Assert Element Value Equals '{0}'", expectedValue);
            string stepDecription = TestLogger.CreateTestStep(actionDescription, name, pageName);
            string actualText = string.Empty;

            try
            {
                actualText = FindWebElement().GetAttribute("value");
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDecription, ex);
            }

            Asserter.AssertThat(actualText, Is.EqualTo(expectedValue), stepDecription, false);
        }

        public void Click()
        {
            string stepDesciption = TestLogger.CreateTestStep("Click", name, pageName);

            IWebElement element = null;
            int attempts = 0;

            while (attempts <= 3)
            {
                try
                {
                    if (TestRun.GetSelectedBrowser().Equals(BrowserType.EDGE))
                    {
                        Thread.Sleep(5000); // Hard coded wait to avoid flakiness of the Driver

                        Actions actions = new Actions(WebDriverHelper.Driver);
                        actions.Click(FindWebElement(true)).Build().Perform();
                    }
                    else
                    {
                        FindWebElement(false).Click();
                    }

                    break;
                }
                catch (Exception ex)
                {
                    attempts += 1;
                    string exceptionMessage = ex.Message.ToLower();

                    if (exceptionMessage.Contains("not clickable at point")
                        && attempts < 4)
                    {
                        try
                        {
                            Thread.Sleep(5000);

                            //Clicks the coordinates of the element;
                            //Note: selenium is unable to click this element the convential way because the control
                            //****  is overlapped. 
                            element = FindWebElement(false);
                            new Actions(WebDriverHelper.Driver).MoveToElement(element).Click().Build().Perform();
                            break;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    else if((exceptionMessage.Contains("could not be scrolled into view")))
                    {
                        try
                        {
                            MoveElementToMiddleOfPage(element);
                            new Actions(WebDriverHelper.Driver).MoveToElement(element).MoveByOffset(0, 0).Click().Build().Perform();
                        }
                        catch
                        {
                            Thread.Sleep(5000);
                            continue;
                        }

                    }
                    else if((exceptionMessage.Contains("element is no longer valid")
                            || exceptionMessage.Contains("element is not displayed")
                            || exceptionMessage.Contains("element is not attached to the page document")
                            || exceptionMessage.Contains("element not visible")
                            || exceptionMessage.Contains("no such element")
                            || exceptionMessage.Contains("unknown error")) 
                            && attempts < 4)
                    {
                        Thread.Sleep(5000);                        
                        continue;
                    }
                    else
                    {
                        TestHelper.HandleActionOrAssertionException(stepDesciption, ex);
                    }                    
                }
            }
        }

        public void DoubleClick()
        {
            string stepDesciption = TestLogger.CreateTestStep("Double Click", name, pageName);

            try
            {
                Actions action = new Actions(WebDriverHelper.Driver);
                action.DoubleClick(FindWebElement(true));
                action.Perform();
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDesciption, ex);
            }
        }

        public bool ExistsInDOM()
        {
            return GetElementCount() > 0;
        }

        public static bool ExistsInDOM(By locator)
        {
            return WebDriverHelper.Driver.FindElements(locator).Count > 0;
        }

        public string GetElementAttribute(string attributeType)
        {
            string attributeValue = string.Empty;

            try
            {
                attributeValue = FindWebElement().GetAttribute(attributeType);
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(TestLogger.CurrentTestStep.Description, ex);
            }

            return attributeValue;
        }

        public int GetElementCount()
        {
            int? count = null;

            try
            {
                count = FindElementsByLocator().Count;
            }
            catch (Exception ex)
            {
                string stepDesciption = TestLogger.CreateTestStep("Get Element Count", name, pageName);
                TestHelper.HandleActionOrAssertionException(TestLogger.CurrentTestStep.Description, ex);
            }

            return count.Value;
        }

        public string GetElementText()
        {
            string text = string.Empty;

            try
            {
                text = FindWebElement().Text;
            }
            catch (Exception ex)
            {
                string stepDesciption = TestLogger.CreateTestStep("Get Element Text", name, pageName);
                TestHelper.HandleActionOrAssertionException(TestLogger.CurrentTestStep.Description, ex);
            }

            return text;
        }

        public string GetElementValue()
        {
            return GetElementAttribute("value");
        }

        public string GetInnerHtml()
        {
            string html = string.Empty;

            try
            {
                html = FindWebElement().GetAttribute("innerHTML");
            }
            catch (Exception ex)
            {
                string stepDesciption = TestLogger.CreateTestStep("Get inner html", name, pageName);
                TestHelper.HandleActionOrAssertionException(TestLogger.CurrentTestStep.Description, ex);
            }

            return html;
        }

        public bool HasAttributeThatContainsValue(string attribute, string value)
        {
            bool hasValue = false;
            string attributeValue = GetElementAttribute(attribute);

            if (attributeValue != null &&
                attributeValue.Contains(value))
            {
                hasValue = true;
            }

            return hasValue;
        }

        public bool HasAttributeWithValue(string attribute, string value)
        {
            bool hasValue = false;
            string attributeValue = GetElementAttribute(attribute);

            if (attributeValue != null &&
                attributeValue.Equals(value))
            {
                hasValue = true;
            }

            return hasValue;
        }

        public bool IsVisible()
        {
            bool visible = false;

            try
            {
                FindWebElement();
                visible = true;
            }
            catch (NoSuchElementException)
            {
                // Do nothing - We expect this exception type if element is not found
            }
            catch (Exception ex) //Throw all other exception types
            {
                TestHelper.HandleActionOrAssertionException(TestLogger.CurrentTestStep.Description, ex);
            }

            return visible;
        }

        public void MoveToElement()
        {
            string stepDesciption = TestLogger.CreateTestStep("Move To Element", name, pageName);
            IWebElement webElement = null;

            try
            {
                webElement = FindWebElement();

                Actions builder = new Actions(WebDriverHelper.Driver);
                builder.MoveToElement(webElement).Perform();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("is out of bounds of viewport width"))
                {
                    MoveElementToMiddleOfPage(webElement);
                }
                else
                {
                    TestHelper.HandleActionOrAssertionException(stepDesciption, ex);
                }
            }

            //Wait until element has been moved into view
            Thread.Sleep(2000);
        }       

        public void MoveToElementAndClick()
        {
            MoveToElement();
            Thread.Sleep(2000);
            Click();
        }     

        public void WaitForElementToBeClickable()
        {
            string stepDescription = TestLogger.CreateTestStep("Wait For Element To Be Displayed And Enabled", name, pageName);

            try
            {
                WaitUntilElementIsClickable();
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDescription, ex);
            }
        }

        public void WaitForElementToBeVisible()
        {
            string stepDescription = TestLogger.CreateTestStep("Wait For Element To Be Displayed", name, pageName);

            try
            {
                WaitUntilElementIsVisible();
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDescription, ex);
            }
        }

        public void WaitUntilElementIsNotVisible()
        {
            string stepDescription = TestLogger.CreateTestStep("Wait Until Element Is Not Displayed", name, pageName);

            try
            {
                WaitUntil(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDescription, ex);
            }
        }

        public void WaitUntilElementTextEquals(string text)
        {
            string actionDescription = string.Format("Wait Until Element Text Equals '{0}'", text);
            string stepDescription = TestLogger.CreateTestStep(actionDescription, name, pageName);

            try
            {
                Func<IWebDriver, bool> condition = SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(locator, text);
                WaitUntil(condition, 30);
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDescription, ex);
            }
        }

        public void WaitUntilElementValueEquals(string text)
        {
            string stepDescription = TestLogger.CreateTestStep("Wait Until Element Value Equals", name, pageName);

            try
            {
                WaitUntil(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(locator, text));
            }
            catch (Exception ex)
            {
                TestHelper.HandleActionOrAssertionException(stepDescription, ex);
            }
        }

        protected void SwitchToFrame()
        {         
            if (frame.StartsWith("Index:"))
            {
                frame = frame.Replace("Index:", string.Empty);
                int frameIndex = int.Parse(frame);

                WebDriverHelper.Driver.SwitchTo().Frame(frameIndex);
            }
            else if (frame.StartsWith("//"))
            {
                SwitchToFrameByXpath();
            }
            else
            {
                WebDriverHelper.Driver.SwitchTo().Frame(frame);
            }
        }
        
        protected void SwitchToFrameByXpath()
        {
            IWebElement iFrame = FindWebElement();
            WebDriverHelper.Driver.SwitchTo().Frame(iFrame);
        }

        protected void WaitUntil(Func<IWebDriver, IWebElement> condition, int timeoutSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(WebDriverHelper.Driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(condition);
        }

        protected void WaitUntil(Func<IWebDriver, bool> condition, int timeoutSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(WebDriverHelper.Driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(condition);
        }

        private ReadOnlyCollection<IWebElement> FindElementsByLocator()
        {
            // Always start from default content...
            WebDriverHelper.Driver.SwitchTo().DefaultContent();

            if (frame.Length > 0)
            {
                SwitchToFrame();
            }            

            return WebDriverHelper.Driver.FindElements(locator);
        }

        protected IWebElement FindWebElement(bool waitUntilVisible = true)
        {
            WaitUntilDocumentHasFullyLoaded();
            
            // Always start from default content...
            WebDriverHelper.Driver.SwitchTo().DefaultContent();

            if (frame.Length > 0)
            {
                SwitchToFrame();
            }

            if (waitUntilVisible)
            {
                WaitUntilElementIsVisible();                
            }

            return FindWebElement();
        }

        protected void MoveElementToMiddleOfPage(IWebElement element)
        {
            //scroll element to middle of the page
            string script = "var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);" +
                            "var elementTop = arguments[0].getBoundingClientRect().top;" +
                            "window.scrollBy(0, elementTop-(viewPortHeight/2));";

            WebDriverHelper.ExecuteJavascript(script, element);
        }

        private IWebElement FindWebElement()
        {
            IWebElement element = null;
            int retries = 0;

            while (retries < 3)
            {
                try
                {
                    element = WebDriverHelper.Driver.FindElement(locator);
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    Thread.Sleep(5000);
                    retries += 1;
                    continue;
                }
            }  

            return element;
        }       

        private void WaitUntilElementIsClickable()
        {                  
            WaitUntil(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));              
        }

        private void WaitUntilElementIsVisible()
        {
            WaitUntil(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        private void WaitUntilDocumentHasFullyLoaded()
        {
            try
            {
                //Selenium webdriver executes to quickly at times, this method will ensure that
                //the page has always been fully loaded before each action
                WaitUntil(wd => WebDriverHelper.ExecuteJavascript("return document.readyState").ToString() == "complete");
            }
            catch
            {
                //Swallow exception - ignore exceptions thrown by Javascript
            }
        }
    }
}
