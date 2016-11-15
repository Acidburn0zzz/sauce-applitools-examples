using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Applitools;

namespace MyTests
{
    public class TestApplitoolsWebsite
    {
        public static void Main(string[] args)
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("browserName", "Firefox");
            caps.SetCapability("username", "YOUR_SAUCE_USERNAME");
            caps.SetCapability("accessKey", "YOUR_SAUCE_ACCESS_KEY");
            IWebDriver driver =  new RemoteWebDriver(new Uri("https://ondemand.saucelabs.com:443/wd/hub"), caps, TimeSpan.FromSeconds(600));

            // This is your api key, make sure you use it in all your tests.
            var eyes = new Eyes();
            eyes.ApiKey = "YOUR_API_KEY";

            try
            {
                // Start visual testing with browser viewport set to 1024x768.
                // Make sure to use the returned driver from this point on.
                driver = eyes.Open(driver, "Applitools", "Test Web Page", new Size(1024, 768));

                driver.Navigate().GoToUrl("http://www.applitools.com");

                // Visual validation point #1
                eyes.CheckWindow("Main Page");

                driver.FindElement(By.CssSelector(".features>a")).Click();

                // Visual validation point #2
                eyes.CheckWindow("Features Page");

                // End visual testing. Validate visual correctness.
                eyes.Close();
            }
            finally
            {
                eyes.AbortIfNotClosed();
                driver.Quit();
            }
        }
    }
}