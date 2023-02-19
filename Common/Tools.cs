using OpenQA.Selenium;

namespace BuggyCars_SpecFlow.Common;

internal class Tools
{
    public void SendKeysToArea(IWebElement element, string value)
    {
        element.SendKeys(Keys.Control + "a");
        element.SendKeys(Keys.Delete);
        element.SendKeys(value);
    }
}
