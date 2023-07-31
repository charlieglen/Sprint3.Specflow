using AventStack.ExtentReports;
using MarsFrameworkSpecflow.Pages;
using NUnit.Framework;
using System.Reflection;
using MarsFrameworkSpecflow.Global;

namespace MarsFrameworkSpecflow.StepDefinitions
{
    [Binding]
    public class SentRequestStepDefinitions : Base
    {
        ManageRequestsPage manageRequestsObj = new ManageRequestsPage();

        [Given(@"I navigate to Sent Requests Page then Received Request Page")]
        public void GivenINavigateToSentRequestsPageThenReceivedRequestPage()
        {
            manageRequestsObj.SentRequestsPage();
        }

        [Given(@"I withdraw a request")]
        public void GivenIWithdrawARequest()
        {
            manageRequestsObj.WithdrawRequest();
        }

        [Then(@"The request should be withrawn successfully")]
        public void ThenTheRequestShouldBeWithrawnSuccessfully()
        {
            string status = manageRequestsObj.GetStatus();
            Assert.That(status == "Withdrawn");
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I view the recipient's profile")]
        public void GivenIViewTheRecipientsProfile()
        {
            string recipientURL = manageRequestsObj.GetRecipientURL();
            Console.WriteLine(recipientURL);
            manageRequestsObj.ViewRecipientsProfile();
            ScenarioContext.Current["RecipientURL"] = recipientURL;
        }

        [Then(@"The recipient's profile should be displayed successfully")]
        public void ThenTheRecipientsProfileShouldBeDisplayedSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            string currentURL = manageRequestsObj.GetPageURL();
            string recipientURL = (string)ScenarioContext.Current["RecipientURL"];
            Console.WriteLine("The current URL is: " + currentURL);
            Console.WriteLine("The recipient's URL is: " + recipientURL);
            Assert.That(recipientURL == currentURL);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I view the sent service")]
        public void GivenIViewTheSentService()
        {
            string sentRequestTitle = manageRequestsObj.SentRequestTitle();
            manageRequestsObj.ViewSentServiceDetail();
            ScenarioContext.Current["SentRequestTitle"] = sentRequestTitle;
        }

        [Then(@"The sent service should be displayed successfully")]
        public void ThenTheSentServiceShouldBeDisplayedSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            string ServicePageTitle = manageRequestsObj.ServiceDetailTitle();
            string sentRequestTitle = (string)ScenarioContext.Current["SentRequestTitle"];
            Assert.That(sentRequestTitle == ServicePageTitle);
            Console.WriteLine("The expected tile is: " + sentRequestTitle);
            Console.WriteLine("The actual title is: " + ServicePageTitle);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the sent requests by categories")]
        public void GivenISortTheSentRequestsByCategories()
        {
            ManageRequestsPage manageRequestsObj = new ManageRequestsPage();
            List<String> actualCategory = manageRequestsObj.BeforeSortingCategory();
            manageRequestsObj.SortByCategory();
            ScenarioContext.Current["ActualCategory"] = actualCategory;
        }

        [Then(@"The sent requests should be sorted by categories successfully")]
        public void ThenTheSentRequestsShouldBeSortedByCategoriesSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> afterCategory = manageRequestsObj.AfterSortingCategory();
            List<String> actualCategory = (List<String>)ScenarioContext.Current["ActualCategory"];
            Assert.AreNotEqual(actualCategory, afterCategory);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the sent requests by title")]
        public void GivenISortTheSentRequestsByTitle()
        {
            ManageRequestsPage manageRequestsObj = new ManageRequestsPage();
            List<String> actualTitle = manageRequestsObj.BeforeSortingTitle();
            manageRequestsObj.SortByTitle();
            ScenarioContext.Current["ActualTitle"] = actualTitle;
        }

        [Then(@"The sent requests should be sorted by title successfully")]
        public void ThenTheSentRequestsShouldBeSortedByTitleSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);

            List<String> afterTitle = manageRequestsObj.AfterSortingTitle();
            List<String> actualTitle = (List<String>)ScenarioContext.Current["ActualTitle"];
            Assert.AreNotEqual(actualTitle, afterTitle);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the sent requests by message")]
        public void GivenISortTheSentRequestsByMessage()
        {
            ManageRequestsPage manageRequestsObj = new ManageRequestsPage();
            List<String> actualMessage = manageRequestsObj.BeforeSortingMessage();
            manageRequestsObj.SortByMessage();
            ScenarioContext.Current["ActualMessage"] = actualMessage;
        }

        [Then(@"The sent requests should be sorted by message successfully")]
        public void ThenTheSentRequestsShouldBeSortedByMessageSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> actualMessage = (List<String>)ScenarioContext.Current["ActualMessage"];
            List<String> afterMessage = manageRequestsObj.AfterSortingMessage();
            Assert.AreNotEqual(actualMessage, afterMessage);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the sent requests by sender")]
        public void GivenISortTheSentRequestsBySender()
        {
            List<String> actualSender = manageRequestsObj.BeforeSortingSender();
            manageRequestsObj.SortBySender();
            ScenarioContext.Current["ActualSender"] = actualSender;
        }

        [Then(@"The sent requests should be sorted by sender successfully")]
        public void ThenTheSentRequestsShouldBeSortedBySenderSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> actualSender = (List<String>)ScenarioContext.Current["ActualSender"];
            List<String> afterSender = manageRequestsObj.AfterSortingSender();
            Assert.AreNotEqual(actualSender, afterSender);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the sent requests by status")]
        public void GivenISortTheSentRequestsByStatus()
        {
            List<String> actualStatus = manageRequestsObj.BeforeSortingStatus();
            manageRequestsObj.SortByStatus();
            ScenarioContext.Current["ActualStatus"] = actualStatus;
        }

        [Then(@"The sent requests should be sorted by status successfully")]
        public void ThenTheSentRequestsShouldBeSortedByStatusSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> actualStatus = (List<String>)ScenarioContext.Current["ActualStatus"];
            List<String> afterStatus = manageRequestsObj.AfterSortingStatus();
            Assert.AreNotEqual(actualStatus, afterStatus);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the sent requests by type")]
        public void GivenISortTheSentRequestsByType()
        {
            List<String> actualType = manageRequestsObj.BeforeSortingType();
            manageRequestsObj.SortByType();
            ScenarioContext.Current["ActualType"] = actualType;
        }

        [Then(@"The sent requests should be sorted by type successfully")]
        public void ThenTheSentRequestsShouldBeSortedByTypeSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> actualType = (List<String>)ScenarioContext.Current["ActualType"];
            List<String> afterType = manageRequestsObj.AfterSortingType();
            Assert.AreNotEqual(actualType, afterType);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the sent requests by date")]
        public void GivenISortTheSentRequestsByDate()
        {
            List<String> actualDate = manageRequestsObj.BeforeSortingDate();
            manageRequestsObj.SortByDate();
            ScenarioContext.Current["ActualDate"] = actualDate;
        }

        [Then(@"The sent requests should be sorted by date successfully")]
        public void ThenTheSentRequestsShouldBeSortedByDateSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> afterDate = manageRequestsObj.AfterSortingDate();
            List<String> actualDate = (List<String>)ScenarioContext.Current["ActualDate"];
            Assert.AreNotEqual(actualDate, afterDate);
            test.Log(Status.Pass, "Passed, action successfull.");
        }
    }
}
