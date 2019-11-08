using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using MeuPrimeiroTeste.Util;

namespace MeuPrimeiroTeste.PageObject
{
    /// <summary>
    /// Mapeamento do processo de Boletos Emitidos.
    /// </summary>
    public class BoletoEmitidos : Base
    {
        #region Mapeamento da pagina #endregion
        private IWebElement BtnBoleto => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Dashboard'])[1]/following::span[1]"));

        private IWebElement BtnEmitidos => Driver.FindElement(By.LinkText("Emitidos"));

        private IWebElement SelecionaData => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[1]/following::span[6]"));

        private IWebElement VoltaMes => Driver.FindElement(By.CssSelector("svg.vc-svg-icon"));

        private IWebElement SelecionaDia19 => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[1]/following::span[25]"));

        private IWebElement Seleciona50RegistrosPorPagina => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Registros por Página:'])[1]/following::select[1]"));

        private IWebElement LimpaDoc => Driver.FindElement(By.Name("Documento"));

        private IWebElement LimpaRazao => Driver.FindElement(By.Name("NomeRazao"));

        private IWebElement TodosSplits => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Split:'])[1]/following::select[1]"));

        private IWebElement Filtrar => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Filtrar'])[1]/i[1]"));
        #endregion

        #region Metodos de Testes 
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
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }
        #endregion
    }
}