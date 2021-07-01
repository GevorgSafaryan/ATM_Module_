using OpenQA.Selenium.Support.UI;
using POM_Implementation.Utils;
using POM_Implementation.WebDriver;
using System;

namespace POM_Implementation.PageObjects
{
    public class BasePage
    {
        protected string title;
        protected WebElement pageUniqueElement;
        protected WebDriverWait wait = Wait.GetWait();

        public BasePage(string title)
        {
            this.title = title;
            CorrectPageIsOpenedByTitle();
        }

        public BasePage(WebElement pageUniqueElement)
        {
            this.pageUniqueElement = pageUniqueElement;
            CorretcPageIsOpenedByUniqueElement();
        }

        public BasePage() { }

        public void CorrectPageIsOpenedByTitle()
        {
            wait.Until(WaitConditions.TitleIs(title));
        }

        public void CorretcPageIsOpenedByUniqueElement()
        {
            wait.Until(WaitConditions.ElementExists(pageUniqueElement.GetLocator()));
        }
    }
}
