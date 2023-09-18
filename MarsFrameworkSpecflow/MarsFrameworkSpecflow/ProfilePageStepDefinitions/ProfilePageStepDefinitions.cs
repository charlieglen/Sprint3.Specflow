using NUnit.Framework;
//using static MarsFrameworkSpecflow.Global.Base;
using System.Reflection;
using MarsFrameworkSpecflow.Global;
using AventStack.ExtentReports;
using MarsFrameworkSpecflow.Pages.ProfilePage;

namespace MarsFrameworkSpecflow.StepDefinitions
{
    [Binding]
    public class ProfilePageStepDefinitions : Base
    {
        ProfilePage profilePage0bj = new ProfilePage();
        //private Exception ex;

        [Given(@"I add a new language record, '([^']*)', '([^']*)'")]
        public void GivenIAddANewLanguageRecord(string language, string languageLevel)
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            try
            {
                profilePage0bj.AddLanguages(language, languageLevel);
            }
            catch (Exception ex)
            {
                test.Log(Status.Info, ex.Message);
            }

        }

        [Then(@"The new language record should be added successfully, '([^']*)', '([^']*)'")]
        public void ThenTheNewLanguageRecordShouldBeAddedSuccessfully(string language, string languageLevel)
        {
            test = extent.CreateTest(MethodBase.GetCurrentMethod()!.Name);
            string alertWindow = profilePage0bj.AlertWindow();
            string expectedMessage = language + " has been added to your languages";

            Assert.That(alertWindow == expectedMessage, "Actual and Expected result did not match");
            test.Log(Status.Pass, "Passed, action successfull.");

        }
    }
}
