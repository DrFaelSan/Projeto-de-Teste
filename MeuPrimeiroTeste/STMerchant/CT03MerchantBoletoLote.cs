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
    public class CT03MerchantBoletoLote
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private login login;
        private BoletoLote lote;


        [SetUp] 
        public void SetupTest()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--test-type", "--disable-hang-monitor", "--new-window", "--no-sandbox", "--lang=" + "pt-BR");
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, chromeOptions); ;
            baseURL = "http://merchant.intermeiopagamentos.com/#/";
            verificationErrors = new StringBuilder();
            login = new login(driver);
            lote = new BoletoLote(driver);
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
        public void CT03MerchantBoletoLoteTest()
        {
            try
            {
                driver.Navigate().GoToUrl(baseURL);
                driver.Manage().Window.Maximize();
                login.ExecutarLogin("bruno.f@inttecnologia.com.br", "Senha123!");
                lote.VizualizarBoletosEmLote();
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(driver, "CT03MerchantBoletoLote", "VizualizacaoBoletoLote");
                MailService.sendMail(ex.StackTrace, "Teste de vizualização Boleto/Lote");
                Thread.Sleep(1250);
                Helper.deletarPasta();
            }
            finally
            {
                driver.Close();
            }
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)

                    alert.Accept();

                else

                    alert.Dismiss();

                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}