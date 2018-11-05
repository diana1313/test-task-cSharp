using OpenQA.Selenium;
using System;
using SeleniumExtras.PageObjects;


namespace tt_qaa_CSharp
{
    class GoogleSearchPage
    { 
        public GoogleSearchPage (IWebDriver driver)
        { 
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "lst-ib")]
        private IWebElement searchInput { get; set; }

        [FindsBy(How = How.Name, Using = "btnK")]
        private IWebElement searchButton { get; set; }


        public void TypeInSearch (String request)
        {
            searchInput.SendKeys(request);
        }

        public GoogleSearchResultPage StartSearch ()
        {
            searchButton.Submit();
            return new GoogleSearchResultPage(PropertiesCollection.driver);
        }

    }
}
