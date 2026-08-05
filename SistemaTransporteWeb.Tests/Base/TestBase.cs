using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using System.Threading;

namespace SistemaTransporteWeb.Tests.Base;

public class TestBase : IDisposable
{
    protected readonly IWebDriver Driver;

    protected const string BaseUrl = "https://localhost:7281";

    public TestBase()
    {
        var options = new ChromeOptions();

        options.AddArgument("--start-maximized");

        Driver = new ChromeDriver(options);
    }

    public void Dispose()
    {
        Driver.Quit();
        Driver.Dispose();
    }



protected void Login()
{
    Driver.Navigate().GoToUrl($"{BaseUrl}/Identity/Account/Login");

    Thread.Sleep(1000);

    Driver.FindElement(By.Id("Input_Email"))
          .SendKeys("angelfrosad@gmail.com");

    Driver.FindElement(By.Id("Input_Password"))
          .SendKeys("Angel_001");

    Driver.FindElement(By.Id("login-submit"))
          .Click();

    Thread.Sleep(2000);
}

}