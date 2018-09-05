namespace TVSLSL.Automation.Common.Applications.Pages.WebElements
{
    using Common;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Threading;
    using TVSLSL.Automation.Common.Tests;
    using TVSLSL.Automation.Common.Tests.Utilities;
    using TVSLSL.Automation.Common.Web;

    public class DropDown : Element
    {
        public DropDown(string elementName, By locator, string pageName, string frame = "") : base(elementName, locator, pageName, frame) { }

        public string GetSelectedItemText()
        {
            SelectElement selectDropdown = new SelectElement(FindWebElement(true));

            return selectDropdown.SelectedOption.GetAttribute("innerText").Trim();
        }

        public string GetSelectedItemValue()
        {
            SelectElement selectDropdown = new SelectElement(FindWebElement(true));

            return selectDropdown.SelectedOption.GetAttribute("value");
        }

        public void SelectDropDownOptionByIndex(int index)
        {
            SelectDropDownOption("By Index", index.ToString());
        }

        public void SelectDropDownOptionByText(string text)
        {
            SelectDropDownOption("By Text", text);
        }

        public void SelectDropDownOptionByValue(string value)
        {
            SelectDropDownOption("By Value", value);
        }

        private void SelectDropDownOption(string selectType, string option)
        {
            string actionDescription = string.Format("Select Drop Down Option \"{0}\" ({1})",  option, selectType);
            string stepDescription = TestLogger.CreateTestStep(actionDescription, name, pageName);

            int attempts = 0;

            while (attempts <= 3)
            {
                try
                {
                    SelectElement dropDown = new SelectElement(FindWebElement());

                    switch (selectType)
                    {
                        case "By Index":
                            dropDown.SelectByIndex(int.Parse(option));
                            break;
                        case "By Text":
                            dropDown.SelectByText(option);
                            break;
                        case "By Value":
                            dropDown.SelectByValue(option);
                            break;
                        default:
                            throw new Exception("Could not find valid drop down select type");
                    }

                    break;
                }
                catch (Exception ex)
                {
                    attempts += 1;

                    if (ex.Message.Contains("is not clickable at point") &&
                        attempts < 3)
                    {
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
    }
}