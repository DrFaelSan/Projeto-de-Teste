using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using NUnit.Framework;
using MeuPrimeiroTeste.Util;
using System;

namespace MeuPrimeiroTeste.PageObject
{
    /// <summary>
    /// Processo de vizualização de Boletos em lote.
    /// </summary>
    public class BoletoLote : Base
    {
        #region Mapeamento da pagina #endregion
        private IWebElement BtnBoleto => Driver.FindElement(By.LinkText("Boleto"));
        private IWebElement BtnLote => Driver.FindElement(By.LinkText("Lote"));
        private IWebElement Dia18Novembro => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[1]/following::span[18]"));
        private IWebElement BtnVoltarMes => Driver.FindElement(By.CssSelector("svg.vc-svg-icon"));
        private IWebElement Dia19Setembro => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[1]/following::span[25]"));
        private IWebElement Selecionar100Registros => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Registros por Página:'])[1]/following::select[1]"));
        private IWebElement BtnFiltrar => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Limpar'])[1]/following::button[1]"));
        #endregion

        #region Metodos de Testes 
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
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }

        #endregion
    }
}
