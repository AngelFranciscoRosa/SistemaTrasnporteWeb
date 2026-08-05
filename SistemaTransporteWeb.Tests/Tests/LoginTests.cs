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
}