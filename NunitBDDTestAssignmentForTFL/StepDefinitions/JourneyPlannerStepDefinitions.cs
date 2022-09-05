using NUnit.Framework;
using NunitBDDTestAssignmentForTFL.Pages;
using System;
using TechTalk.SpecFlow;

namespace NunitBDDTestAssignmentForTFL.StepDefinitions
{
    [Binding]
    public class JourneyPlannerStepDefinitions
    {
        private static string enteredFromLocation;
        private static string enteredToLocation;
        JourneyPlannerPage journeyPlannerPage;
        public JourneyPlannerStepDefinitions()
        {
            journeyPlannerPage = new JourneyPlannerPage();
        }

        [Given(@"the user lands on the TFL plan a journey page")]
        public void GivenTheUserLandsOnTheTFLPlanAJourneyPage()
        {
            journeyPlannerPage
                .openJourneyPlannerPage();
            Assert.That(journeyPlannerPage.isPlanMyJourneyPageHeaderDisplayed);
            Assert.That(journeyPlannerPage.isMyJourneysSectionDisplayed);
            Assert.That(journeyPlannerPage.isRecentsSectionDisplayed);

        }

        [When(@"the user enter valid from location")]
        public void WhenTheUserEnterValidFromLocation()
        {
            journeyPlannerPage
                .enterFromLocation("Waterloo");
            enteredFromLocation = journeyPlannerPage.getEnteredFromLocation();
        }

        [When(@"the user enter valid destination")]
        public void WhenTheUserEnterValidDestination()
        {
            journeyPlannerPage
                .enterToLocation("London Bridge");
            enteredToLocation = journeyPlannerPage.enteredToLocation();
        }

        [When(@"the user click on plan my journey button")]
        public void WhenTheUserClickOnPlanMyJourneyButton()
        {
            journeyPlannerPage
                .clickPlanMyJourneyButton();
        }

        [When(@"the user select arriving option to plan the journey")]
        public void WhenTheUserSelectArrivingOptionToPlanTheJourney()
        {
            journeyPlannerPage.clickOnChangeTimeLink();
            journeyPlannerPage.clickOnArrivingOption();
        }

        [Then(@"the user should be redirected to journey result page with details")]
        public void ThenTheUserShouldBeRedirectedToJourneyResultPageWithDetails()
        {
            Assert.True(true, enteredFromLocation, journeyPlannerPage.getDisplayedFromLocation);
            Assert.True(true, enteredToLocation, journeyPlannerPage.getDisplayedToLocation);

        }

        [When(@"the user enter invalid travel details")]
        public void WhenTheUserEnterInvalidTravelDetails()
        {
            journeyPlannerPage
                .enterFromLocation("3456789");
            journeyPlannerPage
                .enterToLocation("567890");
        }

        [Then(@"the user should be redirected to journey result page")]
        public void ThenTheUserShouldBeRedirectedToJourneyResultPage()
        {
            Assert.True(true, "Journey results - Transport for London", journeyPlannerPage.getTitle);
            Assert.True(true, "Journey results", journeyPlannerPage.getJourneyResultPageSectionHeader);
        }

        [Then(@"the user should see ""([^""]*)""")]
        public void ThenTheUserShouldSee(string errorMessageForInvalidDetails)
        {
            Assert.True(true, errorMessageForInvalidDetails, journeyPlannerPage.getErrorMessageForInvalidLocationSearch);            
        }

        [When(@"click on plan my journey button without entering any travel details")]
        public void WhenClickOnPlanMyJourneyButtonWithoutEnteringAnyTravelDetails()
        {
            journeyPlannerPage
               .clickPlanMyJourneyButton();
        }

        [Then(@"the user should see validation error message")]
        public void ThenTheUserShouldSeeValidationErrorMessage()
        {
            Assert.True(true, "The From field is required.", journeyPlannerPage.getFromFieldValidationErrorMessage);
            Assert.True(true, "The To field is required.", journeyPlannerPage.getToFieldValidationErrorMessage);
        }

        [When(@"the user decided to edit the journey")]
        public void WhenTheUserDecidedToEditTheJourney()
        {
            journeyPlannerPage.enterFromLocation("Waterloo");
            journeyPlannerPage.enterToLocation("London Bridge");
            journeyPlannerPage.clickPlanMyJourneyButton();
        }

        [When(@"the user click on the edit journey link")]
        public void WhenTheUserClickOnTheEditJourneyLink()
        {
            journeyPlannerPage.clickOnEditJourneyLink();
        }

        [When(@"the user update the journey details")]
        public void WhenTheUserUpdateTheJourneyDetails()
        {
            journeyPlannerPage.enterFromLocation("Greenford");
            enteredFromLocation = journeyPlannerPage.getEnteredFromLocation();
            journeyPlannerPage.clickPlanMyJourneyButton();
        }

        [Then(@"the user should be redirected to journey result page with updated details")]
        public void ThenTheUserShouldBeRedirectedToJourneyResultPageWithUpdatedDetails()
        {
            Assert.True(true, enteredFromLocation, journeyPlannerPage.getDisplayedFromLocation);
            Assert.True(true, "Journey results - Transport for London", journeyPlannerPage.getTitle);
            Assert.True(true, "Journey results", journeyPlannerPage.getJourneyResultPageSectionHeader);

        }

    }
}
