using OpenQA.Selenium.DevTools.V107.Cast;

namespace BuggyCars_SpecFlow.Models;

public class ConfigurationInfo
{
    public string BaseUrl { get; set; } = string.Empty;

    public DriverConfiguration? ChromeDriver { get; set; }
}

public class DriverConfiguration
{
    public bool IsHeadless { get; set; }

    public bool IsMaxStart { get; set; }

    public bool IsEnableSavePasswordDialog { get; set; }

    public int ImplicitWaitInSeconds { get; set; }
}
