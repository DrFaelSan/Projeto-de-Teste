using System;
using NUnit.Framework;
using MeuPrimeiroTeste.PageObject;
using System.Threading;
using MeuPrimeiroTeste.Util;

namespace STMerchant
{
    [TestFixture]
    //[Parallelizable(ParallelScope.Fixtures)] /*aqui eu deixo todos os testes de login em paralelo para rodar em conjunto*/
    public class CT00MerchantLogin : Metodos
    {

        private Login login = new Login();

        public CT00MerchantLogin() : base(Browsers.Chrome) { }


        #region TestesDeLogin 
        [Test]
        public void TesteSemDadosLogin()
        {
            try
            {
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                Thread.Sleep(4000);
                login.ExecutarLoginSemDados();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Test]
        public void TesteSemEmailLogin()
        {
            try
            {
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                login.ExecurtarLoginSemEmail("Senha");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Test]
        public void TesteSemSenhaLogin()
        {
            try
            {
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                login.ExecurtarLoginSemSenha("Email");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Test]
        public void TesteComDadosIncorretos()
        {
            try
            {
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                login.ExecutarLoginComDadosIncorretos();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
