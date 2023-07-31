using AventStack.ExtentReports;
using MarsFrameworkSpecflow.Global;
using MarsFrameworkSpecflow.Pages;
using NUnit.Framework;
using System.Reflection;
using static MarsFrameworkSpecflow.Global.GlobalDefinitions;

namespace MarsFrameworkSpecflow.StepDefinitions
{
    [Binding]
    public class SearchSkillStepDefinitions : Base
    {

        SearchSkillsPage searchSkillPageObj = new SearchSkillsPage();

        [Given(@"I search a skill from the profile page")]
        public void GivenISearchASkillFromTheProfilePage()
        {
            testRow = 2;
            searchSkillPageObj.SearchSkillsHomePage();
        }

        [Given(@"I view the main category")]
        public void GivenIViewTheMainCategory()
        {
            searchSkillPageObj.ViewCategory();
        }

        [When(@"I view the subcategory")]
        public void WhenIViewTheSubcategory()
        {
            searchSkillPageObj.ViewSubCategory();
        }

        [Then(@"The searched skill should be displayed successfully")]
        public void ThenTheSearchedSkillShouldBeDisplayedSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);

            searchSkillPageObj.OpenSellerDetails();
            bool searchSkillMatch = searchSkillPageObj.GetSkillTitleAndDescription();
            Assert.That(searchSkillMatch == true);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I search a user from the results page")]
        public void GivenISearchAUserFromTheResultsPage()
        {
            testRow = 2;
            searchSkillPageObj.ViewCategory();
            searchSkillPageObj.SearchUserFromResult();
        }

        [Then(@"The searched user should be displayed successfully")]
        public void ThenTheSearchedUserShouldBeDisplayedSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);

            string sellerNameResult = searchSkillPageObj.GetSellerName();
            Assert.IsTrue(string.Equals(sellerNameResult, (ExcelLib.ReadData(testRow, "SearchUser")), StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(sellerNameResult);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I search a skill from the results page")]
        public void GivenISearchASkillFromTheResultsPage()
        {
            testRow = 2;
            searchSkillPageObj.ViewCategory();
            searchSkillPageObj.SearchSkillsFromResults();
            searchSkillPageObj.OpenSellerDetails();
        }

        [Then(@"The searched skill should be display successfully")]
        public void ThenTheSearchedSkillShouldBeDisplaySuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            
            bool searchSkillMatch = searchSkillPageObj.GetSkillTitleAndDescription();
            Assert.That(searchSkillMatch == true);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I filter the skills by Location - Online")]
        public void GivenIFilterTheSkillsByLocation_Online()
        {
            testRow = 2;
            searchSkillPageObj.ViewCategory();
            searchSkillPageObj.FilterOnline();
            searchSkillPageObj.OpenSellerDetails();
        }

        [Then(@"All skills with online location should be displayed successfully")]
        public void ThenAllSkillsWithOnlineLocationShouldBeDisplayedSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);

            string locationType = searchSkillPageObj.GetLocationType();
            Console.WriteLine(locationType);
            Assert.That(locationType == "Online");
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I filter the skills by Location - Onsite")]
        public void GivenIFilterTheSkillsByLocation_Onsite()
        {
            testRow = 2;
            searchSkillPageObj.ViewCategory();
            searchSkillPageObj.FilterOnsite();
            searchSkillPageObj.OpenSellerDetails();
        }

        [Then(@"All skills with onsite location should be dispalayed successfully")]
        public void ThenAllSkillsWithOnsiteLocationShouldBeDispalayedSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);

            string locationType = searchSkillPageObj.GetLocationType();
            Console.WriteLine(locationType);
            Assert.That(locationType == "On-Site");
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I cancel the location filter")]
        public void GivenICancelTheLocationFilter()
        {
            testRow = 2;
            int actualNumberOfResults = searchSkillPageObj.GetActualNumberOfResults();
            searchSkillPageObj.FilterOnsite();
            searchSkillPageObj.FilterShowAll();
            ScenarioContext.Current["ActualNumberOfResults"] = actualNumberOfResults;
        }

        [Then(@"All results should be displayed successfully")]
        public void ThenAllResultsShouldBeDisplayedSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);

            int actualNumberOfResults = (int)ScenarioContext.Current["ActualNumberOfResults"];
            Console.WriteLine("The actual number of results is: " + actualNumberOfResults);
            int expectedNumberOfResults = searchSkillPageObj.GetExpectedNumberOfResults();
            Console.WriteLine("The expected number of results is: " + expectedNumberOfResults);
            Assert.That(expectedNumberOfResults == actualNumberOfResults);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

        [Given(@"I change the default number of results per page")]
        public void GivenIChangeTheDefaultNumberOfResultsPerPage()
        {
            testRow = 2;
            searchSkillPageObj.ResultsPerPage();
        }

        [Then(@"The new number of results should match successfully")]
        public void ThenTheNewNumberOfResultsShouldMatchSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);

            int resultsPerPage = searchSkillPageObj.GetNumberOfResultsPerPage();
            Console.WriteLine(resultsPerPage);
            Assert.That(resultsPerPage == 18);
            test.Log(Status.Pass, "Passed, action successfull.");
        }

    }
}
