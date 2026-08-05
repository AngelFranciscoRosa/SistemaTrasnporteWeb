using OpenQA.Selenium;
using SistemaTransporteWeb.Tests.Base;
using Xunit;

namespace SistemaTransporteWeb.Tests.Tests;

public class ChoferTests : TestBase
{
    [Fact]
    public void CrearChofer()
    {
        Login();

        Driver.Navigate().GoToUrl($"{BaseUrl}/Choferes/Create");

        Driver.FindElement(By.Id("Nombre"))
              .SendKeys("Juan");

        Driver.FindElement(By.Id("Apellido"))
              .SendKeys("Perez");

        Driver.FindElement(By.Id("Cedula"))
              .SendKeys("00112345678");

        Driver.FindElement(By.Id("Licencia"))
              .SendKeys("A123456");

        Driver.FindElement(By.Id("FechaNacimiento"))
              .SendKeys("01/01/1995");

        Driver.FindElement(By.CssSelector("input[type='submit']"))
              .Click();

        Assert.Contains("Juan", Driver.PageSource);
    }

    [Fact]
    public void EditarChofer()
    {
        Login();

        Driver.Navigate().GoToUrl($"{BaseUrl}/Choferes");

        Driver.FindElement(By.LinkText("Edit"))
              .Click();

        var nombre = Driver.FindElement(By.Id("Nombre"));

        nombre.Clear();

        nombre.SendKeys("Carlos");

        Driver.FindElement(By.CssSelector("input[type='submit']"))
              .Click();

        Assert.Contains("Carlos", Driver.PageSource);
    }

    [Fact]
    public void EliminarChofer()
    {
        Login();

        Driver.Navigate().GoToUrl($"{BaseUrl}/Choferes");

        Driver.FindElement(By.LinkText("Delete"))
              .Click();

        Driver.FindElement(By.CssSelector("input[type='submit']"))
              .Click();

        Assert.DoesNotContain("Carlos", Driver.PageSource);
    }

    [Fact]
    public void CrearChoferConCamposVacios()
    {
        Login();

        Driver.Navigate().GoToUrl($"{BaseUrl}/Choferes/Create");

        Driver.FindElement(By.CssSelector("input[type='submit']"))
              .Click();

        Assert.Contains("required", Driver.PageSource, StringComparison.OrdinalIgnoreCase);
    }


}