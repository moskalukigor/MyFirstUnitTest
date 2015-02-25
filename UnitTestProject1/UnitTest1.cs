using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            var driver = new FirefoxDriver();
            Driver(driver);

        }

        [TestMethod]
        public void TestMethod2()
        {
            var driver = new ChromeDriver(@"\\SERVER\logo\chromedriver_win32");
            Driver(driver);
        }

        public void Driver(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://accounts.google.com/");
            var userNameField = driver.FindElement(By.Id("Email"));
            var userPasswordField = driver.FindElement(By.Id("Passwd"));
            var loginButton = driver.FindElement(By.Id("signIn"));
            userNameField.SendKeys(Settings1.Default.login);
            userPasswordField.SendKeys(Settings1.Default.password);
            loginButton.Click();


            driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/#inbox");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            var createMessageButton = driver.FindElement(By.CssSelector(".T-I.J-J5-Ji.T-I-KE.L3"));////div[2]/div/div/div/div[2]/div/div/div/div/div"));
            createMessageButton.Click();
            var userMessageMail = driver.FindElement(By.Name("to"));
            userMessageMail.SendKeys("moskalukigor@gmail.com");
            var userMessageTheme = driver.FindElement(By.Name("subjectbox"));
            userMessageTheme.SendKeys("myawmyaw");
            var userMessageText = driver.FindElement(By.CssSelector(".Am.Al.editable.LW-avf"));
            userMessageText.SendKeys("bebebe");
            var loginSend = driver.FindElement(By.XPath("//td/div/div/div[4]/table/tbody/tr/td/div/div[2]"));
            loginSend.Click();
        }

    }
}
