using AventStack.ExtentReports;
using MarsFrameworkSpecflow.Pages;
using NUnit.Framework;
using System.Reflection;
using MarsFrameworkSpecflow.Global;

namespace MarsFrameworkSpecflow.StepDefinitions
{
    [Binding]
    public class ReceivedRequestStepDefinitions : Base
    {
        ManageRequestsPage manageRequestsObj = new ManageRequestsPage();
        private string senderURL;

        //Background
        [Given(@"I navigate to Manage Requests Page then Received Request Page")]
        public void GivenINavigateToManageRequestsPageThenReceivedRequestPage()
        {
            manageRequestsObj.ReceivedRequestsPage();
        }
        //Accept Request
        [Given(@"I accept a new request")]
        public void GivenIAcceptANewRequest()
        {
            manageRequestsObj.AcceptRequest();
        }

        [Then(@"The new request should be accepted successfully")]
        public void ThenTheNewRequestShouldBeAcceptedSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);

            string status = manageRequestsObj.GetStatus();
            Assert.That(status == "Accepted");
            test.Log(Status.Pass, "Passed, action successfull.");
        }
        //Decline Request
        [Given(@"I decline a new request")]
        public void GivenIDeclineANewRequest()
        {
            manageRequestsObj.DeclineRequest();
        }

        [Then(@"The new request should be declined successfully")]
        public void ThenTheNewRequestShouldBeDeclinedSuccessfully()
        {
            
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);

            string status = manageRequestsObj.GetStatus();
            Assert.That(status == "Declined");
            test.Log(Status.Pass, "Passed, action successfull.");
        }
        //View Sender's Profile
        [Given(@"I view the sender's profile")]
        public void GivenIViewTheSendersProfile()
        {
            string senderURL = manageRequestsObj.GetSenderURL();
            Console.WriteLine(senderURL);
            manageRequestsObj.ViewSenderProfile();
            ScenarioContext.Current["SenderURL"] = senderURL;

        }

        [Then(@"The sender's profile should be displayed successfully")]
        public void ThenTheSendersProfileShouldBeDisplayedSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            string currentURL = manageRequestsObj.GetPageURL();
            string senderURL = (string)ScenarioContext.Current["SenderURL"];
            Console.WriteLine("The current URL is: " + currentURL);
            Console.WriteLine("The sender's URL is: " + senderURL);
            Assert.That(senderURL == currentURL);
            test.Log(Status.Pass, "Passed, action successfull.");
        }


        [Given(@"I view the requested service")]
        public void GivenIViewTheRequesteddService()
        {
            string receivedRequestTitle = manageRequestsObj.RequestsTitle();
            manageRequestsObj.ViewServiceDetail();
            ScenarioContext.Current["ReceivedRequestTitle"] = receivedRequestTitle;
            
        }

        [Then(@"The requested service should be displayed successfully")]
        public void ThenTheRequestedServiceShouldBeDisplayedSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            string ServicePageTitle = manageRequestsObj.ServiceDetailTitle();
            string receivedRequestTitle = (string)ScenarioContext.Current["ReceivedRequestTitle"];
            Assert.That(receivedRequestTitle == ServicePageTitle);
            Console.WriteLine("The expected tile is: " + receivedRequestTitle);
            Console.WriteLine("The actual title is: " + ServicePageTitle);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the requests by categories")]
        public void GivenISortTheRequestsByCategories()
        {
            List<String> actualCategory = manageRequestsObj.BeforeSortingCategory();
            manageRequestsObj.SortByCategory();
            ScenarioContext.Current["ActualCategory"] = actualCategory;

        }

        [Then(@"The requests should be sorted by categories successfully")]
        public void ThenTheRequestsShouldBeSortedByCategoriesSuccessfully()
        {

            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> afterCategory = manageRequestsObj.AfterSortingCategory();
            List<String> actualCategory = (List<String>)ScenarioContext.Current["ActualCategory"];
            Assert.AreNotEqual(actualCategory, afterCategory);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the requests by title")]
        public void GivenISortTheRequestsByTitle()
        {
            List<String> actualTitle = manageRequestsObj.BeforeSortingTitle();
            manageRequestsObj.SortByTitle();
            ScenarioContext.Current["ActualTitle"] = actualTitle;

        }

        [Then(@"The requests should be sorted by title successfully")]
        public void ThenTheRequestsShouldBeSortedByTitleSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);

            List<String> afterTitle = manageRequestsObj.AfterSortingTitle();
            List<String> actualTitle = (List<String>)ScenarioContext.Current["ActualTitle"];
            Assert.AreNotEqual(actualTitle, afterTitle);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the requests by message")]
        public void GivenISortTheRequestsByMessage()
        {
            List<String> actualMessage = manageRequestsObj.BeforeSortingMessage();
            manageRequestsObj.SortByMessage();
            ScenarioContext.Current["ActualMessage"] = actualMessage;
        }    

        [Then(@"The requests should be sorted by message successfully")]
        public void ThenTheRequestsShouldBeSortedByMessageSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> actualMessage = (List<String>)ScenarioContext.Current["ActualMessage"];
            List<String> afterMessage = manageRequestsObj.AfterSortingMessage();
            Assert.AreNotEqual(actualMessage, afterMessage);
            test.Log(Status.Pass, "Passed, action successfull.");

        }

        [Given(@"I sort the requests by sender")]
        public void GivenISortTheRequestsBySender()
        {
            List<String> actualSender = manageRequestsObj.BeforeSortingSender();
            manageRequestsObj.SortBySender();
            ScenarioContext.Current["ActualSender"] = actualSender;

        }

        [Then(@"The requests should be sorted by sender successfully")]
        public void ThenTheRequestsShouldBeSortedBySenderSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> actualSender = (List<String>)ScenarioContext.Current["ActualSender"];
            List<String> afterSender = manageRequestsObj.AfterSortingSender();
            Assert.AreNotEqual(actualSender, afterSender);
            test.Log(Status.Pass, "Passed, action successfull.");

        }

        [Given(@"I sort the requests by status")]
        public void GivenISortTheRequestsByStatus()
        {
           
            List<String> actualStatus = manageRequestsObj.BeforeSortingStatus();
            manageRequestsObj.SortByStatus();
            ScenarioContext.Current["ActualStatus"] = actualStatus;

        }

        [Then(@"The requests should be sorted by status successfully")]
        public void ThenTheRequestsShouldBeSortedByStatusSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> actualStatus = (List<String>)ScenarioContext.Current["ActualStatus"];
            List<String> afterStatus = manageRequestsObj.AfterSortingStatus();
            Assert.AreNotEqual(actualStatus, afterStatus);
            test.Log(Status.Pass, "Passed, action successfull.");

        }

        [Given(@"I sort the requests by type")]
        public void GivenISortTheRequestsByType()
        {
            List<String> actualType = manageRequestsObj.BeforeSortingType();
            manageRequestsObj.SortByType();
            ScenarioContext.Current["ActualType"] = actualType;
            
        }

        [Then(@"The requests should be sorted by type successfully")]
        public void ThenTheRequestsShouldBeSortedByTypeSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> actualType = (List<String>)ScenarioContext.Current["ActualType"];
            List<String> afterType = manageRequestsObj.AfterSortingType();
            Assert.AreNotEqual(actualType, afterType);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the requests by date")]
        public void GivenISortTheRequestsByDate()
        {
            
            List<String> actualDate = manageRequestsObj.BeforeSortingDate();
            manageRequestsObj.SortByDate();
            ScenarioContext.Current["ActualDate"] = actualDate;

        }

        [Then(@"The requests should be sorted by date successfully")]
        public void ThenTheRequestsShouldBeSortedByDateSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> afterDate = manageRequestsObj.AfterSortingDate();
            List<String> actualDate = (List<String>)ScenarioContext.Current["ActualDate"];
            Assert.AreNotEqual(actualDate, afterDate);
            test.Log(Status.Pass, "Passed, action successfull.");
        }




    }
}
