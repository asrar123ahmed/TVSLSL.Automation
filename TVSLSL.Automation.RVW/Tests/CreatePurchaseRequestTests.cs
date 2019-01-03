namespace TVSLSL.Automation.RVW.Tests
{
    using Common;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Tests.Utilities;
    using TVSLSL.Automation.RVW.Application;

    public class CreatePurchaseRequestTests : RVWTests
    {
        [Test]
        [Category("TestUserGroup")]
        [Order(1)]

        public void CreatePR()
        {
            //Test to verify that user able to create purchase request

            string needDate = TestHelper.GetTodaysDate("dd/MM/yyyy", 1);

            RVWWebApp.Login.SignIntoAccountWIthTestUser();
            RVWWebApp.SelfServiceHome.HeaderSearchBox.InputTextKeyByKey("Create Purchase Request");
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.FirstHeaderSearchSuggestionOption.Click();
            WaitSeconds(5);

            RVWWebApp.CreatePurchaseRequest.Type.ClearText();
            RVWWebApp.CreatePurchaseRequest.Type.InputText("GENERAL", true);
            RVWWebApp.CreatePurchaseRequest.RequesterId.InputText("034743", true);            
            RVWWebApp.CreatePurchaseRequest.ProposalNumber.InputText("");

            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).ItemCode.Click();
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).ItemCode.InputTextByCoordinates("SERCHA1MPCOM259");
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).ItemCode.InputTextByCoordinates(Keys.Enter);
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).RequiredQuantity.Click();
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).RequiredQuantity.InputTextByCoordinates("1");
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).RequiredQuantity.InputTextByCoordinates(Keys.Enter);
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).Cost.Click();
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).Cost.InputTextByCoordinates("125");
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).Cost.InputTextByCoordinates(Keys.Enter);
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).NeedDate.Click();
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).NeedDate.InputTextByCoordinates(needDate);
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).PreferredSupplierCode.Click();
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).PreferredSupplierCode.InputTextByCoordinates("SIFEXTARK1");
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).PreferredSupplierCode.InputTextByCoordinates(Keys.Enter);
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).ACUsage.Click();
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).ACUsage.InputTextByCoordinates("ISPCHARG");
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).ACUsage.InputTextByCoordinates(Keys.Enter);

            RVWWebApp.CreatePurchaseRequest.Default.Click();
            WaitSeconds(3);

            RVWWebApp.CreatePurchaseRequest.CreatePurchaseReq();
            RVWWebApp.CreatePurchaseRequest.PRCreatePopupClose.Click();
            RVWWebApp.CreatePurchaseRequest.PRAdditionalDetails.Click();
            WaitSeconds(5);

            string pRNumber = RVWWebApp.PRAdditionalDetails.PRNumber.GetElementText();
            WaitSeconds(5);
            RVWWebApp.PRAdditionalDetails.LineOfBusiness.InputTextKeyByKey("Intra Company", true);
            WaitSeconds(3);
            RVWWebApp.PRAdditionalDetails.ProjectName.InputTextKeyByKey("3PL General Expenses", true);
            WaitSeconds(3);
            RVWWebApp.PRAdditionalDetails.ProjectLocation.InputTextKeyByKey("MUMBHITVSWHA1", true);
            WaitSeconds(3);
            RVWWebApp.PRAdditionalDetails.GetItemRow(1).MassCheck.Check();
            RVWWebApp.PRAdditionalDetails.GetItemRow(1).BillToCustomer.Click();
            RVWWebApp.PRAdditionalDetails.GetItemRow(1).BillToCustomer.InputTextByCoordinates("No");
            RVWWebApp.PRAdditionalDetails.GetItemRow(1).BudgetDeviation.Click();
            RVWWebApp.PRAdditionalDetails.GetItemRow(1).BudgetDeviation.InputTextByCoordinates("No");
            RVWWebApp.PRAdditionalDetails.Save.Click();
            RVWWebApp.PRAdditionalDetails.SavePopupClose.Click();
            RVWWebApp.PRAdditionalDetails.PRAdditionalPageGoBackBtn.Click();
            WaitSeconds(5);

            RVWWebApp.CreatePurchaseRequest.EditPurchaseRequest.Click();
            RVWWebApp.EditPurchaseRequest.EditAndApprovePR.Click();
            WaitSeconds(5);
            RVWWebApp.EditPurchaseRequest.PopupClose.Click();
            RVWWebApp.EditPurchaseRequest.GoBack.Click();
            RVWWebApp.CreatePurchaseRequest.GoBackBtn.Click();
           
            RVWWebApp.SelfServiceHome.HeaderSearchBox.InputTextKeyByKey("View Purchase Request");
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.FirstHeaderSearchSuggestionOption.Click();
            RVWWebApp.ViewPurchaseRequest.PRNumberFrom.InputTextKeyByKey(pRNumber);
            RVWWebApp.ViewPurchaseRequest.PRNumberTo.InputTextKeyByKey(pRNumber);
            RVWWebApp.ViewPurchaseRequest.Search.Click();
            WaitSeconds(20);

            RVWWebApp.ViewPurchaseRequest.GetItemRow(1).PRNumber.AssertElementTextEquals(pRNumber);
        }

        [Test]
        [Category("TestUserGroup")]
        [Order(2)]

        public void CreatePOFromPR()
        {
            //Test to verify that user can create purchase order from the purchase request

            string dateFrom = TestHelper.GetTodaysDate("dd/MM/yyyy");
            string dateTo = TestHelper.GetTodaysDate("dd/MM/yyyy");

            RVWWebApp.Login.SignIntoAccountWIthTestUser();
            RVWWebApp.SelfServiceHome.HeaderSearchBox.InputTextKeyByKey("View Purchase Request");
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.FirstHeaderSearchSuggestionOption.Click();
            WaitSeconds(5);

            RVWWebApp.ViewPurchaseRequest.PRDateFrom.InputText(dateFrom, true);
            RVWWebApp.ViewPurchaseRequest.PRDateTo.InputText(dateTo, true);
            RVWWebApp.ViewPurchaseRequest.Search.Click();
            WaitSeconds(40);

            int totalRow = RVWWebApp.ViewPurchaseRequest.GetTotalRowCount();
            string pRnumber = RVWWebApp.ViewPurchaseRequest.GetItemRow(totalRow).PRNumber.GetElementText();
            RVWWebApp.ViewPurchaseRequest.GoBack.Click();

            RVWWebApp.SelfServiceHome.HeaderSearchBox.InputTextKeyByKey("Convert Purchase Request To Order");
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.FirstHeaderSearchSuggestionOption.Click();
            WaitSeconds(5);

            RVWWebApp.ConvertPurchaseRequestToOrder.PRNumberFrom.InputText(pRnumber);
            RVWWebApp.ConvertPurchaseRequestToOrder.PRNumberTo.InputText(pRnumber);            
            RVWWebApp.ConvertPurchaseRequestToOrder.Search.Click();
            WaitSeconds(40);
            string preferredSupplierCode = RVWWebApp.ConvertPurchaseRequestToOrder.GetItemRow(1).PreferredSupplierCode.GetElementText();          
            RVWWebApp.ConvertPurchaseRequestToOrder.SupplierCode.InputText(preferredSupplierCode);
            RVWWebApp.ConvertPurchaseRequestToOrder.GetItemRow(1).SelectRow.Click();
            RVWWebApp.ConvertPurchaseRequestToOrder.CreateOrderDoc.Click();
            WaitSeconds(5);
                      
            RVWWebApp.ConvertPurchaseRequestToOrder.CreateOrderPopupClose.Click();
            RVWWebApp.ConvertPurchaseRequestToOrder.EditPurchaseRequest.Click();
            string orderNumber = RVWWebApp.EditPurchaseOrder.PONumber.GetElementText();

            //Do Specify Terms And Condition Step
            RVWWebApp.EditPurchaseOrder.SpecifyTermsAndConditions.Click();
            WaitSeconds(5);
            RVWWebApp.SpecifyTermsAndCondition.InsuranceAmount.InputText("0");
            RVWWebApp.SpecifyTermsAndCondition.SpecifyTermsAndConditionBtn.Click();
            WaitSeconds(5);
            RVWWebApp.SpecifyTermsAndCondition.PopupClose.Click();
            RVWWebApp.SpecifyTermsAndCondition.GoBack.Click();

            //Do Tax calculation Summary Step
            RVWWebApp.EditPurchaseOrder.TaxCalculationSummary.Click();
            WaitSeconds(5);
            RVWWebApp.TaxCalculationSummary.SaveDetails.Click();
            WaitSeconds(5);
            RVWWebApp.TaxCalculationSummary.PopupClose.Click();
            RVWWebApp.TaxCalculationSummary.GoBack.Click();

            //Do Specify Schedule & Distribution Step
            RVWWebApp.EditPurchaseOrder.SpecifyScheduleAndDistribution.Click();
            WaitSeconds(5);
            RVWWebApp.SpecifyScheduleAndDistribution.SpecifySchedule.Click();
            WaitSeconds(5);
            RVWWebApp.SpecifyScheduleAndDistribution.PopupClose.Click();
            RVWWebApp.SpecifyScheduleAndDistribution.GoBack.Click();

            //Do Specify PO - PR coverage Step
            RVWWebApp.EditPurchaseOrder.SpecifyPOPRCoverage.Click();
            WaitSeconds(5);
            RVWWebApp.SpecifyPOPRCoverage.CoverPR.Click();
            WaitSeconds(5);
            RVWWebApp.SpecifyPOPRCoverage.PopupClose.Click();
            RVWWebApp.SpecifyPOPRCoverage.GoBack.Click();

            //Do Refresh Step
            RVWWebApp.EditPurchaseOrder.Refresh.Click();

            //Do Edit & Approve PO Step
            RVWWebApp.EditPurchaseOrder.AnalysisCode.InputText("APR18");
            RVWWebApp.EditPurchaseOrder.GetItemRow(1).ACUsage.Click();
            RVWWebApp.EditPurchaseOrder.GetItemRow(1).ACUsage.ClearText();
            RVWWebApp.EditPurchaseOrder.GetItemRow(1).ACUsage.InputTextByCoordinates("ISPCHARG");
            RVWWebApp.EditPurchaseOrder.GetItemRow(1).ACUsage.InputTextByCoordinates(Keys.Enter);
            RVWWebApp.EditPurchaseOrder.Default.Click();
            RVWWebApp.EditPurchaseOrder.EditAndApprovePO.Click();
            WaitSeconds(5);
            RVWWebApp.EditPurchaseOrder.PopupClose.Click();

            RVWWebApp.EditPurchaseOrder.GoBack.Click();
            RVWWebApp.ConvertPurchaseRequestToOrder.ConvertPRGoBackBtn.Click();

            RVWWebApp.SelfServiceHome.HeaderSearchBox.InputTextKeyByKey("View Purchase Order");
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.FirstHeaderSearchSuggestionOption.Click();
            WaitSeconds(5);
            RVWWebApp.ViewPurchaseOrder.FromPONumber.InputTextKeyByKey(orderNumber);
            RVWWebApp.ViewPurchaseOrder.ToPONumber.InputTextKeyByKey(orderNumber);
            RVWWebApp.ViewPurchaseOrder.Search.Click();
            WaitSeconds(3);

            RVWWebApp.ViewPurchaseOrder.GetItemRow(1).PONumber.AssertElementTextEquals(orderNumber);    
        }
    }
}
