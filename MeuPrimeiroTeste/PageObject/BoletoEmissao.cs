﻿using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using MeuPrimeiroTeste.Logger;

namespace MeuPrimeiroTeste.PageObject
{
    /// <summary>
    /// Mapeamento do processo de Emitir Boleto.
    /// </summary>
    public class BoletoEmissao
    {
        public IWebDriver _driver;
        public BoletoEmissao(IWebDriver driver) => _driver = driver;

        //Botão Boleto ! Inicio do Processo ! 
        private IWebElement BtnBoleto => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Dashboard'])[1]/following::span[1]"));
        private IWebElement BtnEmissao => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Boleto'])[1]/following::span[1]"));
        private IWebElement Documento => _driver.FindElement(By.Name("Documento"));
        private IWebElement NomeRazao => _driver.FindElement(By.Name("NomeRazao"));
        private IWebElement Celular => _driver.FindElement(By.Name("Celular"));
        private IWebElement Email => _driver.FindElement(By.Name("Email"));
        private IWebElement Cep => _driver.FindElement(By.Name("Cep"));
        private IWebElement Numero => _driver.FindElement(By.Name("Numero"));
        private IWebElement BtnProximaPagina1 => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Número do documento:'])[2]/following::button[1]"));

        private IWebElement PopUpPreencherDados => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Campaigns'])[1]/following::strong[1]"));
        //FIM SACADO


        //Inicio Cobranca
        private IWebElement Valor => _driver.FindElement(By.Name("Valor"));
        private IWebElement BtnAutoPreencher => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Número do documento:'])[1]/following::button[1]"));
        private IWebElement Numero14Calendario => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[1]/following::span[18]"));
        private IWebElement BtnProximaPagina2 => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anterior'])[1]/following::button[1]"));
        private IWebElement PopUpPreencherDados2 => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Preenchimento obrigatório'])[2]/following::p[1]"));
        private IWebElement PopUpValorInferior10 => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Valor inválido'])[1]/following::p[1]"));
        //Fim Cobranca

        //Inicio Juros e Multa
        private IWebElement PercentualJuros => _driver.FindElement(By.Name("PercentualJuros"));
        private IWebElement PercentualMulta => _driver.FindElement(By.Name("PercentualMulta"));
        private IWebElement DiaInicioCobrancaJuros => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[2]/following::span[19]"));
        private IWebElement DiaInicioCobrancaMulta => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='D'])[3]/following::span[26]"));
        private IWebElement BtnProximaPagina3 => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anterior'])[1]/following::button[1]"));
        //Fim Juros e Multa        

        //inicio Split
        private IWebElement DocumentoSplit => _driver.FindElement(By.Name("DocumentoSplit"));
        private IWebElement TaxaSplit => _driver.FindElement(By.Name("TaxaSplit"));
        private IWebElement CelularSplit => _driver.FindElement(By.Name("CelularSplit"));
        private IWebElement NomeRazaoSplit => _driver.FindElement(By.Name("NomeRazaoSplit"));
        private IWebElement EmailSplit => _driver.FindElement(By.Name("EmailSplit"));
        private IWebElement BtnIncluirSplit => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='E-mail:'])[1]/following::button[1]"));
        private IWebElement BtnProximaPagina4 => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anterior'])[1]/following::button[1]"));
        //Fim Split

        public void Sacado(string documento, string nomeourazao, string celular, string email, string cep, string numero)
        {
            BtnBoleto.Click();
            Thread.Sleep(1300);
            BtnEmissao.Click();
            Thread.Sleep(1300);
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
            Thread.Sleep(500);
        }

        public void SacadoComErros()
        {
            BtnBoleto.Click();
            Thread.Sleep(1300);
            BtnEmissao.Click();
            Thread.Sleep(1300);
            //Sem Dados
            BtnProximaPagina1.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            EscreverDados.Escrever(PopUpPreencherDados.Text.ToLower());
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            PopUpPreencherDados.Click();
            //Sem nenhum dado até o Momento.
            //Só com Documento Válido
            Documento.SendKeys("56121890010");
            Thread.Sleep(350);
            BtnProximaPagina1.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            EscreverDados.Escrever(PopUpPreencherDados.Text.ToLower());
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            PopUpPreencherDados.Click();
            //Só com Documento Válido até o momento.
            //Com Adição do Nome.
            Documento.SendKeys("56121890010");
            Thread.Sleep(350);
            NomeRazao.SendKeys("Rafael Vieira Tester");
            Thread.Sleep(350);
            BtnProximaPagina1.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            EscreverDados.Escrever(PopUpPreencherDados.Text.ToLower());
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            PopUpPreencherDados.Click();
            //Só com o Documento e o Nome Válido até o momento.
            //Com adição do Celular e o E-Mail.
            Documento.SendKeys("56121890010");
            Thread.Sleep(350);
            NomeRazao.SendKeys("Rafael Vieira Tester");
            Thread.Sleep(350);
            Celular.SendKeys("11999665889");
            Thread.Sleep(350);
            Email.SendKeys("rafaelvplima@gmail.com");
            Thread.Sleep(350);
            BtnProximaPagina1.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            EscreverDados.Escrever(PopUpPreencherDados.Text.ToLower());
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            PopUpPreencherDados.Click();
            // Com Todos Dados Pessoais Válidos Até o Momento.
            //Com CEP Válido porém sem o Número
            Documento.SendKeys("56121890010");
            Thread.Sleep(350);
            NomeRazao.SendKeys("Rafael Vieira Tester");
            Thread.Sleep(350);
            Celular.SendKeys("11999665889");
            Thread.Sleep(350);
            Email.SendKeys("rafaelvplima@gmail.com");
            Thread.Sleep(350);
            Cep.SendKeys("03980150");
            Thread.Sleep(350);
            BtnProximaPagina1.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            EscreverDados.Escrever(PopUpPreencherDados.Text.ToLower());
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            PopUpPreencherDados.Click();
            //Dados Pessoais e o CEP Válido.
            //Com Todos Dados Inseridos, Porém o CPF Inválido.
            Documento.SendKeys("561218900");
            Thread.Sleep(350);
            NomeRazao.SendKeys("Rafael Vieira Tester");
            Thread.Sleep(350);
            Celular.SendKeys("11999665889");
            Thread.Sleep(350);
            Email.SendKeys("rafaelvplima@gmail.com");
            Thread.Sleep(350);
            Cep.SendKeys("03980150");
            Thread.Sleep(350);
            BtnProximaPagina1.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpPreencherDados.Displayed);
            EscreverDados.Escrever(PopUpPreencherDados.Text.ToLower());
            Assert.AreEqual(PopUpPreencherDados.Text.ToLower(), "preenchimento obrigatório".ToLower());
            PopUpPreencherDados.Click();
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
        
        public void CobrancaComErro()
        {
            BtnProximaPagina2.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpValorInferior10.Displayed);
            EscreverDados.Escrever(PopUpValorInferior10.Text.ToLower());
            Assert.AreEqual(PopUpValorInferior10.Text.ToLower(), "preenchimento obrigatório".ToLower());
            PopUpPreencherDados.Click();
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
    }
}