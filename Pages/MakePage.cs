using OpenQA.Selenium;

namespace BuggyCars.Testing.Pages;

public class MakePage
{
    private readonly IWebDriver _webDriver;

    public MakePage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public string MakeName
    {
        get => _webDriver.FindElement(By.TagName("h3")).Text;
    }

    public bool IsModelExist(string model) => _webDriver.FindElement(By.LinkText(model)) != null;

    public void GotoModel(string model) => _webDriver.FindElement(By.LinkText(model)).Click();

    public string GetModelVotes(string model)
    {
        string xpathStr = $"//a[contains(text(),'{model}')]/../../td";

        return _webDriver.FindElements(By.XPath(xpathStr))[3].Text;
    }
}
