using BuggyCars_SpecFlow.Common;
using OpenQA.Selenium;

namespace BuggyCars_SpecFlow.Pages;

public class RegistrationPage
{
    private IWebDriver _webDriver;
    private Tools _tools;
    public RegistrationPage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
        _tools = new Tools();
    }

    private IWebElement userNameInput => _webDriver.FindElement(By.Id("username"));
    private IWebElement firstNameInput => _webDriver.FindElement(By.Id("firstName"));
    private IWebElement lastNameInput => _webDriver.FindElement(By.Id("lastName"));
    private IWebElement passwordInput => _webDriver.FindElement(By.Id("password"));
    private IWebElement confirmPasswordInput => _webDriver.FindElement(By.Id("confirmPassword"));

    public IWebElement registerBtn => _webDriver.FindElement(By.XPath("//button[contains(text(),'Register')]"));

    public void FillForm(string userName, string firstName, string lastName, string password, string confirmPassword)
    {
        _tools.SendKeysToArea(userNameInput, userName);
        _tools.SendKeysToArea(firstNameInput, firstName);
        _tools.SendKeysToArea(lastNameInput, lastName);
        _tools.SendKeysToArea(passwordInput, password);
        _tools.SendKeysToArea(confirmPasswordInput, confirmPassword);
    }

    public string GetErrorMsg()
    {
        return _webDriver.FindElement(By.XPath("//div[contains(@class,'result alert alert-danger')]")).Text;
    }

    public bool IsRegistrationSuccess() => _webDriver.FindElement(By.XPath("//div[contains(text(),'Registration is successful')]")) != null;
}
