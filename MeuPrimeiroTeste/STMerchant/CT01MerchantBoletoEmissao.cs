using System;
using System.Text;
using MeuPrimeiroTeste.Logger;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MeuPrimeiroTeste.PageObject;
using System.Threading;

namespace MeuPrimeiroTeste.STMerchant
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CT01MerchantBoletoEmissao
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private login login;
        private BoletoEmissao boleto;

        [SetUp]//Acontece Antes do Teste
        public void SetupTest()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--test-type", "--disable-hang-monitor", "--new-window", "--no-sandbox", "--lang=" + "pt-BR");
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, chromeOptions); ;
            baseURL = "http://merchant.intermeiopagamentos.com/#/";
            verificationErrors = new StringBuilder();
            login = new login(driver);
            boleto = new BoletoEmissao(driver);
        }

        [TearDown]// Acontece Depois do Teste
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }


        #region TestesBoletoEmissao
        [Test]//O Teste.
        public void CT01MerchantBoletoEmissaoTest()
        {
            try
            {
                driver.Navigate().GoToUrl(baseURL);
                driver.Manage().Window.Maximize();
                login.ExecutarLogin("bruno.f@inttecnologia.com.br", "Senha123!");
                boleto.Sacado("77096739025", "Rafael Vieira Tester", "11999665889", "rafaelvplima@gmail.com", "03980150", "693");
                boleto.Cobranca("R$ 1.520,00");
                boleto.JurosEMulta("50,00%", "50,00%");
                boleto.Split("123.456.789-10", "50,00%", "(10) 91234-5678", "Zezé da Zaga", "futbol@zezinho.com");
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(driver, "CT01MerchantBoletoEmissaoTest", "ProcessoDeEmissão");
                Thread.Sleep(800);
                //MailService.sendMail(ex.StackTrace, "Teste de Processo de Emissão de Boleto.");
                Helper.deletarPasta();
            }
            finally
            {
                driver.Close();
            }
        }

        [Test]
        public void SacadoComErrosTest()
        {
            try
            {
                driver.Navigate().GoToUrl(baseURL);
                driver.Manage().Window.Maximize();
                login.ExecutarLogin("bruno.f@inttecnologia.com.br", "Senha123!");
                boleto.SacadoComErros();
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(driver, "SacadoComErrosTest", "SacadoComErros");
                //Thread.Sleep(800);
                //MailService.sendMail(ex.StackTrace, "Teste de Processo de Emissão Sacado Com Erros.");
                Helper.deletarPasta();
            }
            finally
            {
                driver.Close();
            }
        }

        [Test]
        public void CobrancaComErrosTest()
        {
            try
            {
                driver.Navigate().GoToUrl(baseURL);
                driver.Manage().Window.Maximize();
                login.ExecutarLogin("bruno.f@inttecnologia.com.br", "Senha123!");
                boleto.Sacado("77096739025", "Rafael Vieira Tester", "11999665889", "rafaelvplima@gmail.com", "03980150", "693");
                boleto.CobrancaComErros();
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(driver, "CobrancaComErrosTest", "CobrancaComErros()");
                Thread.Sleep(800);
                //MailService.sendMail(ex.StackTrace, "Teste de Processo de Emissão Cobrança Com Erros.");
                Helper.deletarPasta();
            }
            finally
            {
                driver.Close();
            }
        }

        #endregion


    }
}
