using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TolarusWebsiteTest
{
	public class TolarusWebsite
	{

		IWebDriver driver;
		string targetTestPage = "http://tolarus.co.uk/";

		static object[] NavigationCases =
		{
			new object[] { "About", "http://tolarus.co.uk/about"},
			new object[] { "NutriLabel", "http://tolarus.co.uk/products"},
			new object[] { "Contact", "http://tolarus.co.uk/contact"}
		};

		public void GoToTestPage()
		{
			driver.Url = targetTestPage;
		}

		public IWebElement FindLinkViaText(string linkText)
		{
			return driver.FindElement(By.LinkText(linkText));
		}

		[SetUp]
		public void Setup()
		{
			ChromeOptions options = new ChromeOptions();

			options.AddArgument("--start-maximized");

			driver = new ChromeDriver("C:/WebDriver/", options);
		}

		[Test]
		public void WebsiteTitleIsCorrect()
		{
			GoToTestPage();

			string expected = "Tolarus Software";

			Assert.AreEqual(expected, driver.Title);

		}

		[Test, TestCaseSource("NavigationCases")]
		public void HomePageNavigationLinks(string linkText, string expected)
		{

			GoToTestPage();

			var link = FindLinkViaText(linkText);

			link.Click();

			Assert.AreEqual(expected, driver.Url);

			
		}

		[TearDown]
		public void CleanUp()
		{
			driver.Quit();
		}
	}
}
