using OpenQA.Selenium;
using POM_Implementation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_Implementation.PageObjects
{
    public class LeftMenuPage : BasePage
    {
        private static readonly WebElement composeButton = new WebElement(By.XPath("//span[@class = 'compose-button__wrapper']"));
        private readonly WebElement draftsFolder = new WebElement(By.XPath("//div[text() = 'Черновики']"));
        private readonly WebElement sentFolder = new WebElement(By.XPath("//a[@href = '/sent/']"));
        private readonly WebElement activeFolder = new WebElement(By.XPath("//a[@class = 'nav__item js-shortcut nav__item_active nav__item_shortcut nav__item_expanded_true nav__item_child-level_0']"));

        public LeftMenuPage() : base(composeButton)
        {

        }

        public void ClickOnComposeButton()
        {
            composeButton.Click();
        }

        public void OpenDraftsFolder()
        {
            draftsFolder.Click();
            wait.Until(WaitConditions.ElementDisplayed(activeFolder.GetLocator()));
        }

        public void OpenSentFolder()
        {
            sentFolder.Click();
            wait.Until(WaitConditions.ElementDisplayed(activeFolder.GetLocator()));
        }
    }
}
