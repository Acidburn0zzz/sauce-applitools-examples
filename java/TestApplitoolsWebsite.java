import com.applitools.eyes.Eyes;
import com.applitools.eyes.RectangleSize;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.remote.RemoteWebDriver;

import java.net.URL;

public class TestApplitoolsWebsite {

    public static void main(String[] args) throws Exception {

        WebDriver driver = new RemoteWebDriver(new URL("https://YOUR_SAUCE_USERNAME:YOUR_SAUCE_ACCESS_KEY@ondemand.saucelabs.com:443/wd/hub"), DesiredCapabilities.firefox());

        Eyes eyes = new Eyes();
        // This is your api key, make sure you use it in all your tests.
        eyes.setApiKey("YOUR_API_KEY");

        try {
            // Start visual testing with browser viewport set to 1024x768.
            // Make sure to use the returned driver from this point on.
            driver = eyes.open(driver, "Applitools", "Test Web Page", new RectangleSize(1024, 768));

            driver.get("http://applitools.com");

            // Visual validation point #1
            eyes.checkWindow("Main Page");

            driver.findElement(By.cssSelector(".features>a")).click();

            // Visual validation point #2
            eyes.checkWindow("Features page");

            // End visual testing. Validate visual correctness.
            eyes.close();
        } finally {
            // Abort test in case of an unexpected error.
            eyes.abortIfNotClosed();
            driver.close();
        }
    }
 }