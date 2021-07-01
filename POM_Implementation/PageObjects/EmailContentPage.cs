using OpenQA.Selenium;
using POM_Implementation.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_Implementation.PageObjects
{
    public class EmailContentPage : BasePage
    {
        private static readonly WebElement mainFrame = new WebElement(By.XPath("//div[@class = 'application-mail__layout application-mail__layout_main']//div[@class = 'layout__main-frame']"));
        private static int emailsCount;
        private readonly WebElement emailsList = new WebElement(By.XPath("//div[@class = 'llct__content']"));
        private readonly WebElement sentEmailsSubject = new WebElement(By.XPath("//h2[@class = 'thread__subject']"));
        private readonly WebElement sentEmailsRecipient = new WebElement(By.XPath("(//span[@class = 'letter-contact'])[2]"));
        private readonly WebElement sentEmailsBody = new WebElement(By.XPath("//div[@data-signature-widget= 'container']/../div[1]"));

        public EmailContentPage() : base(mainFrame)
        {

        }

        public void OpenEnEmailFromTheListById(int emailID)
        {
            emailsCount = emailsList.GetElements().Count;
            emailsList.GetElements()[emailID].Click();
        }

        public bool VerifyThatEmailDisappearsFromDraftsFolderAfterSending()
        {
            Browser.Refresh();
            int emailsCountAfterSendingAnEmail = emailsList.GetElements().Count;
            return emailsCountAfterSendingAnEmail == 0 || emailsCountAfterSendingAnEmail == emailsCount - 1;
        }

        public bool VerifySentEmailsContent(string recipient, string subject, string bodyText)
        {
            bool assertRecipient = sentEmailsRecipient.GetAttribute("title").Equals(recipient);
            bool assertSubject = sentEmailsSubject.GetText().Equals(subject);
            bool assertBody = sentEmailsBody.GetText().Contains(bodyText);
            return assertRecipient && assertSubject && assertBody;
        }
    }
}
