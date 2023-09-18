using OpenQA.Selenium;
using MarsFrameworkSpecflow.Global;
using static MarsFrameworkSpecflow.Global.GlobalDefinitions;

namespace MarsFrameworkSpecflow.Pages.ProfilePage
{
    public class ProfilePage : Base
    {
        public ProfilePage()
        {
            ExcelLib.PopulateInCollection(ExcelPath, "LogIn");
        }

        IWebElement addNewLanguageButton => driver.FindElement(By.XPath("//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        IWebElement addLanguageTextbox => driver.FindElement(By.Name("name"));
        IWebElement languageLevelDropdown => driver.FindElement(By.Name("level"));
        IWebElement addLanguangeButton => driver.FindElement(By.XPath("//*[@value='Add']"));
        IWebElement confirmationAlert => driver.FindElement(By.CssSelector("[class='ns-box-inner']"));

        public void AddLanguages(string language, string languageLevel)
        {
            Wait.WaitToBeVisible("XPath", "//div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 5);
            addNewLanguageButton.Click();
            addLanguageTextbox.SendKeys(language);
            languageLevelDropdown.SendKeys(languageLevel);
            addLanguangeButton.Click();

        }

        public string AlertWindow()
        {
            Wait.WaitToBeVisible("CssSelector", "[class='ns-box-inner']", 5);
            return confirmationAlert.Text;
        }
    }

}
