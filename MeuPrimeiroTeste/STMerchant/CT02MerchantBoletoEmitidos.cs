using System;
using System.Text;
using System.Threading;
using MeuPrimeiroTeste.Logger;
using MeuPrimeiroTeste.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace STMerchant
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CT02MerchantBoletoEmitidos
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private login login;
        private BoletoEmitidos boleto;

        [SetUp]
        public void SetupTest()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--test-type", "--disable-hang-monitor", "--new-window", "--no-sandbox", "--lang=" + "pt-BR");
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, chromeOptions); 
            baseURL = "http://merchant.intermeiopagamentos.com/#/";
            verificationErrors = new StringBuilder();
            login = new login(driver);
            boleto = new BoletoEmitidos(driver);
        }

        [TearDown]
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

        [Test]
        public void CT02MerchantBoletoEmitidosTest()
        {
            try
            {
                driver.Navigate().GoToUrl(baseURL);
                driver.Manage().Window.Maximize();
                login.ExecutarLogin("bruno.f@inttecnologia.com.br", "Senha123!");
                boleto.ProcessoDeFiltragemEmitidos();
            }
            catch (Exception ex )
            {
                Helper.criarPasta();
                Helper.capturaImagem(driver, "CT02MerchantBoletoEmitidos", "VizualizarboletosEmitidos");
                Thread.Sleep(800);
                MailService.sendMail(ex.StackTrace, "Teste de Vizualização de Boletos Emitidos.");
                Helper.deletarPasta();
            }
            finally
            {
                driver.Close();
            }
        }
    }
}
