using BuggyCars.Testing.Pages;
using BuggyCars_SpecFlow.Pages;

namespace BuggyCars_SpecFlow.Context;

public class PageContext
{
    public DefaultPage DefaultPage { get; init; }

    public RegistrationPage RegistrationPage { get; init; }

    public HomePage HomePage { get; init; }

    public ProfilePage ProfilePage { get; init; }

    public OverallRatingPage OverallRateingPage { get; init; }

    public MakePage MakePage { get; init; }

    public ModelPage ModelPage { get; init; }

    public PageContext(ConfigurationContext config, WebDriverContext webDriver)
    {
        DefaultPage = new DefaultPage(webDriver.WebDriver, config.configuration.BaseUrl);
        RegistrationPage = new RegistrationPage(webDriver.WebDriver);
        HomePage = new HomePage(webDriver.WebDriver);
        ProfilePage = new ProfilePage(webDriver.WebDriver);
        OverallRateingPage = new OverallRatingPage(webDriver.WebDriver);
        MakePage = new MakePage(webDriver.WebDriver);
        ModelPage = new ModelPage(webDriver.WebDriver);
    }
}
