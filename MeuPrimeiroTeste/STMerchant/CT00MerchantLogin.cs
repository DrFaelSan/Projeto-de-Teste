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
    public class CT00MerchantLogin
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private login login;

        [SetUp] //Acontece Antes do Teste
        public void SetupTest()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--test-type", "--disable-hang-monitor", "--new-window", "--no-sandbox", "--lang=" + "pt-BR");
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, chromeOptions); ;
            baseURL = "http://merchant.intermeiopagamentos.com/#/";
            verificationErrors = new StringBuilder();
            login = new login(driver);
        }

        [TearDown] // Acontece Depois do Teste
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


        #region TestesDeLogin 
        [Test]
        public void TesteSemDadosLogin()
        {
            try
            {
                driver.Navigate().GoToUrl(baseURL);
                driver.Manage().Window.Maximize();
                login.ExecutarLoginSemDados();
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(driver, "TesteSemDadosLogin", "SemDados");
                //Thread.Sleep(800);
                //MailService.sendMail(ex.StackTrace, "Teste Sem Dados no Login");
                Helper.deletarPasta();
            }
            finally
            {
                driver.Close();
            }
        }

        [Test]
        public void TesteSemEmailLogin()
        {
            try
            {
                driver.Navigate().GoToUrl(baseURL);
                driver.Manage().Window.Maximize();
                login.ExecurtarLoginSemEmail("Senha123!");
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(driver, "TesteSemEmailLogin", "SemEmail");
                Thread.Sleep(800);
                MailService.sendMail(ex.StackTrace, "Teste Sem Email no Login");
                Helper.deletarPasta();
            }
            finally
            {
                driver.Close();
            }
        }

        [Test]
        public void TesteSemSenhaLogin()
        {
            try
            {
                driver.Navigate().GoToUrl(baseURL);
                driver.Manage().Window.Maximize();
                login.ExecurtarLoginSemSenha("bruno.f@inttecnologia.com.br");
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(driver, "TesteSemSenhaLogin", "SemSenha");
                Thread.Sleep(800);
                MailService.sendMail(ex.StackTrace, "Teste Sem Senha no Login");
                Helper.deletarPasta();
            }
            finally
            {
                driver.Close();
            }

        }

        [Test]
        public void TesteComDadosIncorretos()
        {
            try
            {
                driver.Navigate().GoToUrl(baseURL);
                driver.Manage().Window.Maximize();
                login.ExecutarLoginComDadosIncorretos();
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(driver, "TesteComDadosIncorretos", "TesteComDadosIncorretos");
                EscreverDados.Escrever(ex.Message);
                Thread.Sleep(800);
                MailService.sendMail(ex.StackTrace, "Teste Com Dados Incorretos");
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
