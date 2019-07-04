using Applitools;
using Applitools.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;


namespace ApplitoolsTutorial
{

    [TestFixture]
    public class AppTest
    {
        private EyesRunner runner;
        private Eyes eyes;

        private IWebDriver driver;

        [SetUp]
        public void BeforeEach()
        {
            //Initialize the Runner for your test.
            runner = new ClassicRunner();

            // Initialize the eyes SDK and set your private API key.
            eyes = new Eyes(runner);

            eyes.SetLogHandler(new StdoutLogHandler(true));
            // Check if the Applitools API key is set in the environment

            if (Environment.GetEnvironmentVariable("APPLITOOLS_API_KEY") == null)
            {
                string message = "\n" +
                    "\n**** Please set APPLITOOLS_API_KEY in your environment ***" +
                    "\nOn Mac/Linux: export APPLITOOLS_API_KEY='YOUR_API_KEY'" +
                    "\nOn Windows: set APPLITOOLS_API_KEY='YOUR_API_KEY'";
                Assert.Fail(message);
            }

            driver = new ChromeDriver();
        }


        [Test]
        public void LoginPage1()
        {
            // Start the test by setting AUT's name, window or the page name that's being tested, viewport width and height
            eyes.Open(driver, "Acme app", "Login Page", new Size(1200, 700));

            // Navigate the browser to the "ACME" demo app
            driver.Url = "https://demo.applitools.com/index.html";

            // Visual checkpoint #1.
            eyes.CheckWindow("Login Page");

            // End the test.
            eyes.CloseAsync();
        }

        [Test]
        public void LoginPage2()
        {
            // Start the test by setting AUT's name, window or the page name that's being tested, viewport width and height
            eyes.Open(driver, "Acme app", "Login Page", new Size(1200, 700));

            // Navigate the browser to the "ACME" demo app
            driver.Url = "https://demo.applitools.com/index_v2.html";

            // Visual checkpoint #1.
            eyes.CheckWindow("Login Page");

            // End the test.
            eyes.CloseAsync();
        }

        [Test]
        public void MainPage1()
        {
            // Start the test by setting AUT's name, window or the page name that's being tested, viewport width and height
            eyes.Open(driver, "Acme app", "Main Page", new Size(1200, 800));

            // Navigate the browser to the "ACME" demo app
            driver.Url = "https://demo.applitools.com/app.html";

            // Visual checkpoint #1.
            eyes.CheckWindow("Main Page");

            // End the test.
            eyes.CloseAsync();
        }

        [Test]
        public void MainPage2()
        {
            // Start the test by setting AUT's name, window or the page name that's being tested, viewport width and height
            eyes.Open(driver, "Acme app", "Main Page", new Size(1200, 800));

            // Navigate the browser to the "ACME" demo app
            driver.Url = "https://demo.applitools.com/app_v2.html";

            // Visual checkpoint #1.
            eyes.CheckWindow("Main Page");

            // End the test.
            eyes.CloseAsync();
        }


        [TearDown]
        public void AfterEach()
        {
            // Close the browser.
            driver.Quit();

            // If the test was aborted before eyes.close was called, ends the test as
            // aborted.
            eyes.AbortIfNotClosed();

            //Wait and collect all test results
            TestResultSummary allTestResults = runner.GetAllTestResults();
        }

    }
}
