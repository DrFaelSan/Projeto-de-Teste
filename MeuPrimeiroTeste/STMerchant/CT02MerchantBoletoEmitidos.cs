using System;
using MeuPrimeiroTeste.PageObject;
using NUnit.Framework;
using MeuPrimeiroTeste.Util;

namespace STMerchant
{
    [TestFixture]
    //[Parallelizable(ParallelScope.Fixtures)] /*aqui eu deixo todos os testes de login em paralelo para rodar em conjunto*/
    public class CT02MerchantBoletoEmitidos : Metodos
    {
        private Login login = new Login();
        private BoletoEmitidos boleto = new BoletoEmitidos();

        //Aqui declaro qual navegador vou abrir meus testes!.
        public CT02MerchantBoletoEmitidos() : base(Browsers.Chrome) { }

        #region Testes de Boletos Emitidos.
        [Test]
        public void CT02MerchantBoletoEmitidosTest()
        {
            //try
            //{
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
                //login.ExecutarLogin("bruno.f@inttecnologia.com.br", "Senha123!"); /*Login Para Testes*/
                login.ExecutarLogin("Luiz@inttecnologia.com.br", "123aA#$"); /*Login para Testes porém com Emissão de Boleto , OBS: poucos boletos...*/
                //login.ExecutarLogin("ipay@interfocus.com.br", "1nterf0cusip4y"); /*Login que não pode Emitir Boletos...*/
                boleto.ProcessoDeFiltragemEmitidos();
            //}
            //catch (Exception ex)
            //{
            //    Helper.criarPasta();
            //    Helper.capturaImagem(Driver, "CT02MerchantBoletoEmitidos", "VizualizarboletosEmitidos");
            //    Thread.Sleep(800);
            //    //MailService.sendMail(ex.StackTrace, "Teste de Vizualização de Boletos Emitidos.");
            //    Helper.deletarPasta();
            //}
        }
        #endregion

    }
}
