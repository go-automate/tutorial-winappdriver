using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace WinAppDriver.AcceptanceTests
{
    [TestClass]
    public class AlarmClockTest
    {
        [TestMethod]
        public void AddAlarm()
        {
            // Launch the Alarms & Clock app
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            // Set Application Id
            appCapabilities.SetCapability("app", "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");
            WindowsDriver<WindowsElement> AlarmClockSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);

            // Use the session to control the app
            AlarmClockSession.FindElementByAccessibilityId("AddAlarmButton").Click();
            AlarmClockSession.FindElementByAccessibilityId("AlarmNameTextBox").Clear();
            AlarmClockSession.FindElementByAccessibilityId("AlarmNameTextBox").SendKeys("Dentist");
        }
    }
}
