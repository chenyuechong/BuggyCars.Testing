using BuggyCars_SpecFlow.Context;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BuggyCars.Testing.StepDefinitions;

[Binding]
public class ViewVotesStep
{
    private readonly PageContext _pageContext;
    private string votes = string.Empty;

    public ViewVotesStep(PageContext pageContext)
    {
        _pageContext = pageContext;
    }

    [Given(@"user click Overall Rating")]
    public void GivenUserClickOverallRating()
    {
        _pageContext.HomePage.GoToOverallRating();
    }
    
    [When(@"look for (.*) in overall rating list")]
    public void WhenLookForInOverallRatingList(string make)
    {
        Assert.True(_pageContext.OverallRateingPage.FindMake(make));
    }

    [When(@"click make (.*)")]
    public void WhenClickMake(string make)
    {
        _pageContext.OverallRateingPage.GotoMakeDetails(make);
    }

    [Then(@"Model (.*) should be in page")]
    public void ThenModelShouldBeInPage(string model)
    {
        Assert.True(_pageContext.MakePage.IsModelExist(model));
    }

    [When(@"user click Model (.*)")]
    public void WhenUserClickModel(string model)
    {
        votes = _pageContext.MakePage.GetModelVotes(model);
        _pageContext.MakePage.GotoModel(model);
    }

    [Then(@"votes number should be the same between make page and model page")]
    public void ThenVotesNumberShouldBeTheSameBetweenMakePageAndModelPage()
    {
        Assert.AreEqual(votes, _pageContext.ModelPage.GetVotes());
    }

    [Then(@"login required message should be in page")]
    public void ThenLoginRequiredMessageShouldBeInPage()
    {
        Assert.True(_pageContext.ModelPage.VoteInfo.Contains("You need to be logged in to vote"));
    }

    [Then(@"voted message should be in page")]
    public void ThenVotedMessageShouldBeInPage()
    {
        Assert.True(_pageContext.ModelPage.VoteInfo.Contains("Thank you for your vote!"));
    }

}
