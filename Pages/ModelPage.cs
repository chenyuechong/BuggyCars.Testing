using BuggyCars_SpecFlow.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BuggyCars.Testing.Pages;

public class ModelPage
{
    private readonly IWebDriver _webDriver;
    private readonly Tools _tools;
    private int _defaultVotes;

    public ModelPage(IWebDriver webDriver)
    {
        _webDriver = webDriver;
        _tools = new Tools();
    }

    public string VoteInfo
    {
        get => _webDriver.FindElement(By.ClassName("card-text")).Text;
    }

    public string ModelName
    {
        get => _webDriver.FindElement(By.TagName("h3")).Text;
    }

    public void AddComment(string comment)
    {
        if (int.TryParse(GetVotes(), out _defaultVotes))
        {
            _tools.SendKeysToArea(_webDriver.FindElement(By.TagName("textarea")), comment);
        }
    }

    public string GetVotes()
    {
        return _webDriver.FindElement(By.XPath("//h4[contains(text(), 'Votes')]/strong")).Text;
    }

    public void ClickVoteButton()
    {
        _webDriver.FindElement(By.TagName("button")).Click();
    }

    public void WaitVoteResult()
    {
        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        wait.Until(e => e.FindElement(By.XPath("//p[contains(text(),'Thank you for your vote')]")));
    }

    public bool IsVotePlusOne() 
    {
        if (int.TryParse(GetVotes(), out var vote))
        {
            return vote - _defaultVotes == 1;
        }

        return false;
    }
}
