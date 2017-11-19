using AgeRangerWebUi.Driver;
using AgeRangerWebUi.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AgeRangerWebUi.Steps
{
    [Binding]
    public sealed class PersonSteps
    {

        private AgeRangerMainPage mainPage;
        public PersonSteps()
        {
            var driverFactory = new Driver.Driver();
            Driver = driverFactory.GetRemoteDriver();
            mainPage = new AgeRangerMainPage(Driver);
        }

        public static IWebDriver Driver { get; set; }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
            Driver = null;
        }

        [StepDefinition(@"I navigate to (.*)")]
        public void GivenINavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);
        }

        [StepDefinition(@"I click on the AddPerson button")]
        public void WhenIClickOnTheAddPersonButton()
        {
            var pageObject = new AgeRangerMainPage(Driver);
            pageObject.AddPerson.Click();
            Thread.Sleep(1000);
        }

        [StepDefinition(@"I add a new person with (.*) as a FirstName, (.*) as a LastName and (.*) as Age")]
        public void GivenIAddANewPersonWithAsAFirstNameAsALastNameAndAsAge(string firstName, string lastName, int age)
        {
            var pageObject = new AgeRangerMainPage(Driver);
            pageObject.FirstName.SendKeys(firstName);
            pageObject.LastName.SendKeys(lastName);
            pageObject.Age.SendKeys(age.ToString());
            pageObject.SubmitButton.Click();
            Thread.Sleep(1000);
            pageObject.OkButton.Click();
            Thread.Sleep(1000);
        }

        [StepDefinition(@"I can see a new person the Landing page with (.*),(.*),(.*) and (.*)")]
        public void ThenICanSeeANewPersonTheLandingPageWithMyNameMyLastNameAndVeryAdult(string firstName, string lastName, int age, string ageRange)
        {
            var pageObject = new AgeRangerMainPage(Driver);
            string firstLastName = (firstName + ' ' + lastName);
            string userFound = "false";
            IList<IWebElement> tableRow = pageObject.PeopleTable.FindElements(By.TagName("tr"));
            foreach (IWebElement row in tableRow)
            {
                if (row.Text.Contains(firstLastName) && row.Text.Contains(age.ToString()) && row.Text.Contains(ageRange))
                {
                    userFound = "true";
                    break;
                }
            }
            Assert.AreEqual("true", userFound, "User was not Found.");
        }

        [StepDefinition(@"I type (.*) in the First Name field")]
        public void WhenITypeInTheFirstNameField(string firstName)
        {
            var pageObject = new AgeRangerMainPage(Driver);
            pageObject.FirstName.SendKeys(firstName);
        }

        [StepDefinition(@"I clear the First Name field")]
        public void WhenIClearTheFirstNameField()
        {
            var pageObject = new AgeRangerMainPage(Driver);
            pageObject.FirstName.Clear();
        }

        [StepDefinition(@"I can see an inline error with message (.*).")]
        public void ThenICanSeeAnInlineErrorWithMessageFirstNameIsRequired_(string FirstNameInlineError)
        {
            var pageObject = new AgeRangerMainPage(Driver);
            string errorMessage = pageObject.FirstNameInlineError.Text;
            Assert.AreEqual(FirstNameInlineError, errorMessage, "Inline Error is not displayed or not matching.");
        }

        [StepDefinition(@"I delete the first Person in the list")]
        public void WhenIDeleteTheFirstPersonInTheList()
        {
            var pageObject = new AgeRangerMainPage(Driver);
            int countBeforeDelete = pageObject.ExistingUserName.Count;
            ScenarioContext.Current.Add("countBeforeDelete", countBeforeDelete);
            pageObject.DeletePerson.Click();
            Thread.Sleep(1000);
        }

        [StepDefinition(@"I click on Confirm")]
        public void WhenIClickOnConfirm()
        {
            var pageObject = new AgeRangerMainPage(Driver);
            pageObject.OkButton.Click();
            Thread.Sleep(1000);
        }

        [StepDefinition(@"the count of people should decrease by one")]
        public void ThenTheCountOfPeopleShouldDecreaseByOne()
        {
            var pageObject = new AgeRangerMainPage(Driver);
            int countAfterDelete = pageObject.ExistingUserName.Count;
            int countBeforeDelete = ScenarioContext.Current.Get<int>("countBeforeDelete");
            if (countAfterDelete != null)
            {
                Assert.AreEqual(countAfterDelete, (countBeforeDelete - 1));
            }
            else
                Console.WriteLine("No Results left to Delete.");
         
        }

        [StepDefinition(@"I edit the first Person in the list")]
        public void GivenIEditTheFirstPersonInTheList()
        {
            var pageObject = new AgeRangerMainPage(Driver);
            int ageBeforeEdit = Int32.Parse(pageObject.ExistingUserAge.First().Text);
            ScenarioContext.Current.Add("ageBeforeEdit", ageBeforeEdit);
            pageObject.EditPerson.Click();
            Thread.Sleep(1000);
        }

        [StepDefinition(@"I change the Age for that Person to a higher value")]
        public void WhenIChangeTheAgeForThatPersonTo()
        {
            var pageObject = new AgeRangerMainPage(Driver);
            int newAge = ScenarioContext.Current.Get<int>("ageBeforeEdit");
            newAge = ++newAge;
            pageObject.Age.Clear();
            pageObject.Age.SendKeys(newAge.ToString());
            pageObject.SubmitButton.Click();
            Thread.Sleep(1000);
        }

        [StepDefinition(@"the age of the first person will have changed")]
        public void ThenTheAgeOfTheFirstPersonWillHaveChanged()
        {
            var pageObject = new AgeRangerMainPage(Driver);
            int ageAfterEdit = Int32.Parse(pageObject.ExistingUserAge.First().Text);
            int ageBeforeEdit = ScenarioContext.Current.Get<int>("ageBeforeEdit");
            Assert.AreNotEqual(ageBeforeEdit, ageAfterEdit, "Age is still the same.");
        }

    }
}