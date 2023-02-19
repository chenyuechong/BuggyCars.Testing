using BuggyCars_SpecFlow.Context;
using TechTalk.SpecFlow;

namespace BuggyCars_SpecFlow.Hooks;

[Binding]
public sealed class Hooks
{
    private readonly WebDriverContext _webDriverContext;

    public Hooks( WebDriverContext webDriver)
    {
        _webDriverContext = webDriver;
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _webDriverContext.WebDriver.Quit();
    }
}