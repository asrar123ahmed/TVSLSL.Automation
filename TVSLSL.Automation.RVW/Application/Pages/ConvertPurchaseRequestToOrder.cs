﻿namespace TVSLSL.Automation.RVW.Application.Pages
{
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Applications.Pages;
    using TVSLSL.Automation.Common.Applications.Pages.WebElements;
    using TVSLSL.Automation.Common.Web;
    using TVSLSL.Automation.RVW.Application.Pages.Sections;

    public class ConvertPurchaseRequestToOrder : Page
    {
        private string iframe;        

        public ConvertPurchaseRequestToOrder()
        {
            InitialisePage();
        } 

        public Button ConvertPRGoBackBtn { get; private set; }
        
        public Button CreateOrderDoc { get; private set; }

        public Button CreateOrderPopupClose { get; private set; }

        public InputBox PRNumberFrom { get; private set; }

        public InputBox PRNumberTo { get; private set; }

        public Button Search { get; private set; }  
        
        public InputBox SupplierCode { get; private set; }

        public ConvertPRToOrderItemRow GetItemRow(int index)
        {
            return new ConvertPRToOrderItemRow(index);
        }
        
        private void InitialisePage()
        {
            iframe = "ilboinnerframe";

            ConvertPRGoBackBtn = new Button("Go Back button", By.Id("ext-gen848"), name);
            CreateOrderDoc = new Button("Create Order Doc", By.XPath("//button[@id='ext-gen64'][@tabindex='27']"), name, iframe);
            CreateOrderPopupClose = new Button("Create Order Popup Close", By.Id("ext-gen1162"), name);
            PRNumberFrom = new InputBox("PR Number From", By.Id("txtprnofrom"), name, iframe);
            PRNumberTo = new InputBox("PR Number To", By.XPath("//input[@id='txttoprno']"), name, iframe);
            Search = new Button("Search", By.Id("ext-gen57"), name, iframe);
            SupplierCode = new InputBox("Supplier Code", By.Id("txtsuppliercode"), name, iframe);
        }
    }
}
