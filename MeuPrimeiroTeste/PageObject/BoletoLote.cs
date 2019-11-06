using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using NUnit.Framework;

namespace MeuPrimeiroTeste.PageObject
{
    /// <summary>
    /// Processo de vizualização de Boletos em lote.
    /// </summary>
    public class BoletoLote
    {
        public IWebDriver _driver;
        public BoletoLote(IWebDriver driver) => _driver = driver;

        private IWebElement BtnBoleto => _driver.FindElement(By.LinkText("Boleto"));
        private IWebElement BtnLote => _driver.FindElement(By.LinkText("Lote"));
        private IWebElement Dia18Novembro => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[1]/following::span[18]"));
        private IWebElement BtnVoltarMes => _driver.FindElement(By.CssSelector("svg.vc-svg-icon"));
        private IWebElement Dia19Setembro => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[1]/following::span[25]"));
        private IWebElement Selecionar100Registros => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Registros por Página:'])[1]/following::select[1]"));
        private IWebElement BtnFiltrar => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Limpar'])[1]/following::button[1]"));

        public void VizualizarBoletosEmLote()
        {
            BtnBoleto.Click();
            Thread.Sleep(1300);
            BtnLote.Click();
            Thread.Sleep(1300);
            Dia18Novembro.Click();
            Thread.Sleep(350);
            BtnVoltarMes.Click();
            Thread.Sleep(350);
            BtnVoltarMes.Click();
            Thread.Sleep(350);
            Dia19Setembro.Click();
            Thread.Sleep(350);
            new SelectElement(Selecionar100Registros).SelectByText("100");
            Thread.Sleep(350);
            BtnFiltrar.Click();
            Thread.Sleep(350);
        }
    }
}
