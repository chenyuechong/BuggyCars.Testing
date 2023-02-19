using BuggyCars.Testing.Models;
using BuggyCars_SpecFlow.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BuggyCars.Testing.Pages;

public class ProfilePage
{
    private readonly IWebDriver _webDriver;
    private readonly Tools _tools;

    public ProfilePage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
        _tools = new Tools();
    }

    public IWebElement FirstNameInput
    {
        get => _webDriver.FindElement(By.Id("firstName"));
    }

    public IWebElement LastNameInput
    {
        get => _webDriver.FindElement(By.Id("lastName"));
    }

    public IWebElement UserNameInput
    {
        get => _webDriver.FindElement(By.Id("username"));
    }
    
    public IWebElement SaveBtn
    {
        get => _webDriver.FindElement(By.XPath("//button[contains(text(), 'Save')]"));
    }

    public void ChangeProfile(UserProfile profile)
    {
        _tools.SendKeysToArea(FirstNameInput, profile.firstName);
        _tools.SendKeysToArea(LastNameInput, profile.lastName);
        
        SaveBtn.Click();
        WaitUpdate();
    }

    public void RefreshBrowser() => _webDriver.Navigate().Refresh();

    private void WaitUpdate()
    {
        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        wait.Until(e => e.FindElement(By.XPath("//div[contains(@class, 'result alert alert-success hidden-md-down')]")));
    }
}
