using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace emailServer
{
    public class Email
    {
        private MailMessage email;
        private SmtpClient server;

        public Email() {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("walterTest25@gmail.com", "nhqvrkbnuxegnffn");
            //server.Credentials = new NetworkCredential("programationiii@gmail.com", "programacion3");
            server.EnableSsl = true;
            server.Port = 590;
            server.Host = "smtp.gmail.com";
        }

        public void correo(string emailDestino, string asunto , string fecha, string hora)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@clinica.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = "<div style='background:green'><h1 style='color:blue'>Clinica Milagro</h1> </br> <div style='color:black'>wal @ Su turno ha sido registrado con exito, para la fecha '" + fecha + "' '" + hora + "' .</div></div>";
        }

        public void enviar_email()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
