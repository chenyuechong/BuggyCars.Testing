using BuggyCars_SpecFlow.Common;
using OpenQA.Selenium;

namespace BuggyCars_SpecFlow.Pages;

public class HomePage
{
    private readonly IWebDriver _webDriver;
    private readonly Tools _tools;

    public HomePage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
        _tools = new Tools();
    }

    public bool IsLoggedIn() => _webDriver.FindElements(By.XPath("//span[contains(text(), 'Hi')]")).Count == 1;

    public void Logout() => _webDriver.FindElement(By.LinkText("Logout")).Click();

    public void GoToProfile() => _webDriver.FindElement(By.LinkText("Profile")).Click();

    public void GoToOverallRating() => _webDriver.FindElement(By.XPath("//a[contains(@href,'/overall')]")).Click();

    public void GoToPopularModel() => _webDriver.FindElement(By.XPath("//a[contains(@href,'/model')]")).Click();

    public void GoToPopularMake() => _webDriver.FindElement(By.XPath("//a[contains(@href,'/make')]")).Click();
}

