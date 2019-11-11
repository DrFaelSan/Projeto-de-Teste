using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using MeuPrimeiroTeste.Logger;
using MeuPrimeiroTeste.Util;
using System;

namespace MeuPrimeiroTeste.PageObject
{
    /// <summary>
    /// Mapeamento do processo de Emitir Boleto.
    /// </summary>
    public class BoletoEmissao : Base
    {

        #region Mapeamento da pagina
        //Botão Boleto ! Inicio do Processo ! 
        private IWebElement BtnBoleto => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Dashboard'])[1]/following::span[1]"));
        private IWebElement BtnEmissao => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Boleto'])[1]/following::span[1]"));
        private IWebElement Documento => Driver.FindElement(By.Name("Documento"));
        private IWebElement NomeRazao => Driver.FindElement(By.Name("NomeRazao"));
        private IWebElement Celular => Driver.FindElement(By.Name("Celular"));
        private IWebElement Email => Driver.FindElement(By.Name("Email"));
        private IWebElement Cep => Driver.FindElement(By.Name("Cep"));
        private IWebElement Numero => Driver.FindElement(By.Name("Numero"));
        private IWebElement BtnProximaPagina1 => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Número do documento:'])[2]/following::button[1]"));

        private IWebElement PopUpPreencherDados => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Campaigns'])[1]/following::strong[1]"));
        //FIM SACADO

        //Inicio Cobranca
        private IWebElement Valor => Driver.FindElement(By.Name("Valor"));
        private IWebElement BtnAutoPreencher => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Número do documento:'])[1]/following::button[1]"));
        private IWebElement Numero14Calendario => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[1]/following::span[18]"));
        private IWebElement BtnProximaPagina2 => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anterior'])[1]/following::button[1]"));
        private IWebElement PopUpValorInvalido => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Valor inválido'])[1]/following::p[1]"));
        //Fim Cobranca

        //Inicio Juros e Multa
        private IWebElement PercentualJuros => Driver.FindElement(By.Name("PercentualJuros"));
        private IWebElement PercentualMulta => Driver.FindElement(By.Name("PercentualMulta"));
        private IWebElement DiaInicioCobrancaJuros => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[2]/following::span[19]"));
        private IWebElement DiaInicioCobrancaMulta => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[3]/following::span[26]"));
        private IWebElement BtnProximaPagina3 => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anterior'])[1]/following::button[1]"));
        //Fim Juros e Multa        

        //inicio Split
        private IWebElement DocumentoSplit => Driver.FindElement(By.Name("DocumentoSplit"));
        private IWebElement TaxaSplit => Driver.FindElement(By.Name("TaxaSplit"));
        private IWebElement CelularSplit => Driver.FindElement(By.Name("CelularSplit"));
        private IWebElement NomeRazaoSplit => Driver.FindElement(By.Name("NomeRazaoSplit"));
        private IWebElement EmailSplit => Driver.FindElement(By.Name("EmailSplit"));
        private IWebElement BtnIncluirSplit => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='E-mail:'])[1]/following::button[1]"));
        private IWebElement BtnProximaPagina4 => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anterior'])[1]/following::button[1]"));
        //Fim Split
        #endregion

        #region Metodos de Testes 
        public void Sacado(string documento, string nomeourazao, string celular, string email, string cep, string numero)
        {
            BtnBoleto.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            BtnEmissao.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Documento.SendKeys(documento);
            Thread.Sleep(350);
            NomeRazao.SendKeys(nomeourazao);
            Thread.Sleep(350);
            Celular.SendKeys(celular);
            Thread.Sleep(350);
            Email.SendKeys(email);
            Thread.Sleep(350);
            Cep.SendKeys(cep);
            Thread.Sleep(350);
            Numero.SendKeys(numero);
            Thread.Sleep(350);
            BtnProximaPagina1.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        public void SacadoComErros()
        {
            BtnBoleto.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            BtnEmissao.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            //Sem Dados
            BtnProximaPagina1.Click();
            Thread.Sleep(450);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            //Sem nenhum dado até o Momento.
            //Só com Documento Válido
            Documento.SendKeys("56121890010");
            Thread.Sleep(350);
            BtnProximaPagina1.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            //Só com Documento Válido até o momento.
            //Com Adição do Nome.
            Documento.Clear();
            Documento.SendKeys("56121890010");
            Thread.Sleep(350);
            NomeRazao.SendKeys("Rafael Vieira Tester");
            Thread.Sleep(350);
            BtnProximaPagina1.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            //Só com o Documento e o Nome Válido até o momento.
            //Com adição do Celular e o E-Mail.
            Documento.Clear();
            Documento.SendKeys("56121890010");
            Thread.Sleep(350);
            NomeRazao.Clear();
            NomeRazao.SendKeys("Rafael Vieira Tester");
            Thread.Sleep(350);
            Celular.SendKeys("11999665889");
            Thread.Sleep(350);
            Email.SendKeys("rafaelvplima@gmail.com");
            Thread.Sleep(350);
            BtnProximaPagina1.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            // Com Todos Dados Pessoais Válidos Até o Momento.
            //Com CEP Válido porém sem o Número
            Documento.Clear();
            Documento.SendKeys("56121890010");
            Thread.Sleep(350);
            NomeRazao.Clear();
            NomeRazao.SendKeys("Rafael Vieira Tester");
            Thread.Sleep(350);
            Celular.Clear();
            Celular.SendKeys("11999665889");
            Thread.Sleep(350);
            Email.Clear();
            Email.SendKeys("rafaelvplima@gmail.com");
            Thread.Sleep(350);
            Cep.SendKeys("03980150");
            Thread.Sleep(350);
            BtnProximaPagina1.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            //Dados Pessoais e o CEP Válido.
            //Com Todos Dados Inseridos, Porém o CPF Inválido.
            Documento.Clear();
            Documento.SendKeys("561218900");
            Thread.Sleep(350);
            NomeRazao.Clear();
            NomeRazao.SendKeys("Rafael Vieira Tester");
            Thread.Sleep(350);
            Celular.Clear();
            Celular.SendKeys("11999665889");
            Thread.Sleep(350);
            Email.Clear();
            Email.SendKeys("rafaelvplima@gmail.com");
            Thread.Sleep(350);
            Cep.Clear();
            Cep.SendKeys("03980150");
            Thread.Sleep(350);
            BtnProximaPagina1.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            //Pronto. Todos Erros Possíveis.
        }

        public void Cobranca(string valor)
        {
            Valor.SendKeys(valor);
            BtnAutoPreencher.Click();
            Thread.Sleep(350);
            Numero14Calendario.Click();
            BtnProximaPagina2.Click();
            Thread.Sleep(500);
        }
        
        public void CobrancaComErros()
        {
            //Cobrança sem nenhum dado
            BtnProximaPagina2.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpValorInvalido.Displayed);
            Assert.AreEqual(PopUpValorInvalido.Text.ToLower(), "Valor do título não pode ser inferior a R$ 10,00".ToLower());
            //Cobraça com valor valido
            Valor.SendKeys("R$ 1.520,00");
            Thread.Sleep(500);
            BtnProximaPagina2.Click();
            Thread.Sleep(600);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            BtnProximaPagina2.Click();
            Thread.Sleep(600);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            //Cobrança com os auto preencher
            BtnAutoPreencher.Click();
            Thread.Sleep(350);
            BtnProximaPagina2.Click();
            Thread.Sleep(600);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            Thread.Sleep(1000);
            Numero14Calendario.Click();
            //Cobraça com valor valido
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Valor.Clear();
            Valor.SendKeys("R$ 50.500,01");
            BtnProximaPagina2.Click();
            Thread.Sleep(500);
            Assert.IsTrue(PopUpValorInvalido.Displayed);
            Assert.AreEqual(PopUpValorInvalido.Text.ToLower(), "Valor do título não pode ser superior a R$50000,00".ToLower());
        }

        public void JurosEMulta(string percentualjuros, string percentualmulta)
        {
            PercentualJuros.SendKeys(percentualjuros);
            Thread.Sleep(350);
            PercentualMulta.SendKeys(percentualmulta);
            Thread.Sleep(350);
            DiaInicioCobrancaJuros.Click();
            DiaInicioCobrancaMulta.Click();
            Thread.Sleep(500);
            BtnProximaPagina3.Click();
            Thread.Sleep(500);

        }

        public void JurosEMultaComErros()
        {
            PercentualJuros.SendKeys("101,00%");
            Thread.Sleep(350);
            PercentualMulta.SendKeys("101,00%");
            Thread.Sleep(350);
            DiaInicioCobrancaJuros.Click();
            DiaInicioCobrancaMulta.Click();
            Thread.Sleep(500);
            BtnProximaPagina3.Click();
            Thread.Sleep(350);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
        }

        public void Split(string documentoSplit, string taxaSplit, string celularSplit, string nomeRazaoSplit, string emailSplit)
        {
            DocumentoSplit.SendKeys(documentoSplit);
            Thread.Sleep(350);
            TaxaSplit.SendKeys(taxaSplit);
            Thread.Sleep(350);
            CelularSplit.SendKeys(celularSplit);
            Thread.Sleep(350);
            NomeRazaoSplit.SendKeys(nomeRazaoSplit);
            Thread.Sleep(350);
            EmailSplit.SendKeys(emailSplit);
            Thread.Sleep(350);
            BtnIncluirSplit.Click();
            Thread.Sleep(350);
            BtnProximaPagina4.Click();
            Thread.Sleep(500);
        }

        public void SplitComErros()
        {
            DocumentoSplit.SendKeys("  55aa!");
            Thread.Sleep(350);
            TaxaSplit.SendKeys("90,01");
            Thread.Sleep(350);
            CelularSplit.SendKeys("   aa!");
            Thread.Sleep(350);
            NomeRazaoSplit.SendKeys("Razão para Testes");
            Thread.Sleep(350);
            EmailSplit.SendKeys("matheus@hotmail.com.");
            Thread.Sleep(350);
            BtnIncluirSplit.Click();
            Thread.Sleep(350);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
        }

        #endregion
    }
}
