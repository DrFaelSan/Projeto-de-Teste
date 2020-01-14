using System;
using NUnit.Framework;
using MeuPrimeiroTeste.PageObject;
using MeuPrimeiroTeste.Util;
using System.Threading;

namespace STMerchant
{
    [TestFixture]
    //[Parallelizable(ParallelScope.Fixtures)] /*aqui eu deixo todos os testes de login em paralelo para rodar em conjunto*/
    public class CT01MerchantBoletoEmissao : Metodos
    {
        private readonly Login login = new Login();
        private readonly BoletoEmissao boleto = new BoletoEmissao();

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
                login.ExecutarLogin("email", "senha"); /*Login Para Testes*/
                boleto.Sacado("documentoSacado", "Rafael Vieira Tester", "numeroCelularSacado", "Email", "Cep", "NumeroCasaSacado");
                boleto.Cobranca("R$ 1.500,00");
                boleto.JurosEMulta("05,00%", "05,00%");
                boleto.Split("documentoSplit", "50,00%", "NumeroCelularSplit", "Matheus Santana", "EmailSplit");
            }
            catch (Exception ex)
            {
                throw;
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
                login.ExecutarLogin("email", "senha"); /*Login Para Testes*/
                boleto.SacadoComErros();
            }
            catch (Exception ex)
            { 
            throw;
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
                login.ExecutarLogin("email", "senha"); /*Login Para Testes*/
                boleto.Sacado("documentoSacado", "Rafael Vieira Tester", "numeroCelularSacado", "Email", "Cep", "NumeroCasaSacado");
                boleto.CobrancaComErros();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [Test]
        public void JurosComErroTest()
        {
            try
            {
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                login.ExecutarLogin("email", "senha"); /*Login Para Testes*/
                boleto.Sacado("documentoSacado", "Rafael Vieira Tester", "numeroCelularSacado", "Email", "Cep", "NumeroCasaSacado");
                boleto.Cobranca("R$ 1.520,00");
                boleto.JurosEMultaComErros();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [Test]
        public void SplitComErroTest()
        {

            try
            {
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                login.ExecutarLogin("email", "senha"); /*Login Para Testes*/
                boleto.Sacado("documentoSacado", "Rafael Vieira Tester", "numeroCelularSacado", "Email", "Cep", "NumeroCasaSacado");
                boleto.Cobranca("R$ 1.500,00");
                boleto.JurosEMulta("05,00%", "05,00%");
                boleto.SplitComErros();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
