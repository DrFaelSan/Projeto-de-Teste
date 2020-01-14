using System;
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
            try
            {
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                login.ExecutarLogin("Email", "Senha"); /*Login Para Testes*/
                lote.VizualizarBoletosEmLote();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}