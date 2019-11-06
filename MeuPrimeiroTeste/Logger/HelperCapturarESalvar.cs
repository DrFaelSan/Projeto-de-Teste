using OpenQA.Selenium;
using System;
using System.IO;
namespace MeuPrimeiroTeste.Logger
{

    public static  class Helper
    {
        ///Diretorio que crio e salvo os dados.
        public static string screenshotsPasta = AppDomain.CurrentDomain.BaseDirectory + "Evidencias";
        
        ///Método para tirar a foto e salvar! esse método é chamado dentro do método "CapturarImagem."
        public static void Screenshot(IWebDriver driver, string screenshotsPasta)
        {
            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            foto.SaveAsFile(screenshotsPasta, ScreenshotImageFormat.Png);
        }

        ///Método que eu chamo para capturar a foto na hora que a aplicação quebra.
        public static void capturaImagem(IWebDriver driver, string casoDeteste, string param )
        {
            var data = DateTime.Now.ToShortDateString().Replace('/', '_');
            Screenshot(driver, AppDomain.CurrentDomain.BaseDirectory + "Evidencias" + "\\" + casoDeteste + "_" + "DDD_" + param + "Data_" + data + ".Png");
        }
        ///Método que eu uso para criar a pasta aonde os print's serão salvos.
        public static void criarPasta()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Evidencias";
            try
            {
                if (Directory.Exists(path))
                    return;
                
                DirectoryInfo pasta = Directory.CreateDirectory(path);
               
                //Console.WriteLine($"Pasta criada com sucesso {Directory.GetCreationTime(path)}.");
            }
            catch (Exception e)
            {
                //Console.WriteLine($"Não foi possível criar {e.ToString()}");
            }
        }


        /// Deletando repositório de evidências.
        public static void deletarPasta()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Evidencias";
            try
            {
                if (Directory.Exists(path))
                {

                    foreach (var files in Directory.GetDirectories(path))
                        if (files.Contains(".png") || files.Contains(".txt"))
                            Directory.Delete(path, true);
                    return;
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine($"Não foi possível deletar {e.ToString()}");
            }
        }
    }
 }
