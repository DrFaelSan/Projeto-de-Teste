using System;
using MeuPrimeiroTeste.Logger;
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
                Helper.criarPasta();
                Helper.capturaImagem(Driver, "TesteSemDadosLogin", "SemDados");
                EscreverDados.Escrever(ex.Message);
                Thread.Sleep(800);
                //MailService.sendMail(ex.StackTrace, "Teste Sem Dados no Login");
                Helper.deletarPasta();
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
                login.ExecurtarLoginSemEmail("Senha123!");
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(Driver, "TesteSemEmailLogin", "SemEmail");
                EscreverDados.Escrever(ex.Message);
                Thread.Sleep(800);
                //MailService.sendMail(ex.StackTrace, "Teste Sem Email no Login");
                Helper.deletarPasta();
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
                login.ExecurtarLoginSemSenha("bruno.f@inttecnologia.com.br");
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(Driver, "TesteSemSenhaLogin", "SemSenha");
                EscreverDados.Escrever(ex.Message);
                Thread.Sleep(800);
                //MailService.sendMail(ex.StackTrace, "Teste Sem Senha no Login");
                Helper.deletarPasta();
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
                Helper.criarPasta();
                Helper.capturaImagem(Driver, "TesteComDadosIncorretos", "TesteComDadosIncorretos");
                EscreverDados.Escrever(ex.Message);
                Thread.Sleep(800);
                //MailService.sendMail(ex.StackTrace, "Teste Com Dados Incorretos");
                Helper.deletarPasta();
            }
        }
        #endregion
    }
}
