using AventStack.ExtentReports;
using NUnit.Framework;
using System.Reflection;
using MarsFrameworkSpecflow.Global;
using MarsFrameworkSpecflow.Pages;

namespace MarsFrameworkSpecflow.StepDefinitions
{
    [Binding]
    public class SentRequestStepDefinitions : Base
    {
        SentRequestPage sentRequestPageObj = new SentRequestPage();

        [Given(@"I navigate to Sent Requests Page then Received Request Page")]
        public void GivenINavigateToSentRequestsPageThenReceivedRequestPage()
        {
            sentRequestPageObj.SentRequestsPage();
        }

        [Given(@"I withdraw a request")]
        public void GivenIWithdrawARequest()
        {
            sentRequestPageObj.WithdrawRequest();
        }

        [Then(@"The request should be withrawn successfully")]
        public void ThenTheRequestShouldBeWithrawnSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            string status = sentRequestPageObj.GetStatus();
            Assert.That(status == "Withdrawn");
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I view the recipient's profile")]
        public void GivenIViewTheRecipientsProfile()
        {
            string recipientURL = sentRequestPageObj.GetRecipientURL();
            Console.WriteLine(recipientURL);
            sentRequestPageObj.ViewRecipientsProfile();
            ScenarioContext.Current["RecipientURL"] = recipientURL;
        }

        [Then(@"The recipient's profile should be displayed successfully")]
        public void ThenTheRecipientsProfileShouldBeDisplayedSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            string currentURL = sentRequestPageObj.GetPageURL();
            string recipientURL = (string)ScenarioContext.Current["RecipientURL"];
            Console.WriteLine("The current URL is: " + currentURL);
            Console.WriteLine("The recipient's URL is: " + recipientURL);
            Assert.That(recipientURL == currentURL);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I view the sent service")]
        public void GivenIViewTheSentService()
        {
            string sentRequestTitle = sentRequestPageObj.SentRequestTitle();
            sentRequestPageObj.ViewSentServiceDetail();
            ScenarioContext.Current["SentRequestTitle"] = sentRequestTitle;
        }

        [Then(@"The sent service should be displayed successfully")]
        public void ThenTheSentServiceShouldBeDisplayedSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            string ServicePageTitle = sentRequestPageObj.ServiceDetailTitle();
            string sentRequestTitle = (string)ScenarioContext.Current["SentRequestTitle"];
            Assert.That(sentRequestTitle == ServicePageTitle);
            Console.WriteLine("The expected tile is: " + sentRequestTitle);
            Console.WriteLine("The actual title is: " + ServicePageTitle);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the sent requests by categories")]
        public void GivenISortTheSentRequestsByCategories()
        {
            List<String> actualCategory = sentRequestPageObj.BeforeSortingCategory();
            sentRequestPageObj.SortByCategory();
            ScenarioContext.Current["ActualCategory"] = actualCategory;
        }

        [Then(@"The sent requests should be sorted by categories successfully")]
        public void ThenTheSentRequestsShouldBeSortedByCategoriesSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> afterCategory = sentRequestPageObj.AfterSortingCategory();
            List<String> actualCategory = (List<String>)ScenarioContext.Current["ActualCategory"];
            Assert.AreNotEqual(actualCategory, afterCategory);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the sent requests by title")]
        public void GivenISortTheSentRequestsByTitle()
        {
            List<String> actualTitle = sentRequestPageObj.BeforeSortingTitle();
            sentRequestPageObj.SortByTitle();
            ScenarioContext.Current["ActualTitle"] = actualTitle;
        }

        [Then(@"The sent requests should be sorted by title successfully")]
        public void ThenTheSentRequestsShouldBeSortedByTitleSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);

            List<String> afterTitle = sentRequestPageObj.AfterSortingTitle();
            List<String> actualTitle = (List<String>)ScenarioContext.Current["ActualTitle"];
            Assert.AreNotEqual(actualTitle, afterTitle);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the sent requests by message")]
        public void GivenISortTheSentRequestsByMessage()
        {
            List<String> actualMessage = sentRequestPageObj.BeforeSortingMessage();
            sentRequestPageObj.SortByMessage();
            ScenarioContext.Current["ActualMessage"] = actualMessage;
        }

        [Then(@"The sent requests should be sorted by message successfully")]
        public void ThenTheSentRequestsShouldBeSortedByMessageSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> actualMessage = (List<String>)ScenarioContext.Current["ActualMessage"];
            List<String> afterMessage = sentRequestPageObj.AfterSortingMessage();
            Assert.AreNotEqual(actualMessage, afterMessage);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the sent requests by recepient")]
        public void GivenISortTheSentRequestsByRecepient()
        {
            List<String> actualRecepient = sentRequestPageObj.BeforeSortingRecepient();
            sentRequestPageObj.SortByRecepient();
            ScenarioContext.Current["ActualRecepient"] = actualRecepient;
        }

        [Then(@"The sent requests should be sorted by recepient successfully")]
        public void ThenTheSentRequestsShouldBeSortedByRecepientSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> actualRecepient = (List<String>)ScenarioContext.Current["ActualRecepient"];
            List<String> afterRecepient = sentRequestPageObj.AfterSortingRecepient();
            Assert.AreNotEqual(actualRecepient, afterRecepient);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the sent requests by status")]
        public void GivenISortTheSentRequestsByStatus()
        {
            List<String> actualStatus = sentRequestPageObj.BeforeSortingStatus();
            sentRequestPageObj.SortByStatus();
            ScenarioContext.Current["ActualStatus"] = actualStatus;
        }

        [Then(@"The sent requests should be sorted by status successfully")]
        public void ThenTheSentRequestsShouldBeSortedByStatusSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> actualStatus = (List<String>)ScenarioContext.Current["ActualStatus"];
            List<String> afterStatus = sentRequestPageObj.AfterSortingStatus();
            Assert.AreNotEqual(actualStatus, afterStatus);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the sent requests by type")]
        public void GivenISortTheSentRequestsByType()
        {
            List<String> actualType = sentRequestPageObj.BeforeSortingType();
            sentRequestPageObj.SortByType();
            ScenarioContext.Current["ActualType"] = actualType;
        }

        [Then(@"The sent requests should be sorted by type successfully")]
        public void ThenTheSentRequestsShouldBeSortedByTypeSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> actualType = (List<String>)ScenarioContext.Current["ActualType"];
            List<String> afterType = sentRequestPageObj.AfterSortingType();
            Assert.AreNotEqual(actualType, afterType);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I sort the sent requests by date")]
        public void GivenISortTheSentRequestsByDate()
        {
            List<String> actualDate = sentRequestPageObj.BeforeSortingDate();
            sentRequestPageObj.SortByDate();
            ScenarioContext.Current["ActualDate"] = actualDate;
        }

        [Then(@"The sent requests should be sorted by date successfully")]
        public void ThenTheSentRequestsShouldBeSortedByDateSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            List<String> afterDate = sentRequestPageObj.AfterSortingDate();
            List<String> actualDate = (List<String>)ScenarioContext.Current["ActualDate"];
            Assert.AreNotEqual(actualDate, afterDate);
            test.Log(Status.Pass, "Passed, action successfull.");
        }
    }
}
