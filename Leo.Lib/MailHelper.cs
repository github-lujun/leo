using System;
using System.Net;
using System.Net.Mail;

namespace Leo.Lib
{
    public class MailHelper
    {
        public static void SendMail(String from,String[] to,String subject,String body,String username,String password,String smtp)
        {
            SendMail(new MailAddress(from), to, subject, body, username, password,smtp);
        }

        public static void SendMail(MailAddress from, String[] to, String subject, String body, String username, String password, String smtp)
        {
            var mail = new MailMessage();
            mail.From = from;
            foreach (var t in to)
            {
                mail.To.Add(t);
            }
            mail.Subject = subject;
            mail.Body = body;
            var client = new SmtpClient(smtp);
            client.Credentials = new NetworkCredential(username,password);
            client.Send(mail);
        }
    }
}
