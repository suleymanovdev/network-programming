using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SMTP_MAIL
{
    internal class Program
    {
        static void SMTP()
        {
            var client = new SmtpClient("your mail smtp", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(
                    "your email",
                    "your password"
                );
            var message = new MailMessage
            {
                Body = "your text",
                Subject = "your text"
            };             
            message.From = new MailAddress("your email", "your name");
            message.To.Add(new MailAddress("sending email"));
            client.Send(message);
        }         

        static void Main(string[] args)
        {
            SMTP();
        }
    }
}
