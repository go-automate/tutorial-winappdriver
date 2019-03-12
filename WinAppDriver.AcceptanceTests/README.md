# Getting Started

## Install the WinAppDriver Executable

1. Download Windows Application Driver installer from https://github.com/Microsoft/WinAppDriver/releases
2. Run the installer on a Windows 10 machine where your application under test is installed and will be tested
3. From the `Start` menu search for `Developer Settings`
4. In the `For developers` screen, switch on `Developer Mode` (say `Yes` to the `are you sure` popup and wait for it to install everything it needs to).
5. Run WinAppDriver.exe from the installation directory (E.g. `C:\Program Files (x86)\Windows Application Driver`)
6. Windows Application Driver will then be running on the test machine listening to requests on the default IP address and port (`127.0.0.1:4723`). 

## Download the Windows SDK

1. Open Microsoft Visual Studio 
2. Go to `Tools > Get Tools and Features`. This will open the Visual Studio Installer.
3. Click on `Individual Components` from the top tabs
4. Scroll down until you see `Windows 10 SDK` and choose the last one in the list (the latest version)
5. Click on the `checkbox` next to it and click the `Modify` button to install it. You might need to close Visual Studio while this is installing.

## Create a Test Project

1. Open Microsoft Visual Studio 
2. Go to `Tools > Get Tools and Features`. This will open the Visual Studio Installer.
3. Ensure you have `.NET desktop development` installed.
4. Back in Visual Studion, create the test project and solution. I.e. Select `New Project > Templates > Visual C# > Test > Unit Test Project`
5. Once created, select `Project > Manage NuGet Packages... > Browse` and search for `Appium.WebDriver`.
6. Install the `Appium.WebDriver` NuGet packages for the test project

## Inspecting UI Elements
The latest Windows SDK includes a great tool to inspect the application you are testing. This tool allows you to see every UI element/node that you can query using Windows Application Driver. This `inspect.exe` tool can be found under the Windows SDK folder which is typically `C:\Program Files (x86)\Windows Kits\10\bin\<SDK Version>\x86`. Replace <SDK Version> in this path with the version of the Windows SDK you downloaded.

More detailed documentation on Inspect is available on MSDN https://msdn.microsoft.com/library/windows/desktop/dd318521(v=vs.85).aspx.

## Supported Locators to Find UI Elements
Windows Application Driver supports various locators to find UI element in the application session. The table below shows all supported locator strategies with their corresponding UI element attributes shown in inspect.exe.

|Client API						|	Locator Strategy	|	Matched Attribute in inspect.exe		|	Example		|
|-------------------------------|-----------------------|-------------------------------------------|---------------|
|FindElementByAccessibilityId	|	accessibility id	|	AutomationId							| AppNameTitle	|
|FindElementByClassName			|	class name			|	ClassName								| TextBlock		|
|FindElementById				|	id					|	RuntimeId (decimal)						| 42.333896.3.1	|
|FindElementByName				|	name				|	Name									| Calculator	|
|FindElementByTagName			|	tag name			|	LocalizedControlType (upper camel case)	| Text			|
|FindElementByXPath				|	xpath				|	Any										| //Button[0]	|

## Write your Test - A Universal Windows Platform Application

1. Create a new Unit Test called `TestAlarmClock` and add the following code to your Test Method (call it `AddAlarmTest`):

NOTE: Use `ctrl + .` to import the relevent libraries.

```c#
			// Launch the Alarms & Clock app
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
			// Set Application Id
            appCapabilities.SetCapability("app", "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");
            WindowsDriver<WindowsElement> AlarmClockSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities);

            // Use the session to control the app
            AlarmClockSession.FindElementByAccessibilityId("AddAlarmButton").Click();
            AlarmClockSession.FindElementByAccessibilityId("AlarmNameTextBox").Clear();
			AlarmClockSession.FindElementByAccessibilityId("AlarmNameTextBox").SendKeys("Dentist");
```

You can find the Application Id of your application in the generated AppX\vs.appxrecipe file under RegisteredUserModeAppID node. E.g. c24c8163-548e-4b84-a466-530178fc0580_scyf5npe3hv32!App or simply ask your developers for it.

## Write your Test - A Classic Windows Platform Application

1. Create a folder called `MyTestFolder` on the C drive (i.e. `C:\MyTestFolder`)
2. Add a text file in this folder called `MyTestFile.txt`
3. Create a new Unit Test called `TestNotePad` and add the following code to your Test Method (call it `AddTextToFileTest`):

NOTE: Use `ctrl + .` to import the relevent libraries.

```c#
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
```
You'll note that instead of an Application Id we need to specify the full executable path of the application. We also need to specify the working directory of the test.

## Sample Projects

Below is a link to some detailed and well documented (read the README.md for each project) best practice projects:

https://github.com/Microsoft/WinAppDriver/tree/master/Samples/C%23


## Actions

More information can be found in the official repository:

https://github.com/Microsoft/WinAppDriver

See the `Supported APIs` section for the list of actions you can perform on an element.

