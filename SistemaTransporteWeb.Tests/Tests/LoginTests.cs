using OpenQA.Selenium;
using SistemaTransporteWeb.Tests.Base;
using Xunit;

namespace SistemaTransporteWeb.Tests.Tests;

public class LoginTests : TestBase
{
    [Fact]
    public void LoginCorrecto()
    {
        Login();
        var usuario = Driver.FindElement(By.CssSelector("a[title='Manage']"));

        Assert.Contains("angelfrosad@gmail.com", usuario.Text);
    }

    [Fact]
    public void LoginIncorrecto()
    {
        Driver.Navigate().GoToUrl($"{BaseUrl}/Identity/Account/Login");

        Driver.FindElement(By.Id("Input_Email"))
              .SendKeys("incorrecto@gmail.com");

        Driver.FindElement(By.Id("Input_Password"))
              .SendKeys("123456");

        Driver.FindElement(By.Id("login-submit"))
              .Click();

        Assert.Contains("Invalid login attempt.", Driver.PageSource);
    }
}