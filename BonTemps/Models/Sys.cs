using BonTemps.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using MimeKit;
using MailKit.Net.Smtp;

namespace BonTemps.Models
{
    public class Sys
    {
        //Credential settings
        public string SmtpAdres;
        public string EmailPass;
        public int EmailPort;
        //Mail settings
        public string CompanyName;
        public string EmailAdres;
        public string Sender;
        public string Onderwerp;
        public string Format;


        public static async Task CheckAccount(ApplicationDbContext _context, UserManager<Klant> _usermanager, SignInManager<Klant> signmanager, string username)
        {
            if (_context.Klanten.Where(x=>x.UserName == username).Count() == 0)
            {
                await signmanager.SignOutAsync();
            }
        }
        public void ConfigureEmailSettings()
        {
            SmtpAdres = "smtp.gmail.com";
            EmailPort = 587;

            CompanyName = "BonTemps";

            EmailAdres = "bontemps538@gmail.com";
            EmailPass = "P@$$w0rd123";


        }
        public void ConfigureFormat(bool UseHtml)
        {
            if (UseHtml)
            {
                Format = "HTML";
            }
            else
            {
                Format = "TEXT";
            }
        }

        public void SendCustomEmail(bool UseHtmlFormat, string Subject , string Message, string EmailReceiver)
        {
            ConfigureEmailSettings();
            ConfigureFormat(UseHtmlFormat);
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(CompanyName, EmailAdres));
            message.To.Add(new MailboxAddress(EmailReceiver, EmailReceiver));
            message.Subject = Subject;
            message.Body = new TextPart(Format)
            {
                Text = message.ToString()
            };
            Email_Send(message);
        }

        public void Email_Send(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect(SmtpAdres, EmailPort, false);
                client.Authenticate(EmailAdres, EmailPass);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void SendConfirmationMail(ApplicationDbContext _context, Reservering reservering, bool UseHtmlFormat)
        {
            ConfigureEmailSettings();
            ConfigureFormat(UseHtmlFormat);
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(CompanyName, EmailAdres));

            string email = reservering.Email;
            string Onderwerp = "Goedkeuring reservering Bontemps.";

            message.To.Add(new MailboxAddress(email, email));

            message.Subject = Onderwerp;

            int klant = _context.Klanten.Where(x => x.Email == reservering.Email).Count();
            if (klant == 0)
            {
                message.Body = new TextPart(Format)
                {
                    Text =
                    "<h1>Goedkeuring reservering</h1>" +
                    "Beste Klant," +
                    "<p>Hierbij willen we u graag informeren dat uw reservering (<b>" + reservering.ReserveringsDatum + "</b> )is goedgekeurd.<br/>" +
                    "Aangezien u de keuze heeft gemaakt om te reserveren zonder account, is dit de laatste mail die u krijgt.<br/>" +
                    "Voor vragen kunt u ons bellen of een email sturen.</br>" +
                    "<br/>" +
                    "Met vriendelijke groet,<br/><br/>" +
                    "BonTemps" +
                    "</p>"
                };
            }
            else
            {
                message.Body = new TextPart(Format)
                {
                    Text =
                    "<h1>Goedkeuring reservering</h1>" +
                    "Beste Klant," +
                    "<p>Hierbij willen we u graag informeren dat uw reservering (<b>" + reservering.ReserveringsDatum + "</b> )is goedgekeurd.<br/>" +
                    "Aangezien u de keuze heeft gemaakt om te reserveren met uw account, Krijgt u een link waar u uw reservering kunt bekijken.<br/>" +
                    "Voor vragen kunt u ons bellen of een email sturen.</br>" +
                    "<br/>" +
                    "Link naar uw reservering : " + "https://localhost:44545/reservering/Reservering <br/><br/>" +
                    "Met vriendelijke groet,<br/><br/>" +
                    "BonTemps" +
                    "</p>"

                };
            }
            Email_Send(message);
        }
    }
}
