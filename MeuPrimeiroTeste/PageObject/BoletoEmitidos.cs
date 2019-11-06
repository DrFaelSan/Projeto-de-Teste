using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace MeuPrimeiroTeste.PageObject
{
    /// <summary>
    /// Mapeamento do processo de Boletos Emitidos.
    /// </summary>
    public class BoletoEmitidos
    {
        public IWebDriver _driver;

        public BoletoEmitidos(IWebDriver driver) => _driver = driver;

        private IWebElement BtnBoleto => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Dashboard'])[1]/following::span[1]"));

        private IWebElement BtnEmitidos => _driver.FindElement(By.LinkText("Emitidos"));

        private IWebElement SelecionaData => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[1]/following::span[6]"));

        private IWebElement VoltaMes => _driver.FindElement(By.CssSelector("svg.vc-svg-icon > path"));

        private IWebElement SelecionaDia19 => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[1]/following::span[25]"));

        private IWebElement Seleciona50RegistrosPorPagina => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Registros por Página:'])[1]/following::select[1]"));

        private IWebElement LimpaDoc => _driver.FindElement(By.Name("Documento"));

        private IWebElement LimpaRazao => _driver.FindElement(By.Name("NomeRazao"));

        private IWebElement TodosSplits => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Split:'])[1]/following::select[1]"));

        private IWebElement Filtrar => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Filtrar'])[1]/i[1]"));
     
        public void ProcessoDeFiltragemEmitidos()
        {
            BtnBoleto.Click(); 
            Thread.Sleep(1300);
            BtnEmitidos.Click(); 
            Thread.Sleep(1300);
            SelecionaData.Click(); 
            Thread.Sleep(350);
            VoltaMes.Click();
            Thread.Sleep(350);
            VoltaMes.Click(); 
            Thread.Sleep(350);
            SelecionaDia19.Click();
            Thread.Sleep(350);
            new SelectElement(Seleciona50RegistrosPorPagina).SelectByText("50");
            Thread.Sleep(350);
            LimpaDoc.Clear();
            LimpaRazao.Clear();
            TodosSplits.Click();
            Thread.Sleep(350);
            Filtrar.Click();
            Thread.Sleep(350);
        }
    }
}