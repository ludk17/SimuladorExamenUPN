using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorExamenUPN.Tests.Selenium
{
    [TestFixture]
    public class HomeTest
    {
        [Test]
        public void HomeIsOK() {
            var chrome = new ChromeDriver();
            chrome.Url = "http://localhost:58972/";

            var element = chrome.FindElementByClassName("jumbotron");

            Assert.NotNull(element);

            chrome.Close();
        }
    }
}
