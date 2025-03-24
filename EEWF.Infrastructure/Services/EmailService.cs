using EEWF.Application.Interfaces;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string subject, string html)
        {

            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse(""));
            //email.To.Add(MailboxAddress.Parse(to));
            //email.Subject = subject;
            //email.Body = new TextPart(TextFormat.Html) { Text = html };

            //// send email
            //using var smtp = new SmtpClient();
            //smtp.Connect("smtp.englishwithfidan.com", 25, SecureSocketOptions.StartTls);
            //smtp.Authenticate("postmaster@englishwithfidan.com", "NurlanAztu2003.");
            //smtp.Send(email);
            //smtp.Disconnect(true);
            //---------------
            //string smtpServer = "mail5018.site4now.net";
            //int smtpPort = 25;
            //string email = "postmaster@englishwithfidan.com";
            //string password = "NurlanAztu2003.";

            //// E-posta göndermek için SMTP istemcisini oluşturun
            //SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            //smtpClient.EnableSsl = true; // Gerekirse SSL/TLS kullanın
            //smtpClient.Credentials = new NetworkCredential(email, password);

            //// Göndermek istediğiniz e-posta bilgilerini ayarlayın
            //MailMessage mailMessage = new MailMessage();
            //mailMessage.From = new MailAddress(email);
            //mailMessage.To.Add(to);
            //mailMessage.Subject = subject;
            //mailMessage.Body = html;
            //----------------
            //string smtpServer = "smtp.englishwithfidan.com";
            //int smtpPort = 25;
            //string email = "postmaster@englishwithfidan.com";
            //string password = "NurlanAztu2003.";

            //using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            //{
            //    smtpClient.EnableSsl = true;
            //    smtpClient.Credentials = new NetworkCredential(email, password);

            //    using (MailMessage mailMessage = new MailMessage(email, to))
            //    {
            //        mailMessage.Subject = subject;
            //        mailMessage.Body = html;
            //        mailMessage.IsBodyHtml = true;

            //        smtpClient.Send(mailMessage);
            //    }
            //}


            //SmtpClient smtpClient = new SmtpClient("mail.englishwithfidan.com", 8889);
            //smtpClient.Credentials = new NetworkCredential("postmaster@englishwithfidan.com", "NurlanAztu2003.");
            //smtpClient.EnableSsl = true;

            //MailMessage mail = new MailMessage();
            //mail.From = new MailAddress("postmaster@englishwithfidan.com");
            //mail.To.Add(to);
            //mail.Subject = subject;
            //mail.Body = html;

            //smtpClient.Send(mail);
            string smtpServer = "mail5018.site4now.net";
            int smtpPort = 25;
            string userName = "postmaster@englishwithfidan.com";
            string password = "NurlanAztu2003.";
            bool enableSsl = false;

            string fromEmail = "postmaster@englishwithfidan.com";
            string toEmail = to;
            string a = subject;
            string body = html;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmail);
            mail.To.Add(toEmail);
            mail.Subject = a;
            mail.Body = body;

            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.Credentials = new NetworkCredential(userName, password);
            smtpClient.EnableSsl = enableSsl;

            smtpClient.Send(mail);

            //Console.WriteLine("Email sent successfully.");
        }

    }
}
