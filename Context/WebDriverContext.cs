using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BuggyCars_SpecFlow.Context;

public class WebDriverContext
{
    private const string EnableAutomation = "enable-automation";
    private const string Maximized = "--start-maximized";
    private const string EnableCredentail = "credentials_enable_service";
    private const string EnableSavePassword = "profile.password_manager_enabled";
    public IWebDriver WebDriver { get; init; }

    public WebDriverContext(ConfigurationContext configurationContext)
    {
        var chromeOptions = new ChromeOptions();
        if (configurationContext.configuration.ChromeDriver.IsHeadless)
            chromeOptions.AddExcludedArgument(EnableAutomation);
        if (configurationContext.configuration.ChromeDriver.IsMaxStart)
            chromeOptions.AddArguments(Maximized);
        if (configurationContext.configuration.ChromeDriver.IsEnableSavePasswordDialog)
        {
            chromeOptions.AddUserProfilePreference(EnableCredentail, false);
            chromeOptions.AddUserProfilePreference(EnableSavePassword, false);
        }
        
        WebDriver = new ChromeDriver(chromeOptions);
        WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(configurationContext.configuration.ChromeDriver.ImplicitWaitInSeconds);
    }
}
