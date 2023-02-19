using BuggyCars.Testing.Models;
using OpenQA.Selenium.DevTools.V107.Cast;

namespace BuggyCars_SpecFlow.Models;

public class ConfigurationInfo
{
    public string BaseUrl { get; set; } = string.Empty;

    public WebDriverConfiguration? ChromeDriver { get; set; }
}
