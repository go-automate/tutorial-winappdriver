using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace WinAppDriver.AcceptanceTests
{
    [TestClass]
    public class NotepadTest
    {
        [TestMethod]
        public void AddTextToFileTest()
        {
            // Launch Notepad
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            // Notepad executable path
            appCapabilities.SetCapability("app", @"C:\Windows\System32\notepad.exe");
            // File to open
            appCapabilities.SetCapability("appArguments", @"MyTestFile.txt");
            // Path to directory that contains file
            appCapabilities.SetCapability("appWorkingDir", @"C:\MyTestFolder\");
            WindowsDriver<WindowsElement> NotepadSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);

            // Use the session to control the app
            NotepadSession.FindElementByClassName("Edit").SendKeys("This is some text");
        }
    }
}
