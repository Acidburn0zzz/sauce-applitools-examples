from selenium import webdriver
from applitools.eyes import Eyes

eyes = Eyes()
# This is your api key, make sure you use it in all your tests.
eyes.api_key = 'YOUR_API_KEY'

# Get a selenium web driver object.
desired_cap = webdriver.DesiredCapabilities.FIREFOX
driver = webdriver.Remote(
   command_executor='http://YOUR_SAUCE_USERNAME:YOUR_SAUCE_ACCESS_KEY@ondemand.saucelabs.com:80/wd/hub',
   desired_capabilities=desired_cap)

try:
    # Start visual testing with browser viewport set to 1024x768.
    # Make sure to use the returned driver from this point on.
    driver = eyes.open(driver=driver, app_name='Applitools', test_name='Test Web Page',
                       viewport_size={'width': 1024, 'height': 768})
    driver.get('http://www.applitools.com')

    # Visual validation point #1
    eyes.check_window('Main Page')

    driver.find_element_by_css_selector('.features>a').click()

    # Visual validation point #2
    eyes.check_window('Features Page')

    # End visual testing. Validate visual correctness.
    eyes.close()
finally:
    driver.quit()
    eyes.abort_if_not_closed()
