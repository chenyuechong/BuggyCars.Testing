using BuggyCars_SpecFlow.Context;
using BuggyCars_SpecFlow.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BuggyCars_SpecFlow.StepDefinitions;

[Binding]
public class RegistrationSteps
{
    private readonly PageContext _pageContext;

    private string _radomUserName = string.Empty;
    private string _radomPassword = string.Empty;
    private IEnumerable<RegisterationInfo> _registrations;
    public RegistrationSteps(PageContext pageContext)
    {
        _pageContext = pageContext;
    }

    [Given(@"user open BuggyCars website")]
    public void GivenUserOpenBuggyCarsWebsite()
    {
        _pageContext.DefaultPage.LoadPage();
    }

    [When(@"user click register button on the top")]
    public void WhenUserClickRegisterButtonOnTheTop()
    {
        _pageContext.DefaultPage.ClickRegister();
    }

    [When(@"enter following invalid data")]
    public void WhenEnterFollowingInvalidData(Table table)
    {
        _registrations = table.CreateSet<RegisterationInfo>();  
    }

    [Then(@"the register button should be disable")]
    public void ThenTheRegisterButtonShouldBeDisable()
    {
        foreach (var item in _registrations)
        {
            _pageContext.RegistrationPage.FillForm(item.UserName, item.FirstName,
                item.LastName, item.Password, item.ConfirmPassword);
            Assert.False(_pageContext.RegistrationPage.registerBtn.Enabled);
        }
    }

    [When(@"enter following data to register")]
    public void WhenEnterFollowingDataToRegister(Table table)
    {
        _radomUserName = Guid.NewGuid().ToString("n").Substring(0, 8);
        var data = table.CreateSet<RegisterationInfo>();

        foreach (var item in data)
        {
            _pageContext.RegistrationPage.FillForm(_radomUserName, _radomUserName,
                item.LastName, item.Password, item.ConfirmPassword);
            _radomPassword = item.Password;
        }

        _pageContext.RegistrationPage.registerBtn.Click();
    }
    

    [Then(@"lenght of password error shows in page")]
    public void ThenLenghtOfPasswordErrorShowsInPage()
    {
        Assert.True(_pageContext.RegistrationPage.GetErrorMsg().Contains("minimum field size of 6"));
    }

    [Then(@"password police error shows in page")]
    public void ThenPasswordPoliceErrorShowsInPage()
    {
        Assert.True(_pageContext.RegistrationPage.GetErrorMsg().Contains("Password did not conform with policy"));
    }

    [Then(@"register successfully")]
    public void ThenRegisterSuccessfully()
    {
        Assert.True(_pageContext.RegistrationPage.IsRegistrationSuccess());
    }

    [When(@"use creditial to login")]
    [Then(@"use creditial to login")]
    public void WhenUseCreditialToLogin()
    {
        _pageContext.DefaultPage.LoadPage();
        _pageContext.DefaultPage.FillLoginForm(_radomUserName, _radomPassword);
        _pageContext.DefaultPage.ClickLogin();
        Assert.True(_pageContext.HomePage.IsLoggedIn());
    }

    [When(@"click populor model")]
    public void WhenClickPopulorModel()
    {
        _pageContext.HomePage.GoToPopularModel();
    }

    [When(@"add a comment ""([^""]*)""")]
    public void WhenAddAComment(string comment)
    {
        _pageContext.ModelPage.AddComment(comment);
    }

    [When(@"click vote button")]
    public void WhenClickVoteButton()
    {
        _pageContext.ModelPage.ClickVoteButton();
    }

    [Then(@"votes should plus one")]
    public void ThenVotesShouldPlusOne()
    {
        _pageContext.ModelPage.WaitVoteResult();
        Assert.True(_pageContext.ModelPage.IsVotePlusOne());
    }
}
