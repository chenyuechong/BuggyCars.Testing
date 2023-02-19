using BuggyCars_SpecFlow.Common;
using OpenQA.Selenium;

namespace BuggyCars_SpecFlow.Pages;

public class DefaultPage
{
    private readonly IWebDriver _webDriver;
    private readonly string _baseURL;
    private readonly Tools _tools;

    public DefaultPage(IWebDriver webDriver, String baseUrl)
    {
        _webDriver= webDriver;
        _baseURL = baseUrl;
        _tools = new Tools();
    }

    public void LoadPage()
    {
        _webDriver.Navigate().GoToUrl(_baseURL);
    }

    public void ClickRegister()
    {
        _webDriver.FindElement(By.LinkText("Register")).Click();
    }

    public void FillLoginForm(string userName, string password)
    {
        _tools.SendKeysToArea(_webDriver.FindElement(By.Name("login")), userName);
        _tools.SendKeysToArea(_webDriver.FindElement(By.Name("password")),password);
    }

    public void ClickLogin() => _webDriver.FindElement(By.XPath("//button[contains(text(), 'Login')]")).Click();

    public bool IsLoginFailed() => _webDriver.FindElements(By.XPath("//span[contains(@class,'label label-warning')]")).Count == 1 ? true : false;

    public bool IsLogout() => _webDriver.FindElement(By.LinkText("Register")) != null;
}
