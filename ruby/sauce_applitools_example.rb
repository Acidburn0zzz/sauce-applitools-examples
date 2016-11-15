require 'eyes_selenium'
require 'selenium-webdriver'

eyes = Applitools::Eyes.new
# This is your api key, make sure you use it in all your tests.
eyes.api_key = 'YOUR_API_KEY'

# Get a selenium web driver object.
caps = Selenium::WebDriver::Remote::Capabilities.firefox()
my_webdriver = Selenium::WebDriver.for(:remote,
    :url => "https://YOUR_SAUCE_USERNAME:YOUR_SAUCE_ACCESS_KEY@ondemand.saucelabs.com:443/wd/hub",
    :desired_capabilities => caps)

begin
    # Start visual testing using my_webdriver and setting the viewport to 1024x768.
    eyes.test(app_name: 'Applitools', test_name: 'Test Web Page',
        viewport_size: {width: 1024, height: 768}, driver: my_webdriver) do |driver|
    driver.get 'http://www.applitools.com'
    # Visual validation point #1
    eyes.check_window('Main Page')
    driver.find_element(:css, ".features>a").click
    # Visual validation point #2
    eyes.check_window('Features Page')
end
ensure
    my_webdriver.quit
end