using NunitBDDTestAssignmentForTFL.Hooks;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitBDDTestAssignmentForTFL.Pages
{
    public class JourneyPlannerPage
    {
        IWebDriver driver;
        public JourneyPlannerPage()
        {
            driver = Hooks.Hooks.driver;
        }

        public void goToJourneyPlannerPage()
        {
            driver.Navigate().GoToUrl("http://tfl.gov.uk");
        }

        IWebElement _fromLocationTextBox => driver.FindElement(By.Id("InputFrom"));
        IWebElement _toLocationTextBox => driver.FindElement(By.Id("InputTo"));
        IWebElement _planMyJourneyButton => driver.FindElement(By.Id("plan-journey-button"));
        IWebElement _planJourneySectionHeader => driver.FindElement(By.XPath("//div[contains(text(), 'Plan a journey')]"));
        IWebElement _myJourneysSection => driver.FindElement(By.Id("jp-fav-tab-home"));
        IWebElement _recentsJourneySection => driver.FindElement(By.Id("jp-recent-tab-home"));
        IWebElement journeyResultPageSectionHeader => driver.FindElement(By.XPath("//span[@class='jp-results-headline']"));
        IWebElement _validationErrorForFromLocationTextBox => driver.FindElement(By.Id("InputFrom-error"));
        IWebElement _validationErrorForToLocationTextBox => driver.FindElement(By.Id("InputTo-error"));
        IWebElement _errorMessageForInvalidTravelDetailsSearch => driver.FindElement(By.XPath("//li[@class='field-validation-error']"));
        IWebElement _changeTimeLink => driver.FindElement(By.XPath("//div[@class='change-time-options']"));
        IWebElement _arrivingOption => driver.FindElement(By.Id("arriving"));
        IWebElement _enteredFromLocation => driver.FindElement(By.XPath("(//span[contains(text(), 'From')]/following::strong)[1]"));
        IWebElement _enteredToLocation => driver.FindElement(By.XPath("(//span[contains(text(), 'To')]/following::strong)[2]"));
        IWebElement _EditJourneyLink => driver.FindElement(By.XPath("//a[@class='edit-journey']"));

        public string getTitle()
        {
           return driver.Title;
        }

        public void openJourneyPlannerPage()
        {            
            goToJourneyPlannerPage();
        }

        public void clickPlanMyJourneyButton()
        {
            _planMyJourneyButton.Click();
        }

        public string getFromFieldValidationErrorMessage()
        {
            return _validationErrorForFromLocationTextBox.Text;
        }

        public string getToFieldValidationErrorMessage()
        {
            return _validationErrorForToLocationTextBox.Text;
        }

        public void enterFromLocation(string fromLocation)
        {
            _fromLocationTextBox.SendKeys(fromLocation);
            _fromLocationTextBox.SendKeys(Keys.Enter);
        }

        public string getEnteredFromLocation()
        {
            return _fromLocationTextBox.GetAttribute("value");
        }

        public string getDisplayedFromLocation()
        {
            return _enteredFromLocation.Text;
        }
        public void enterToLocation(string toLocation)
        {
            _toLocationTextBox.SendKeys(toLocation);
            _toLocationTextBox.SendKeys(Keys.Enter);
        }

        public string enteredToLocation()
        {
            return _toLocationTextBox.GetAttribute("value");
        }

        public string getDisplayedToLocation()
        {
            return _enteredToLocation.Text;
        }

        public string getErrorMessageForInvalidLocationSearch()
        {
            return _errorMessageForInvalidTravelDetailsSearch.Text;
        }

        public void clickOnChangeTimeLink()
        {
            _changeTimeLink.Click();
        }

        public void clickOnArrivingOption()
        {
            _arrivingOption.Click();
        }

        public void clickOnEditJourneyLink()
        {
            _EditJourneyLink.Click();
        }

        public Boolean isPlanMyJourneyPageHeaderDisplayed()
        {
            return _planJourneySectionHeader.Displayed;
        }

        public Boolean isMyJourneysSectionDisplayed()
        {
            return _myJourneysSection.Displayed;
        }

        public Boolean isRecentsSectionDisplayed()
        {
            return _recentsJourneySection.Displayed;
        }

        public string getJourneyResultPageSectionHeader()
        {
            return -journeyResultPageSectionHeader.Text;
        }
    }
}
