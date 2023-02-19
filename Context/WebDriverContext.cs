using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BuggyCars_SpecFlow.Context;

public class WebDriverContext
{
    public IWebDriver WebDriver { get; init; }

    public WebDriverContext(ConfigurationContext configurationContext)
    {
        var chromeOptions = new ChromeOptions();
        if (configurationContext.configuration.ChromeDriver.IsHeadless)
            chromeOptions.AddExcludedArgument("enable-automation");
        if (configurationContext.configuration.ChromeDriver.IsMaxStart)
            chromeOptions.AddArguments("--start-maximized");
        if (configurationContext.configuration.ChromeDriver.IsEnableSavePasswordDialog)
        {
            chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
        }
        
        WebDriver = new ChromeDriver(chromeOptions);
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(configurationContext.configuration.ChromeDriver.ImplicitWaitInSeconds);
    }
}
