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
            try
            {
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
                login.ExecutarLogin("email", "senha"); /*Login Para Testes*/
                boleto.ProcessoDeFiltragemEmitidos();
            }
            catch (Exception ex)
            {
                throw; 
            }
        }
        #endregion

    }
}
