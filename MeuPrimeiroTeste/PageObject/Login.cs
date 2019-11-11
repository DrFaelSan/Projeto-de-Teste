using MeuPrimeiroTeste.Util;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
namespace MeuPrimeiroTeste.PageObject
{
    /// <summary>
    /// Mapeamento da página de Login.
    /// </summary>
    public class Login : Base
    {
        #region Mapeamento da pagina 
        //Mapeamento do Login.
        private IWebElement Email => Driver.FindElement(By.Name("Email"));
        private IWebElement Senha => Driver.FindElement(By.Name("Senha"));
        private IWebElement BtnLoginEntrar => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Recuperar'])[1]/following::div[2]"));
        private IWebElement PopUpAtencao => Driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Atenção'])[1]/following::p[1]"));
        private IWebElement PopUpAtencaoDadosInvalidos => Driver.FindElement(By.Id("QXRlbiVDMyVBNyVDMyVBM29Vc3UlQzMlQTFyaW8lMjBlJTJGb3UlMjBzZW5oYSUyMGludiVDMyVBMWxpZG9zb3Jhbmdl"));
        #endregion

        #region Metodos de Testes 
        public void ExecutarLogin(string email, string senha)
        {
            Email.SendKeys(email);
            Senha.SendKeys(senha);
            BtnLoginEntrar.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        public void ExecutarLoginSemDados()
        {
            BtnLoginEntrar.Click();
            Thread.Sleep(350);
            Assert.IsTrue(PopUpAtencao.Displayed);
            Assert.AreEqual(PopUpAtencao.Text.ToLower(), "Necessário informar o(s) campos abaixo!".ToLower());
        }

        public void ExecurtarLoginSemEmail(string senha)
        {
            Senha.SendKeys(senha);
            BtnLoginEntrar.Click();
            Thread.Sleep(450);
            Assert.IsTrue(PopUpAtencao.Displayed);
            Assert.AreEqual(PopUpAtencao.Text.ToLower(), "Necessário informar o(s) campos abaixo!".ToLower());
        }

        public void ExecurtarLoginSemSenha(string email)
        {
            Email.SendKeys(email);
            BtnLoginEntrar.Click();
            Thread.Sleep(350);
            Assert.IsTrue(PopUpAtencao.Displayed);
            Assert.AreEqual(PopUpAtencao.Text.ToLower(), "Necessário informar o(s) campos abaixo!".ToLower());
        }

        public void ExecutarLoginComDadosIncorretos()
        {
            Email.SendKeys("email@exemplo.com");
            Senha.SendKeys("SenhaErrada");
            BtnLoginEntrar.Click();
            Thread.Sleep(550);
            Assert.IsTrue(PopUpAtencaoDadosInvalidos.Displayed);
            Assert.AreEqual(PopUpAtencaoDadosInvalidos.Text.ToLower(), "atenção\r\nusuário e/ou senha inválidos".ToLower());
        }

        #endregion

    }
}
