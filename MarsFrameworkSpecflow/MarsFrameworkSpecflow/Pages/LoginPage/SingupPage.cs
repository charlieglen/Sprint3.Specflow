using MarsFrameworkSpecflow.Global;
using OpenQA.Selenium;
using static MarsFrameworkSpecflow.Global.GlobalDefinitions;

namespace MarsFrameworkSpecflow.Pages.LoginPage
{
    public class SignupPage : Base
    {
        public SignupPage()
        {
            ExcelLib.PopulateInCollection(ExcelPath, "Signup");
        }
        //public static IWebElement signupPage => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/button"));
        IWebElement joinSkillShare => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/a"));
        IWebElement firstName => driver.FindElement(By.Name("firstName"));
        IWebElement lastName => driver.FindElement(By.Name("lastName"));
        IWebElement emailAddress => driver.FindElement(By.Name("email"));
        IWebElement password => driver.FindElement(By.Name("password"));
        IWebElement confirmPassword => driver.FindElement(By.Name("confirmPassword"));
        IWebElement terms => driver.FindElement(By.Name("terms"));
        IWebElement joinButton => driver.FindElement(By.Id("submit-btn"));


        public void SignUp()
        {
            //signupPage.Click();
            joinSkillShare.Click();
            firstName.SendKeys(ExcelLib.ReadData(2, "First Name"));
            lastName.SendKeys(ExcelLib.ReadData(2, "Last Name"));
            emailAddress.SendKeys(ExcelLib.ReadData(2, "UserEmail"));
            password.SendKeys(ExcelLib.ReadData(2, "Password"));
            confirmPassword.SendKeys(ExcelLib.ReadData(2, "Password"));
            terms.Click();
            joinButton.Click();


        }
    }
}
