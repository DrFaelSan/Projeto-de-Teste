using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MeuPrimeiroTeste.Logger
{
    public static class EscreverDados {

        static string Arquivo = AppDomain.CurrentDomain.BaseDirectory + "Evidencias";

        public static void Escrever(string PopUp)
        {
            // 1: Escreve uma linha para o novo arquivo        
            using (StreamWriter writer = new StreamWriter(Arquivo+"\\PopUp.txt", true))
            {
                writer.WriteLine(PopUp);
            }
        }

    }

}



