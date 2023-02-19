using OpenQA.Selenium;

namespace BuggyCars.Testing.Pages;

public class OverallRatingPage
{
    private readonly IWebDriver _webDriver;
    public OverallRatingPage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public bool FindMake(string make)
    {
        IWebElement nextPage = _webDriver.FindElement(By.LinkText("»"));
        
        // Currently, there is a paging bug that the next page button still clickable even
        // though navigated to the last page. 
        while (nextPage.Enabled)
        {
            if(_webDriver.FindElements(By.LinkText(make)).Count == 0)
                nextPage.Click();
            else
                return true;
        }

        return false;
    }

    public void GotoMakeDetails(string make)
    {
        var first = (IWebElement?)_webDriver.FindElements(By.LinkText(make)).FirstOrDefault() ??
            throw new ApplicationException("Make details page cannot be found");

        first.Click();
    }
}
