using System;
using MeuPrimeiroTeste.Logger;
using NUnit.Framework;
using MeuPrimeiroTeste.PageObject;
using System.Threading;
using MeuPrimeiroTeste.Util;
using Docker.DotNet.Models;

namespace STMerchant
{
    [TestFixture]
    //[Parallelizable(ParallelScope.Fixtures)] /*aqui eu deixo todos os testes de login em paralelo para rodar em conjunto*/
    public class CT01MerchantBoletoEmissao : Metodos
    {
        private Login login = new Login();
        private BoletoEmissao boleto = new BoletoEmissao();

        //Aqui declaro qual navegador vou abrir meus testes!.
        public CT01MerchantBoletoEmissao() : base(Browsers.Chrome) { }

        #region Testes de Boleto Emissao.
        [Test]//O Teste.
        public void CT01MerchantBoletoEmissaoTest()
        {
            try
            {
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                //login.ExecutarLogin("bruno.f@inttecnologia.com.br", "Senha123!"); /*Login Para Testes*/
                login.ExecutarLogin("Luiz@inttecnologia.com.br", "123aA#$"); /*Login para Testes porém com Emissão de Boleto , OBS: poucos boletos...*/
                //login.ExecutarLogin("ipay@interfocus.com.br", "1nterf0cusip4y"); /*Login que não pode Emitir Boletos...*/
                boleto.Sacado("46248408874", "Rafael Vieira Tester", "11987533130", "rafaelvplima@gmail.com", "04383037", "83");
                boleto.Cobranca("R$ 1.500,00");
                boleto.JurosEMulta("05,00%", "05,00%");
                boleto.Split("443.114.018-25", "50,00%", "(11) 95784-3798", "Matheus Santana", "matheus-397@hotmail.com");
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(Driver, "CT01MerchantBoletoEmissaoTest", "ProcessoDeEmissão");
                Thread.Sleep(800);
                //MailService.sendMail(ex.StackTrace, "Teste de Processo de Emissão de Boleto.");
                Helper.deletarPasta();
            }
        }

        [Test]
        public void SacadoComErrosTest()
        {
            try
            {
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                Thread.Sleep(4000);
                //login.ExecutarLogin("bruno.f@inttecnologia.com.br", "Senha123!"); /*Login Para Testes*/
                login.ExecutarLogin("Luiz@inttecnologia.com.br", "123aA#$"); /*Login para Testes porém com Emissão de Boleto , OBS: poucos boletos...*/
                //login.ExecutarLogin("ipay@interfocus.com.br", "1nterf0cusip4y"); /*Login que não pode Emitir Boletos...*/
                boleto.SacadoComErros();
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(Driver, "SacadoComErrosTest", "SacadoComErros");
                //Thread.Sleep(800);
                //MailService.sendMail(ex.StackTrace, "Teste de Processo de Emissão Sacado Com Erros.");
                Helper.deletarPasta();
            }
        }

        [Test]
        public void CobrancaComErrosTest()
        {
            try
            {
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                Thread.Sleep(4000);
                //login.ExecutarLogin("bruno.f@inttecnologia.com.br", "Senha123!"); /*Login Para Testes*/
                login.ExecutarLogin("Luiz@inttecnologia.com.br", "123aA#$"); /*Login para Testes porém com Emissão de Boleto , OBS: poucos boletos...*/
                //login.ExecutarLogin("ipay@interfocus.com.br", "1nterf0cusip4y"); /*Login que não pode Emitir Boletos...*/
                boleto.Sacado("77096739025", "Rafael Vieira Tester", "11999665889", "rafaelvplima@gmail.com", "03980150", "693");
                boleto.CobrancaComErros();
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(Driver, "CobrancaComErrosTest", "CobrancaComErros()");
                Thread.Sleep(800);
                //MailService.sendMail(ex.StackTrace, "Teste de Processo de Emissão Cobrança Com Erros.");
                Helper.deletarPasta();
            }
        }


        [Test]
        public void JurosComErroTest()
        {
            try
            {
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                login.ExecutarLogin("bruno.f@inttecnologia.com.br", "Senha123!");
                boleto.Sacado("77096739025", "Rafael Vieira Tester", "11999665889", "rafaelvplima@gmail.com", "03980150", "693");
                boleto.Cobranca("R$ 1.520,00");
                boleto.JurosEMultaComErros();
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(Driver, "CobrancaComErrosTest", "CobrancaComErros()");
                Thread.Sleep(800);
                //MailService.sendMail(ex.StackTrace, "Teste de Processo de Emissão Cobrança Com Erros.");
                //Helper.deletarPasta();
            }
            finally
            {
                Driver.Close();
            }
        }

        [Test]
        public void SplitComErroTest()
        {

            try
            {
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                login.ExecutarLogin("bruno.f@inttecnologia.com.br", "Senha123!");
              
            }
            catch (Exception ex)
            {
                Helper.criarPasta();
                Helper.capturaImagem(Driver, "CobrancaComErrosTest", "CobrancaComErros()");
                Thread.Sleep(800);
                //MailService.sendMail(ex.StackTrace, "Teste de Processo de Emissão Cobrança Com Erros.");
                //Helper.deletarPasta();
            }
            finally
            {
                Driver.Close();
            }
        }
        #endregion
    }
}
