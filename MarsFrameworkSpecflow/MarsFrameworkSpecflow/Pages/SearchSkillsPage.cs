using OpenQA.Selenium;
using MarsFrameworkSpecflow.Global;
using static MarsFrameworkSpecflow.Global.GlobalDefinitions;

namespace MarsFrameworkSpecflow.Pages
{
    public class SearchSkillsPage : Base
    {
        public SearchSkillsPage()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkill");
        }

        IWebElement searchSkillTextArea => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/input"));
        IWebElement searchIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/i"));
        IWebElement searchUserTextArea => driver.FindElement(By.XPath("//*[@class=\"ui icon input fluid\"]/input"));
        IWebElement search => driver.FindElement(By.XPath("//span[text()='" + ExcelLib.ReadData(testRow, "SearchUser") + "']"));
        IWebElement getSellerName => driver.FindElement(By.XPath("//*[@class=\"seller-info\"]"));
        IWebElement searchSkillsFromResults => driver.FindElement(By.XPath("//*[@class=\"four wide column\"]/div[2]/input"));
        IWebElement searchIconFromResults => driver.FindElement(By.XPath("//*[@class=\"four wide column\"]/div[2]/i"));
        IWebElement openSellerDetails => driver.FindElement(By.XPath("//*[@class=\"ui stackable three cards\"]/div[1]/a[1]/img[1]"));
        IWebElement skillTitle => driver.FindElement(By.XPath("//*[@class=\"skill-title\"]"));
        IWebElement skillDescription => driver.FindElement(By.XPath("//*[@class=\"sixteen wide column\"]/div[1]/div/div/div[2]"));
        IWebElement searchCategory => driver.FindElement(By.XPath("//*[@class=\"item category\" and contains(text(), '" + ExcelLib.ReadData(testRow, "Category") + "')]"));
        IWebElement searchSubcategory => driver.FindElement(By.XPath("//*[@class=\"item subcategory\" and contains(text(), '" + ExcelLib.ReadData(testRow, "SubCategory") + "' )]"));

        IWebElement filterOnline => driver.FindElement(By.XPath("//*[@class=\"ui button\" and contains(text(), \"Online\")]"));
        IWebElement filterOnsite => driver.FindElement(By.XPath("//*[@class=\"ui button\" and contains(text(), \"Onsite\")]"));
        IWebElement filterShowAll => driver.FindElement(By.XPath("//*[@class=\"ui button\" and contains(text(), \"ShowAll\")]"));
        IWebElement getLocationType => driver.FindElement(By.XPath("//*[@class=\"ui grid\"]/div[3]/div[1]/div[3]/div/div[2]"));
        IWebElement resultsPerPage18 => driver.FindElement(By.XPath("//*[@class=\"right floated column \"]/button[3]"));
        IWebElement searchResults => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span"));
        IWebElement SecondTolastPage => driver.FindElement(By.XPath("//*[@class=\"ui buttons semantic-ui-react-button-pagination\"]/button[last()-2]"));
        IWebElement lastPage => driver.FindElement(By.XPath("//*[@class=\"ui buttons semantic-ui-react-button-pagination\"]/button[last()-1]"));
        IWebElement searchUserResult => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]"));
        IWebElement searchNotice => driver.FindElement(By.XPath("//*[@id=\"main-message\"]/h1/span"));
        IWebElement searchResultAlert => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/h3"));

        List<IWebElement> resultsAsAString => new List<IWebElement>(driver.FindElements(By.XPath("//*[@class='item category']/*[@class='right-floated']")));
        List<IWebElement> resultsAsAStringSubcategory => new List<IWebElement>(driver.FindElements(By.XPath("//*[@class='item subcategory']/*[@class='right-floated']")));
        List<IWebElement> numberOfResults => new List<IWebElement>(driver.FindElements(By.XPath("//*[@class=\"seller-info\"]")));
        List<IWebElement> numberOfResultsLastPage => new List<IWebElement>(driver.FindElements(By.XPath("//*[@class=\"seller-info\"]")));
        List<IWebElement> numberOfResultsPerPage => new List<IWebElement>(driver.FindElements(By.XPath("//*[@class=\"seller-info\"]")));


        public void SearchSkillsHomePage()
        {
            Wait.WaitToBeClickable("XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[1]/input", 5);
            searchSkillTextArea.SendKeys(ExcelLib.ReadData(testRow, "SearchSkill"));
            searchIcon.Click();

        }

        public void SearchUserFromResult()
        {
            searchUserTextArea.SendKeys(ExcelLib.ReadData(testRow, "SearchUser"));
            Wait.WaitToBeClickable("XPath", "//span[text()='" + ExcelLib.ReadData(testRow, "SearchUser") + "']", 5);
            search.Click();
        }

        public string GetSellerName()
        {
            Wait.WaitToBeVisible("XPath", "//*[@class=\"seller-info\"]", 5);
            return getSellerName.Text;
        }

        public void SearchSkillsFromResults()
        {
            Wait.WaitToBeVisible("XPath", "//*[@class=\"four wide column\"]/div[2]/input", 5);
            searchSkillsFromResults.SendKeys(ExcelLib.ReadData(testRow, "SearchBySkill"));
            searchIconFromResults.Click();
        }

        public void OpenSellerDetails()
        {
            Wait.WaitToBeClickable("XPath", "//*[@class=\"ui stackable three cards\"]/div[1]/a[1]/img[1]", 5);
            //Thread.Sleep(1000);
            openSellerDetails.Click();
        }
        public bool GetSkillTitleAndDescription()
        {
            //Wait.WaitToBeVisible("XPath", "//*[@class=\"ui button\" and contains(text(), \"ShowAll\")]", 5);

            if (skillTitle.Text.Contains(ExcelLib.ReadData(testRow, "SearchBySkill"), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(skillTitle.Text);
                if (skillDescription.Text.Contains(ExcelLib.ReadData(testRow, "SearchBySkill"), StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(skillDescription.Text);
                    return true;
                }
            }
            return false;
        }

        public void ViewCategory()
        {
            Wait.WaitToBeVisible("XPath", "//*[@class=\"item category\" and contains(text(), '" + ExcelLib.ReadData(testRow, "Category") + "')]", 5);
            searchCategory.Click();
        }

        public void ViewSubCategory()
        {
            Wait.WaitToBeVisible("XPath", "//*[@class=\"item subcategory\" and contains(text(), '" + ExcelLib.ReadData(testRow, "SubCategory") + "' )]", 5);
            searchSubcategory.Click();
        }

        public void ViewHighestMatchCategory()
        {
            Thread.Sleep(1000);
            List<int> resultNumbers = new List<int>();

            foreach (IWebElement result in resultsAsAString)
            {
                int number;
                if (int.TryParse(result.Text, out number))
                {
                    resultNumbers.Add(number);
                }
            }
            // if resultNumbers.Count is true, execute resultNumbers.Max else return 0.
            int highestValue = resultNumbers.Count > 0 ? resultNumbers.Max() : 0;
            Console.WriteLine(string.Join(" | ", highestValue));
            IWebElement highestResult = driver.FindElement(By.XPath("//*[@class=\"right-floated\" and contains(text(), " + highestValue + ")]"));
            highestResult.Click();

        }

        public void ViewHighestMatchSubCategory()
        {
            Thread.Sleep(1000);
            List<int> resultNumbers = new List<int>();

            foreach (IWebElement result in resultsAsAStringSubcategory)
            {
                int number;
                if (int.TryParse(result.Text, out number))
                {
                    resultNumbers.Add(number);
                }
            }
            // if resultNumbers.Count is true, execute resultNumbers.Max else return 0.
            int highestValueSubCategory = resultNumbers.Count > 0 ? resultNumbers.Max() : 0;
            IWebElement highestResultSubcategory = driver.FindElement(By.XPath("//*[@class='item subcategory']/*[@class='right-floated' and contains(text(), " + highestValueSubCategory + ")]"));

            Console.WriteLine(string.Join(" | ", highestValueSubCategory));
            highestResultSubcategory.Click();
        }

        //Filter
        public void FilterOnline()
        {
            Wait.WaitToBeVisible("XPath", "//*[@class=\"ui button\" and contains(text(), \"Online\")]", 5);
            filterOnline.Click();
        }

        public void FilterOnsite()
        {
            Wait.WaitToBeVisible("XPath", "//*[@class=\"ui button\" and contains(text(), \"Onsite\")]", 5);
            filterOnsite.Click();
            Task.Delay(1000).Wait();
        }

        public void FilterShowAll()
        {
            Wait.WaitToBeVisible("XPath", "//*[@class=\"ui button\" and contains(text(), \"ShowAll\")]", 5);
            filterShowAll.Click();
        }

        public string GetLocationType()
        {
            Wait.WaitToBeVisible("XPath", "//*[@class=\"ui grid\"]/div[3]/div[1]/div[3]/div/div[2]", 5);
            return getLocationType.Text;
        }

        public void ResultsPerPage()
        {
            Wait.WaitToBeVisible("XPath", "//*[@class=\"right floated column \"]/button[3]", 5);
            resultsPerPage18.Click();
        }
        // verify total number of results
        public int GetActualNumberOfResults()
        {
            Wait.WaitToBeVisible("XPath", "//*[@class=\"ui buttons semantic-ui-react-button-pagination\"]/button[last()-2]", 5);
            int SecondTolastPageNumber;
            int.TryParse(SecondTolastPage.Text, out SecondTolastPageNumber);
            Console.WriteLine("Number of Pages with max number of displayed results: " + SecondTolastPageNumber);

            int totalCount = 0;
            for (int page = 1; page <= SecondTolastPageNumber; page++)
            {
                //totalcount = totalcount + numberofresults
                totalCount += numberOfResults.Count;
            }

            lastPage.Click();
            Task.Delay(1000).Wait();
            Console.WriteLine(numberOfResultsLastPage.Count);
            return totalCount + numberOfResultsLastPage.Count;

        }

        public int GetExpectedNumberOfResults()
        {
            Task.Delay(1000).Wait();
            //Wait.WaitToBeClickable("XPath", "//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[1]/div[1]/div/a[1]/span", 5);
            int searchResultInt;
            int.TryParse(searchResults.Text, out searchResultInt);
            Console.WriteLine(searchResultInt);
            return searchResultInt;
        }

        public int GetNumberOfResultsPerPage()
        {
            //Wait.WaitToBeClickable("XPath", "//*[@class='seller-info']", 5);
            //Thread.Sleep(1500);
            Task.Delay(1000).Wait();
            return numberOfResultsPerPage.Count;
        }

        public string GetNotWorkingNotice()
        {
            return searchNotice.Text;
        }

        public string LocateSearchUserResultPanel()
        {
            searchUserTextArea.SendKeys(ExcelLib.ReadData(testRow, "SearchUser"));
            return searchUserResult.GetAttribute("class");
        }

        public string SearchResultAlert()
        {
            return searchResultAlert.Text;
        }
    }
}
