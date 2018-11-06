
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace tt_qaa_CSharp
{


    public class Runner
    {


        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver();
            PropertiesCollection.driver.Navigate().GoToUrl("https://www.google.com");
            Console.WriteLine("Url opened in Chrome Browser");
        }

        [Test]
        public void GoogleSearchTest()
        {
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(PropertiesCollection.driver);

            googleSearchPage.TypeInSearch("automation");
            GoogleSearchResultPage googleSearchResultPage = googleSearchPage.StartSearch();
            googleSearchResultPage.OpenFirstResult();
            Console.WriteLine("Title  of : ' " + PropertiesCollection.driver.Title + "' , should contains searched data");
            Assert.IsTrue(PropertiesCollection.driver.Title.ToLower().Contains("automation"), "Title doesn't contain searched data");

        }

        [Test]
        public void DomainNameTest()
        {
            GoogleSearchPage googleSearchPage = new GoogleSearchPage(PropertiesCollection.driver);

            googleSearchPage.TypeInSearch("automation");
            GoogleSearchResultPage googleSearchResultPage = googleSearchPage.StartSearch();
            Assert.IsTrue(googleSearchResultPage.FindDomainNameInResultsPages("testautomationday.com", 5), "Domain is not found in results");
            Console.WriteLine("Domain name should be present on first 5 result pages");

        }

        [TearDown]
        public void CloseBrowser()
        {
            PropertiesCollection.driver.Close();
            Console.WriteLine("Browser closed");

        }

    }
}
