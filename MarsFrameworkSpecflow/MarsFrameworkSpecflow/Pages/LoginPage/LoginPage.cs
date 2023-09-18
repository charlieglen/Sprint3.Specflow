using OpenQA.Selenium;
using MarsFrameworkSpecflow.Global;
using static MarsFrameworkSpecflow.Global.GlobalDefinitions;

namespace MarsFrameworkSpecflow.Pages.LoginPage

{
    public class LoginPage : Base
    {
        public LoginPage()
        {
            ExcelLib.PopulateInCollection(ExcelPath, "LogIn");
        }
        IWebElement signinButton => driver.FindElement(By.CssSelector("[class=\"item\"]"));
        IWebElement emailTextbox => driver.FindElement(By.Name("email"));
        IWebElement passwordTextbox => driver.FindElement(By.Name("password"));
        IWebElement rememberMeCheckbox => driver.FindElement(By.Name("rememberDetails"));
        IWebElement loginButton => driver.FindElement(By.XPath("//*[contains(text(),'Login')]"));

        public void LogInActions()
        {
            signinButton.Click();
            emailTextbox.SendKeys(ExcelLib.ReadData(2, "UserEmail"));
            passwordTextbox.SendKeys(ExcelLib.ReadData(2, "Password"));
            rememberMeCheckbox.Click();
            loginButton.Click();
        }
    }
}
