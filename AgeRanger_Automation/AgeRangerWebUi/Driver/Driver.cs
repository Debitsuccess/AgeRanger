using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRangerWebUi.Driver
{
    public class Driver
    {
        public IWebDriver GetRemoteDriver()
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("browserName", "Chrome");
            capabilities.SetCapability("platform", "Windows 10");
            capabilities.SetCapability("version", "62.0");
            return new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capabilities,
                TimeSpan.FromSeconds(60));
        }
    }
}
