using NUnit.Framework;
using POM_Implementation.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM_Implementation.Tests
{
    public class BaseTest
    {
        protected static Browser Instance;
        [SetUp]
        public void Setup()
        {
            Instance = Browser.Instance;
            Browser.Navigate(Configuration.URL);
        }

        [TearDown]
        public void CleanUp()
        {
            Browser.Quit();
        }
    }
}
