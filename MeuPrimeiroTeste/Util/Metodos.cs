using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using NUnit.Framework;
using System;
using System.Threading;

namespace MeuPrimeiroTeste.Util
{
    [TestFixture]
    public class Metodos : Base
    {

        #region Browser

        private Browsers _BrowserSelecionado;
        public Metodos(Browsers browser) => _BrowserSelecionado = browser;

        [SetUp]
        public void IniciarTestes() => BuscarDriverLocal(_BrowserSelecionado);


        private void BuscarDriverLocal(Browsers browsers)
        {
            switch (browsers)
            {
                default:
                case Browsers.Chrome:
                    Driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory); break;
                case Browsers.FireFox:
                    Driver = new FirefoxDriver();
                    break;
                case Browsers.Edge:
                    Driver = new EdgeDriver();
                    break;
            }
        }

        [TearDown]
        public void FinalizarTeste() => Driver.Dispose();
        #endregion

        #region JavaScript
        public static void ExecutarJavaScript(IWebDriver driver, string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteAsyncScript(script);
        }
        #endregion
    }
}
