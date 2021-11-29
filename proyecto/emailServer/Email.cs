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
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void correo(string emailDestino, string asunto , string fecha, string hora)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@clinica.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = "<div style='background:blue; padding:20px; border:6px solid rgb(77, 112, 206 );border-radius:15px;'><h1 style='color:white'>Clinica Milagro</h1> </br> <div style='color:white'>Su turno ha sido registrado con exito, para la fecha <strong style='color: black'> " + fecha + " a las " + hora + "</strong>.</div> <div style='color:white'>Desde Clinica Milagro le deseamos que tenga un buen dia.</div><div style='color:white'>Saludos Cordiales.</div></div>";
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
