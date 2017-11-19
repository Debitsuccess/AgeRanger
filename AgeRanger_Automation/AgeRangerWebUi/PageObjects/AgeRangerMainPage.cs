using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Threading;

namespace AgeRangerWebUi.PageObjects
{
    public class AgeRangerMainPage 

    {
        public AgeRangerMainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='searchText']")]
        public IWebElement SearchTextField { get; set; }

        [FindsBy(How = How.XPath, Using = "//table")]
        public IWebElement PeopleTable { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[@class='col-md-7 ng-binding']")]
        public IList<IWebElement> ExistingUserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[@class='col-md-2 ng-binding']")]
        public IList<IWebElement> ExistingUserAge { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@ng-click='openEditForm(person)']")]
        public IWebElement EditPerson { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@ng-click='delete(person)']")]
        public IWebElement DeletePerson { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@ng-click='openNewPersonForm()']")]
        public IWebElement AddPerson { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='FirstName']")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@class='help-block']")]
        public IWebElement FirstNameInlineError { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='LastName']")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='Age']")]
        public IWebElement Age { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@ng-click='submit()']")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@ng-click='close()']")]
        public IWebElement CloseButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@data-bb-handler='confirm']")]
        public IWebElement OkButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@data-bb-handler='cancel']")]
        public IWebElement CancelButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='bootbox-close-button close']")]
        public IWebElement CrossButton { get; set; }
    }
}
