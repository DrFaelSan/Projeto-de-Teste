using System;
using System.IO;
using System.Net.Mail;

namespace MeuPrimeiroTeste.Logger
{
    public static class MailService
    {
        ///M�todo para enviar o e-mail.
        public static void sendMail(string excessao , string teste)
        {
            using (MailMessage oMail = new MailMessage())
            {
                ///Basic�o do corpo do email
                oMail.Sender = new MailAddress("rafaelvplima@gmail.com");
                oMail.From = new MailAddress("matheus-397@hotmail.com");
                oMail.To.Add("matheus-397@hotmail.com");
                oMail.Subject = $"{teste} - Realt�rio de execu��o autom�tica";
                oMail.IsBodyHtml = true;

                ///Aqui declaro o corpo do e-mail de uma forma HTML.
                oMail.Body =
                    (
                    "<!DOCTYPE html>" +
                     "<font face='Calibri'>Prezados,</font><br/><br/><font face='Calibri'> O teste regressivo referente ao projeto<b> Merchant </b> foi realizado devidamente.</font><br/><br/>" +
                     $"<font face='Calibri'> O erro que ocorreu no teste foi : {excessao}.</font><br/><br/>" +
                     "<font face='Calibri'>Em caso de d�vidas, procure o analista de QA respons�vel ou consulte o build referente no link https://suporte.intermeio.com/</font>. <br/><br/>" +
                     "<font face='Calibri'>Ateciosamente, </font> <br/>" +
                     "<font face='Calibri'>Rafael - Equipe QA</font><br/> " +
                     "</ html >"
                    );
                oMail.Priority = MailPriority.Normal;
                
                ///Conex�o com o servidor de e-mail nesse caso o do Google.
                using (SmtpClient oSmtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    oSmtp.UseDefaultCredentials = false;
                    //Minhas cred�nciais para poder enviar um e-mail.
                    oSmtp.Credentials = new System.Net.NetworkCredential("rafaelvplima@gmail.com", "rpxtazzikzomsbbd");
                    oSmtp.EnableSsl = true;

                    /// Anexando evid�ncias ao email
                    DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Evidencias");
                    foreach (FileInfo file in dir.GetFiles()) { oMail.Attachments.Add(new Attachment(file.FullName)); } 

                    try
                    {
                        Console.WriteLine("Iniciando envio de email  ...");
                        oSmtp.Send(oMail);
                        Console.WriteLine("Email enviado!");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Falha devido ao erro:");
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            ///Limpando diret�rio
            foreach (FileInfo file in new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Evidencias").GetFiles()){ File.Delete(file.FullName); }
            
        }
    }
}
