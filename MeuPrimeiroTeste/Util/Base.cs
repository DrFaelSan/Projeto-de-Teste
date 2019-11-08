using OpenQA.Selenium;
namespace MeuPrimeiroTeste.Util
{
    public class Base {
        public static IWebDriver Driver { get; set; }
        public static string baseURL { get; set; } = "http://merchant.intermeiopagamentos.com/#/";
    }
}
