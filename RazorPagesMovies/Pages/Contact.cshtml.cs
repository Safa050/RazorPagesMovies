using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace RazorPagesMovies.Pages
{
    public class ContactModel : PageModel
    {
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            string nombre = Request.Form["first_name"]; //Los comandos Request.QueryString y Request.Form
            //se utilizan para recuperar la entrada del usuario de los formularios.
            string apellido = Request.Form["last_name"];
            string telefono = Request.Form["telephone"];
            string email = Request.Form["email"];
            string mensaje = Request.Form["message"];
            enviarCorreo(nombre, apellido, email, telefono, mensaje);
            return RedirectToPage("./Contact"); //redirige a la pagina de contacto
            }
        public void enviarCorreo(string nombre, string apellido, string email, string telefono, string mensaje)
        {

            string deDireccionOrigen = "safagannoun67@gmail.com"; //habra que configurar nuestro gmail

            MailMessage message = new MailMessage(); //Representa un mensaje de correo electrónico que se
            //puede enviar con la clase SmtpClient.

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential() //le pasamos las credenciales
            {
                UserName = deDireccionOrigen,
                Password = "*****"
            };
            //Especifique si el objeto SmtpClient utiliza SSL (Secure Sockets Layer) para cifrar la conexión.
            smtpClient.EnableSsl = true; //Es true si el objeto SmtpClient utiliza SSL; en caso contrario, es false.
            //De manera predeterminada, es false.
            message.From = new MailAddress(deDireccionOrigen);
            message.To.Add(new MailAddress(deDireccionOrigen));
            message.Subject = nombre + "-" + apellido + " - Telefono: " + telefono;
            message.IsBodyHtml = true;
            message.Body = mensaje;

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network; //Especifica la forma en que se controlarán
            //los mensajes de correo electrónico salientes.
            smtpClient.Send(message);

}
    }
}
