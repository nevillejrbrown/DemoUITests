using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoUITEsts
{
    public class TheTopicApp
    {

        private const String BASE_URL = "https://localhost:44395";

        [SetUp]
        public void Setup()
        {
        }

        private void Pause(int millis=3000)
        {
            Thread.Sleep(millis);
        }

        [Test]
        public void ShouldShowAListOfTopics()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(BASE_URL + "/Topics/List");
                IWebElement element = driver.FindElement(By.Id("pageHeader"));
                Assert.AreEqual(element.Text, "Index");
            }
        }

        [Test]
        public void ShouldAllowAddingOfTopic()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(BASE_URL + "/Topics/List");
                Pause();
                
                driver.FindElement(By.LinkText("Create New")).Click();
                Pause();

                driver.FindElement(By.Id("Name")).SendKeys("Git");
                Pause();

                driver.FindElement(By.Id("CreateBtn")).Click();
                Pause();

                // hack
                driver.FindElement(By.Id("name4"));

            }
        }
    }
}
