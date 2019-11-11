using System;
using System.Threading;
using MeuPrimeiroTeste.Logger;
using MeuPrimeiroTeste.PageObject;
using NUnit.Framework;
using MeuPrimeiroTeste.Util;

namespace STMerchant
{
    [TestFixture]
    //[Parallelizable(ParallelScope.Fixtures)] /*aqui eu deixo todos os testes de login em paralelo para rodar em conjunto*/
    public class CT03MerchantBoletoLote : Metodos
    {
        private Login login = new Login();
        private BoletoLote lote = new BoletoLote();

        //Aqui declaro qual navegador vou abrir meus testes!.
        public CT03MerchantBoletoLote() : base(Browsers.Chrome) { }


        #region Testes de Boleto Lote.
        [Test]
        public void CT03MerchantBoletoLoteTest()
        {
            //try
            //{
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                //login.ExecutarLogin("bruno.f@inttecnologia.com.br", "Senha123!"); /*Login Para Testes*/
                login.ExecutarLogin("Luiz@inttecnologia.com.br", "123aA#$"); /*Login para Testes porém com Emissão de Boleto , OBS: poucos boletos...*/
                //login.ExecutarLogin("ipay@interfocus.com.br", "1nterf0cusip4y"); /*Login que não pode Emitir Boletos...*/
                lote.VizualizarBoletosEmLote();
            //}
            //catch (Exception ex)
            //{
            //    Helper.criarPasta();
            //    Helper.capturaImagem(Driver, "CT03MerchantBoletoLote", "VizualizacaoBoletoLote");
            //    //MailService.sendMail(ex.StackTrace, "Teste de vizualização Boleto/Lote");
            //    Thread.Sleep(1250);
            //    Helper.deletarPasta();
            //}
        }

        #endregion
    }
}