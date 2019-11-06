using MeuPrimeiroTeste.Logger;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
namespace MeuPrimeiroTeste.PageObject
{
    /// <summary>
    /// Mapeamento da página de Login.
    /// </summary>
    public class login
    {
        public IWebDriver _driver;

        public login(IWebDriver driver) => _driver = driver; 

        //Mapeamento do Login.
        private IWebElement Email => _driver.FindElement(By.Name("Email"));
        private IWebElement Senha => _driver.FindElement(By.Name("Senha"));
        private IWebElement BtnLoginEntrar => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Recuperar'])[1]/following::div[2]"));
        private IWebElement PopUpAtencao => _driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Atenção'])[1]/following::p[1]"));
        private IWebElement PopUpAtencaoDadosInvalidos => _driver.FindElement(By.Id("QXRlbiVDMyVBNyVDMyVBM29Vc3UlQzMlQTFyaW8lMjBlJTJGb3UlMjBzZW5oYSUyMGludiVDMyVBMWxpZG9zb3Jhbmdl"));

        public void ExecutarLogin(string email, string senha)
        {
            Email.SendKeys(email);
            Senha.SendKeys(senha);
            BtnLoginEntrar.Click();
            Thread.Sleep(1250);
        }

        public void ExecutarLoginSemDados()
        {
            BtnLoginEntrar.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpAtencao.Displayed);
            //EscreverDados.Escrever(PopUpAtencao.Text.ToLower());
            Assert.AreEqual(PopUpAtencao.Text.ToLower(), "Necessário informar o(s) campos abaixo!".ToLower());
            PopUpAtencao.Click();

        }

        public void ExecurtarLoginSemEmail(string senha)
        {
            Senha.SendKeys(senha);
            BtnLoginEntrar.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpAtencao.Displayed);
           // EscreverDados.Escrever(PopUpAtencao.Text.ToLower());
            Assert.AreEqual(PopUpAtencao.Text.ToLower(), "Necessário informar o(s) campos abaixo!".ToLower());
            PopUpAtencao.Click();
        }

        public void ExecurtarLoginSemSenha(string email)
        {
            Email.SendKeys(email);
            BtnLoginEntrar.Click();
            Thread.Sleep(250);
            Assert.IsTrue(PopUpAtencao.Displayed);
            //EscreverDadosDePop.Escrever(PopUpAtencao.Text.ToLower());
            Assert.AreEqual(PopUpAtencao.Text.ToLower(), "Necessário informar o(s) campos abaixo!".ToLower());
            PopUpAtencao.Click();
        }

        public void ExecutarLoginComDadosIncorretos()
        {
            Email.SendKeys("email@exemplo.com");
            Senha.SendKeys("SenhaErrada");
            BtnLoginEntrar.Click();
            Thread.Sleep(500);
            PopUpAtencaoDadosInvalidos.Click();
            Assert.IsTrue(PopUpAtencaoDadosInvalidos.Displayed);
            //EscreverDados.Escrever(PopUpAtencaoDadosInvalidos.Text.ToLower());
            Assert.AreEqual(PopUpAtencaoDadosInvalidos.Text.ToLower(), "atenção\r\nusuário e/ou senha inválidos".ToLower());
        }

    }
}
