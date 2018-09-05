namespace TVSLSL.Automation.RVW.Tests
{
    using Common;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using TVSLSL.Automation.Common.Tests.Utilities;
    using TVSLSL.Automation.RVW.Application;

    public class CreatePurchaseRequestTest : RVWTests
    {
        [Test]

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
            RVWWebApp.CreatePurchaseRequest.Type.InputText("CAPITAL", true);
            RVWWebApp.CreatePurchaseRequest.RequesterId.InputText("052335");
            RVWWebApp.CreatePurchaseRequest.RequesterName.InputText("Nived");
            RVWWebApp.CreatePurchaseRequest.ProposalNumber.InputText("3PLAPN00001/1819");

            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).ItemCode.Click();
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).ItemCode.InputTextByCoordinates("GENCOOAIRELE007");
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).ItemCode.InputTextByCoordinates(Keys.Enter);
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).RequiredQuantity.Click();
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).RequiredQuantity.InputTextByCoordinates("1");
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).ItemCode.InputTextByCoordinates(Keys.Enter);
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).Cost.Click();
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).Cost.InputTextByCoordinates("1000");
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).ItemCode.InputTextByCoordinates(Keys.Enter);
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).NeedDate.Click();
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).NeedDate.InputTextByCoordinates(needDate);
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).PreferredSupplierCode.Click();
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).PreferredSupplierCode.InputTextByCoordinates("GATEXRAI28");
            RVWWebApp.CreatePurchaseRequest.GetItemRow(1).ItemCode.InputTextByCoordinates(Keys.Enter);

            RVWWebApp.CreatePurchaseRequest.CreatePurchaseReq();
            RVWWebApp.CreatePurchaseRequest.PRCreatePopupClose.Click();
            RVWWebApp.CreatePurchaseRequest.PRAdditionalDetails.Click();
            WaitSeconds(5);

            string pRNumber = RVWWebApp.PRAdditionalDetails.PRNumber.GetElementText();
            RVWWebApp.PRAdditionalDetails.LineOfBusiness.InputText("AFTER MARKET WAREHOUSE", true);
            WaitSeconds(3);
            RVWWebApp.PRAdditionalDetails.ProjectName.InputText("BANGALORE WAREHOUSE", true);
            WaitSeconds(3);
            RVWWebApp.PRAdditionalDetails.ProjectLocation.InputText("BANGADTVSWHE2", true);
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
            WaitSeconds(3);
            RVWWebApp.EditPurchaseRequest.PopupClose.Click();
            RVWWebApp.EditPurchaseRequest.GoBack.Click();
            RVWWebApp.CreatePurchaseRequest.GoBackBtn.Click();
           
            RVWWebApp.SelfServiceHome.HeaderSearchBox.InputTextKeyByKey("View Purchase Request");
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.FirstHeaderSearchSuggestionOption.Click();
            RVWWebApp.ViewPurchaseRequest.PRNumberFrom.InputText(pRNumber);
            RVWWebApp.ViewPurchaseRequest.PRNumberTo.InputText(pRNumber);
            RVWWebApp.ViewPurchaseRequest.Search.Click();
            WaitSeconds(5);

            RVWWebApp.ViewPurchaseRequest.GetItemRow(1).PRNumber.AssertElementTextEquals(pRNumber);
        }

        [Test]

        public void CreatePOFromPR()
        {
            //Test to verify that user can create purchase order from the purchase request

            string dateFrom = TestHelper.GetTodaysDate("dd/MM/yyyy", -30);
            string dateTo = TestHelper.GetTodaysDate("dd/MM/yyyy", 1);

            RVWWebApp.Login.SignIntoAccountWIthTestUser();
            RVWWebApp.SelfServiceHome.HeaderSearchBox.InputTextKeyByKey("View Purchase Request");
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.FirstHeaderSearchSuggestionOption.Click();
            WaitSeconds(5);

            RVWWebApp.ViewPurchaseRequest.PRDateFrom.InputText(dateFrom, true);
            RVWWebApp.ViewPurchaseRequest.PRDateTo.InputText(dateTo, true);
            RVWWebApp.ViewPurchaseRequest.Search.Click();
            WaitSeconds(5);
            string pRnumber = RVWWebApp.ViewPurchaseRequest.GetItemRow(1).PRNumber.GetElementText();
            RVWWebApp.ViewPurchaseRequest.GoBack.Click();

            RVWWebApp.SelfServiceHome.HeaderSearchBox.InputTextKeyByKey("Convert Purchase Request To Order");
            WaitSeconds(3);
            RVWWebApp.SelfServiceHome.FirstHeaderSearchSuggestionOption.Click();
            WaitSeconds(5);

            RVWWebApp.ConvertPurchaseRequestToOrder.PRNumberFrom.InputText(pRnumber, true);
            RVWWebApp.ConvertPurchaseRequestToOrder.PRNumberTo.InputText(pRnumber, true);            
            RVWWebApp.ConvertPurchaseRequestToOrder.Search.Click();
            WaitSeconds(5);
            string preferredSupplierCode = RVWWebApp.ConvertPurchaseRequestToOrder.GetItemRow(1).PreferredSupplierCode.GetElementText();            
            RVWWebApp.ConvertPurchaseRequestToOrder.SupplierCode.InputText(preferredSupplierCode);
            RVWWebApp.ConvertPurchaseRequestToOrder.GetItemRow(1).SelectRow.Click();
            RVWWebApp.ConvertPurchaseRequestToOrder.CreateOrderDoc.Click();
            RVWWebApp.ConvertPurchaseRequestToOrder.CreateOrderPopupClose.Click();
            RVWWebApp.ConvertPurchaseRequestToOrder.ConvertPRGoBackBtn.Click();
        }
    }
}
