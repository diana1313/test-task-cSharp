using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tt_qaa_CSharp
{
    class GoogleSearchResultPage
    {

        private IWebDriver driver;

        public GoogleSearchResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "iUh30")]
        private IList<IWebElement> searchResultsLinks { get; set; }

        [FindsBy(How = How.ClassName, Using = "LC20lb")]
        private IList<IWebElement> searchResultsTittles { get; set; }

        [FindsBy(How = How.Id, Using = "pnnext")]
        private IWebElement nextPageButton { get; set; }

        public void OpenFirstResult()
        {
            searchResultsTittles.First().Click();
        }

        public IList<IWebElement> GetSearchResultsTittles()
        {
            return searchResultsTittles;
        }

        public Optional<IWebElement> CheckDomainName(String domainName)
        {
            foreach (IWebElement resultLink in searchResultsLinks)
            {
                if (resultLink.Text.Contains(domainName))
                {
                    return new Optional<IWebElement>(resultLink);
                }
            }
            return new Optional<IWebElement>(null);
        }


        public bool FindDomainNameInResultsPages(String domainName, int pagesCountToCheck)
        {
            int count = 1;
            while (count < pagesCountToCheck)
            {

                Optional<IWebElement> searchedDomainName = CheckDomainName(domainName);
                if (searchedDomainName.hasValue() && searchedDomainName.getValue().Displayed)
                {
                    Console.WriteLine("Element found");
                    return true;
                }

                GoToNextPage();
                count++;

                if (count > pagesCountToCheck)
                {
                    Console.WriteLine("Reached last page");
                }

            }
            return false;
        }

        public void GoToNextPage()
        {
            nextPageButton.Click();
        }

        public IWebElement GetNextPageButton()
        {
            return nextPageButton;
        }



    }
}
