using BuggyCars.Testing.Models;
using BuggyCars_SpecFlow.Context;
using BuggyCars_SpecFlow.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BuggyCars.Testing.StepDefinitions;

[Binding]
public class UserProfileSteps
{
    private readonly PageContext _pageContext;

    public UserProfileSteps(PageContext pageContext)
    {
        _pageContext = pageContext;
    }

    [Given(@"user use valid credential login")]
    public void GivenUserUseValidCredentialLogin(Table table)
    {
        var data = table.CreateSet<LoginCredential>();
        foreach (var item in data)
        {
            _pageContext.DefaultPage.FillLoginForm(item.userName, item.password);
        }

        _pageContext.DefaultPage.ClickLogin();
    }

    [Given(@"user already in Profile Page")]
    public void GivenUserAlreadyInProfilePage()
    {
        _pageContext.HomePage.GoToProfile();
    }

    [Given(@"user has profile details")]
    public void GivenUserHasProfileDetails(Table table)
    {
        var data = table.CreateSet<UserProfile>();
        foreach (var item in data)
        {
            Assert.AreEqual(_pageContext.ProfilePage.UserNameInput.GetAttribute("value"), item.userName);
            Assert.AreEqual(_pageContext.ProfilePage.FirstNameInput.GetAttribute("value"), item.firstName);
            Assert.AreEqual(_pageContext.ProfilePage.LastNameInput.GetAttribute("value"), item.lastName);
        }
    }

    [When(@"change name to")]
    [Then(@"restore test data")]
    public void WhenChangeNameTo(Table table)
    {
        var data = table.CreateSet<UserProfile>();
        foreach (var item in data)
        {
            _pageContext.ProfilePage.ChangeProfile(item);
        }
    }

    [When(@"refresh page")]
    public void WhenRefreshPage()
    {
        _pageContext.ProfilePage.RefreshBrowser();
        _pageContext.HomePage.GoToProfile();
    }

    [Then(@"user should see details")]
    public void ThenUserShouldSeeDetails(Table table)
    {
        var data = table.CreateSet<UserProfile>();
        foreach (var item in data)
        {
            Assert.AreEqual(_pageContext.ProfilePage.UserNameInput.GetAttribute("value"), item.userName);
            Assert.AreEqual(_pageContext.ProfilePage.FirstNameInput.GetAttribute("value"), item.firstName);
            Assert.AreEqual(_pageContext.ProfilePage.LastNameInput.GetAttribute("value"), item.lastName);
        }
    }
}
