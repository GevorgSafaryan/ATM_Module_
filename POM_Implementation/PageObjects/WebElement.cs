using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using POM_Implementation.Utils;
using POM_Implementation.WebDriver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_Implementation.PageObjects
{
    public class WebElement
    {
        private IWebDriver driver;
        private By locator;
        private WebDriverWait wait;

        public WebElement(By locator)
        {
            this.locator = locator;
            driver = Browser.GetDriver();
            wait = Wait.GetWait();
        }

        public IWebElement GetElement()
        {
            return driver.FindElement(locator);
        }

        public ReadOnlyCollection<IWebElement> GetElements()
        {
            return driver.FindElements(locator);
        }

        public By GetLocator()
        {
            return locator;
        }

        public int GetCount()
        {
            return wait.Until(WaitConditions.VisibilityOfAllElementsLocatedBy(locator)).Count;
        }

        public void Click()
        {
            wait.Until(WaitConditions.ElementToBoClickable(locator)).Click();
        }

        public void SendKeys(string input)
        {
            wait.Until(WaitConditions.ElementDisplayed(locator)).SendKeys(input);
        }

        public string GetText()
        {
            return wait.Until(WaitConditions.ElementDisplayed(locator)).Text;
        }

        public string GetAttribute(string attribute)
        {
            return wait.Until(WaitConditions.ElementDisplayed(locator)).GetAttribute(attribute);
        }

        public bool Displayed()
        {
            return driver.FindElement(locator).Displayed;
        }

        //public void ElementIsVisible()
        //{
        //    var element = wait.Until(condition =>
        //    {
        //        try
        //        {
        //            var elementToBeDisplayed = driver.FindElement(locator);
        //            return elementToBeDisplayed.Displayed;
        //        }
        //        catch (NoSuchElementException)
        //        {
        //            return false;
        //        }
        //        catch (StaleElementReferenceException)
        //        {
        //            return false;
        //        }
        //    });
        //}
    }
}
