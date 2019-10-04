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
    public class TemaTest
    {
        [Test]
        public void TemaIndexIsOk()
        {
            var chrome = new ChromeDriver();
            chrome.Url = Global.URL;
            chrome.FindElementById("temaLink").Click();
            var title = chrome.FindElementByTagName("h2");
            
            Assert.AreEqual("Temas", title.Text);
            chrome.Close();
        }

        [Test]
        public void TemaCrearValidacionIsOK()
        {
            var chrome = new ChromeDriver();
            chrome.Url = Global.URL;
            chrome.FindElementById("temaLink").Click();
            chrome.FindElementById("creartemaLink").Click();
            chrome.FindElementById("btnguardartema").Click();
            var validation = chrome.FindElementByClassName("field-validation-error");

            Assert.NotNull(validation.Text);
            chrome.Close();
        }
        [Test]
        public void TemaCrearIsOk()
        {
            var chrome = new ChromeDriver();
            chrome.Url = Global.URL;
            chrome.FindElementById("temaLink").Click();
            chrome.FindElementById("creartemaLink").Click();
            chrome.FindElementById("Nombre").SendKeys("Nombre1");
            chrome.FindElementById("Descripcion").SendKeys("aaaaaaaaaaa");
            chrome.FindElementById("btnguardartema").Click();

            Assert.IsTrue(chrome.Url.EndsWith("/Tema"));
            chrome.Close();
        }


    }
}
