using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinAppDriverTest
{
    class Program
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";


        const string NotepadAppId = "notepad.exe";
        private const string CalculatorAppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
        private const string CRMAppId = @"C:\Users\prataps\Desktop\CRM\setup.exe";

        static void Main(string[] args)
        {
            DesiredCapabilities desiredCapabilities = new DesiredCapabilities();
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            desiredCapabilities.SetCapability("app", CRMAppId);
            WindowsDriver<WindowsElement> session, desktopSession;
           
            try { session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), desiredCapabilities); } catch (Exception e) { Console.WriteLine(e.Message); }

            Thread.Sleep(45000); Console.WriteLine("Wait for 45 seconds is over!");

            //Creating a desktop session
            appCapabilities.SetCapability("app", "Root");
            desktopSession = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);

            //Navigating to target app through desktop session
            var mainWindow = desktopSession.FindElementByName("CRM Application - Built with Progress® Telerik® UI for WPF");
            var mainWindowHandle = mainWindow.GetAttribute("NativeWindowHandle");
            mainWindowHandle = (int.Parse(mainWindowHandle)).ToString("x"); // Convert to Hex
            appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("appTopLevelWindow", mainWindowHandle);
            session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);

            //Clicking the grid element
            var cell = session.FindElementByAccessibilityId("CellElement_2_2");
            cell.Click();


            var mainMenus = session.FindElementByClassName("MainMenuView").FindElementsByClassName("RadRadioButton");

            //Clicking on Contact Menu
            var contactMenu = mainMenus[2];
            contactMenu.Click();

            Console.WriteLine("Printing menus count " + mainMenus.Count);
            Console.WriteLine("Printing Grid content " + cell.Text);

            //Clickig on setting Button.
            var settingButton = session.FindElementByXPath("//Button[@ClassName=\"RadToggleButton\"]");
            settingButton.Click();

            Console.WriteLine("Printing menus count " + mainMenus.Count);


        }
    }
}
