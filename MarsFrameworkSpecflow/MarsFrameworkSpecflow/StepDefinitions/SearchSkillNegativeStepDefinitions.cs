using AventStack.ExtentReports;
using MarsFrameworkSpecflow.Pages;
using NUnit.Framework;
using MarsFrameworkSpecflow.Global;
using System.Reflection;

namespace MarsFrameworkSpecflow.StepDefinitions
{
    [Binding]
    public class SearchSkillNegativeStepDefinitions : Base
    {
        SearchSkillsPage searchSkillPageObj = new SearchSkillsPage();

        [Given(@"I search an empty skill")]
        public void GivenISearchAnEmptySkill()
        {
            testRow = 3;
            searchSkillPageObj.SearchSkillsHomePage();
            int expectedNumberOfResults = searchSkillPageObj.GetExpectedNumberOfResults();
            ScenarioContext.Current["ExpectedNumberOfResults"] = expectedNumberOfResults;
        }

        [Then(@"All registered skills must be displayed successfully")]
        public void ThenAllRegisteredSkillsMustBeDisplayedSuccessfully()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);

            int actualNumberOfResults = searchSkillPageObj.GetActualNumberOfResults();
            int expectedNumberOfResults = (int)ScenarioContext.Current["ExpectedNumberOfResults"];
            Console.WriteLine("The number of refinable result is: " + expectedNumberOfResults);
            Console.WriteLine("The total number of registered skills for trade is: " + actualNumberOfResults);
            Assert.That(expectedNumberOfResults == 0 && actualNumberOfResults != 0);
            test.Log(Status.Pass, "Passed, action successfull. No refinable results and all skills are displayed.");
        }

        [Given(@"I search a skill with just space")]
        public void GivenISearchASkillWithJustSpace()
        {
            testRow = 8;
            searchSkillPageObj.SearchSkillsHomePage();
            int expectedNumberOfResults = searchSkillPageObj.GetExpectedNumberOfResults();
            ScenarioContext.Current["ExpectedNumberOfResults"] = expectedNumberOfResults;

        }

        [Given(@"I search an empty skill from the result page")]
        public void GivenISearchAnEmptySkillFromTheResultPage()
        {
            testRow = 4;
            searchSkillPageObj.SearchSkillsHomePage();
            int expectedNumberOfResults = searchSkillPageObj.GetExpectedNumberOfResults();
            ScenarioContext.Current["ExpectedNumberOfResults"] = expectedNumberOfResults;
        }

        [Then(@"There will be no changes in the result page")]
        public void ThenThereWillBeNoChangesInTheResultPage()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);

            int expectedNumberOfResults = (int)ScenarioContext.Current["ExpectedNumberOfResults"];
            int actualNumberOfResults = searchSkillPageObj.GetActualNumberOfResults();
            Console.WriteLine("The expected number of results is: " + expectedNumberOfResults);
            Console.WriteLine("The actual number of results is: " + actualNumberOfResults);
            Assert.That(expectedNumberOfResults == actualNumberOfResults);
            test.Log(Status.Pass, "Passed, action successfull. No changes in the search results displayed.");
        }

        [Given(@"I search an empty user from the result page")]
        public void GivenISearchAnEmptyUserFromTheResultPage()
        {
            testRow = 5;
            searchSkillPageObj.SearchSkillsHomePage();
        }

        [Then(@"There should be no results to display")]
        public void ThenThereShouldBeNoResultsToDisplay()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            string resultPanelIsVisible = searchSkillPageObj.LocateSearchUserResultPanel();
            Console.WriteLine("Class name " + resultPanelIsVisible + " is visible which means no results to show.");
            Assert.That(resultPanelIsVisible == "results transition");
            test.Log(Status.Pass, "Passed, action successfull. No search results to show and search icon not clickable.");
        }

        [Given(@"I search with more than the number of allowed characters")]
        public void GivenISearchWithMoreThanTheNumberOfAllowedCharacters()
        {
            testRow = 7;
            searchSkillPageObj.SearchSkillsHomePage();
        }

        [Then(@"The website should crash")]
        public void ThenTheWebsiteShouldCrash()
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            string searchNotice = searchSkillPageObj.GetNotWorkingNotice();
            Console.WriteLine(searchNotice);
            Assert.That(searchNotice == "This page isn’t working");
            test.Log(Status.Pass, "Passed, action successfull. Search keyword exceeds the number of characters allowed - 8152.");

        }
    }
}
