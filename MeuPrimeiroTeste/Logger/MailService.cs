using System;
using System.IO;
using System.Net.Mail;

namespace MeuPrimeiroTeste.Logger
{
    public static class MailService
    {
        ///Método para enviar o e-mail.
        public static void sendMail(string excessao , string teste)
        {
            using (MailMessage oMail = new MailMessage())
            {
                ///Basicão do corpo do email
                oMail.Sender = new MailAddress("rafaelvplima@gmail.com");
                oMail.From = new MailAddress("matheus-397@hotmail.com");
                oMail.To.Add("matheus-397@hotmail.com");
                oMail.Subject = $"{teste} - Realtório de execução automática";
                oMail.IsBodyHtml = true;

                ///Aqui declaro o corpo do e-mail de uma forma HTML.
                oMail.Body =
                    (
                    "<!DOCTYPE html>" +
                     "<font face='Calibri'>Prezados,</font><br/><br/><font face='Calibri'> O teste regressivo referente ao projeto<b> Merchant </b> foi realizado devidamente.</font><br/><br/>" +
                     $"<font face='Calibri'> O erro que ocorreu no teste foi : {excessao}.</font><br/><br/>" +
                     "<font face='Calibri'>Em caso de dúvidas, procure o analista de QA responsável ou consulte o build referente no link https://suporte.intermeio.com/</font>. <br/><br/>" +
                     "<font face='Calibri'>Ateciosamente, </font> <br/>" +
                     "<font face='Calibri'>Rafael - Equipe QA</font><br/> " +
                     "</ html >"
                    );
                oMail.Priority = MailPriority.Normal;
                
                ///Conexão com o servidor de e-mail nesse caso o do Google.
                using (SmtpClient oSmtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    oSmtp.UseDefaultCredentials = false;
                    //Minhas credênciais para poder enviar um e-mail.
                    oSmtp.Credentials = new System.Net.NetworkCredential("rafaelvplima@gmail.com", "rpxtazzikzomsbbd");
                    oSmtp.EnableSsl = true;

                    /// Anexando evidências ao email
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
            ///Limpando diretório
            foreach (FileInfo file in new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Evidencias").GetFiles()){ File.Delete(file.FullName); }
            
        }
    }
}
