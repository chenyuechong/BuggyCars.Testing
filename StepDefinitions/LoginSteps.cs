using BuggyCars_SpecFlow.Context;
using BuggyCars_SpecFlow.Models;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BuggyCars.Testing.StepDefinitions;

[Binding]
public class LoginSteps
{
    private readonly PageContext _pageContext;

    public LoginSteps(PageContext pageContext)
    {
        _pageContext = pageContext;
    }

    [When(@"user use invalid credential to login")]
    public void WhenUserUseInvalidCredentialToLogin(Table table)
    {
        var data = table.CreateSet<LoginCredential>();
        foreach (var item in data)
        {
            _pageContext.DefaultPage.FillLoginForm(item.userName, item.password);
        }

        _pageContext.DefaultPage.ClickLogin();
    }

    [Then(@"login failed")]
    public void ThenLoginFailed()
    {
        Assert.True(_pageContext.DefaultPage.IsLoginFailed());
    }

    [When(@"user use valid credential to login")]
    public void WhenUserUseValidCredentialToLogin(Table table)
    {
        var data = table.CreateSet<LoginCredential>();
        foreach (var item in data)
        {
            _pageContext.DefaultPage.FillLoginForm(item.userName, item.password);
        }

        _pageContext.DefaultPage.ClickLogin();
    }

    [Then(@"user should see first name in the page")]
    public void ThenUserShouldSeeFirstNameInThePage()
    {
        Assert.True(_pageContext.HomePage.IsLoggedIn());
    }


    [When(@"user click logout")]
    public void WhenUserClickLogout()
    {
        _pageContext.HomePage.Logout();
    }

    [Then(@"register button shows in page")]
    public void ThenRegisterButtonShowsInPage()
    {
        Assert.True(_pageContext.DefaultPage.IsLogout());
    }
}
