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
            //server.Credentials = new NetworkCredential("walterdiaz9418@gmail.com", "cstkyahnvmwbdnkc");
            //server.Credentials = new NetworkCredential("programationiii@gmail.com", "programacion3");
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
            email.Body = "<div style='background: rgba(0,212,255,1); padding:20px;'><h1 style='color:white'>Clinica Milagro</h1></br><p style='color:black'>Su turno ha sido registrado con exito, para la fecha " + fecha + " a las " + hora + " .</p><p> Desde Clinica Milagro le deseamos un buen dia.</p><p> Saludos cordiales.</p></div>";
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
