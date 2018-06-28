using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using saucelabs.saucerest;
using System.Threading;

namespace SauceTest
{
    class Program
    {
        //IWebDriver driver;
        public static String SAUCE_USERNAME = "SantoshDora";
        public static String SAUCE_ACCESS_KEY = "72d52f85-68f1-4ef7-bda3-038eb24ce50f";
        public static String SAUCE_URL = "https://" + SAUCE_USERNAME + ":" + SAUCE_ACCESS_KEY + "@ondemand.saucelabs.com:443/wd/hub";
        public static String Extension_path = "C:\\BeatBlip\\extension_2_6.crx";
        //  static String SAUCE_PRERUN = "https://github.com/SantoshDora/mycode/blob/master/addExtension.exe?raw=true";
        public static String SAUCE_PRERUN = "C:\\Revionics-Automation\\autoITScripts\\EnableExtensionSuperCopy.exe";

        static DesiredCapabilities capabilities;
       // DesiredCapabilities desiredCapability;

        static RemoteWebDriver browser;
        //SauceREST api;
        //Boolean passed = true;

        static void Main(string[] args)
        {
            
            FileInfo prerunFile = new FileInfo(SAUCE_PRERUN);

            //SauceREST api = new SauceREST(SAUCE_USERNAME, SAUCE_ACCESS_KEY);
            //api..uploadFile(prerunFile);

            Dictionary<String, String> prerunParams = new Dictionary<string, string>();
            prerunParams.Add("executable", "sauce-storage:" + prerunFile.Name);
            prerunParams.Add("background", "false");
            
            ChromeOptions options = new ChromeOptions();
            options.AddExtension(Extension_path);
            capabilities = options.ToCapabilities() as DesiredCapabilities;

            capabilities.SetCapability("name", "From C# new 22");
            //capabilities.SetCapability("build", System.getenv("BUILD_TAG"));
            capabilities.SetCapability("platform", "Windows 10");
            capabilities.SetCapability("version", "latest");
            capabilities.SetCapability("prerun", prerunParams);

            

            browser = new RemoteWebDriver(new Uri(SAUCE_URL), capabilities);
            browser.Url = "http://www.google.co.in";

            Thread.Sleep(2000);
            browser.Url = "http://www.quest.com/";
            browser.Quit();
            //capabilities.SetCapability((ChromeOptions.Capability, options);
            //IWebDriver driver = new ChromeDriver("C:\\BeatBlip\\");
            //driver.Url = "http://www.google.co.in";
        }
    }
}
