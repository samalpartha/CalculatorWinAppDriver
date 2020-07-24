using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace CalculatorAutomationWinappDriver
{
    [TestClass]
    public class UnitTest
    {
        //Appium Driver URL it works like a windows Service on your PC  
        private const string appiumDriverURI = "http://127.0.0.1:4723";
        //Application Key of your UWA   
        //U can use any .Exe file as well for open a windows Application  
        private const string calApp = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";

        protected static WindowsDriver<WindowsElement> calSession;

        public object By { get; private set; }

        [TestMethod]
        public void TestMethod1()
        {
            if (calSession == null)
            {
                DesiredCapabilities appCapabilities = new DesiredCapabilities();
                appCapabilities.SetCapability("app", calApp);
                appCapabilities.SetCapability("deviceName", "WindowsPC");
                //Create a session to intract with Calculator windows application  
                calSession = new WindowsDriver<WindowsElement>(new Uri(appiumDriverURI), appCapabilities);

                //Automate Button and Get answer from Calculator  

                //find by Name  
                calSession.FindElement(By.Name("Nine")).Click();
                calSession.FindElement(By.Name("One")).Click();
                calSession.FindElement(By.Name("Two")).Click();
                calSession.FindElement(By.Name("Three")).Click();
                calSession.FindElement(By.Name("Multiply by")).Click();
                //find by automation id  
                calSession.FindElementByAccessibilityId("num9Button").Click();
                calSession.FindElementByAccessibilityId("equalButton").Click();
                //getting value from textbox  
                string ExpectedValue = calSession.FindElementByAccessibilityId("CalculatorResults").Text;
                string ExpectedValue1 = ExpectedValue.Replace("Display is ", "").Replace(",", "");

                //Testcases  
                Assert.AreEqual(82107, Convert.ToInt64(ExpectedValue1));
            }
        }
    }
}
