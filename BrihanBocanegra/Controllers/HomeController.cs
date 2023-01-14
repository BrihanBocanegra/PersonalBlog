using Azure.Identity;
using BrihanBocanegra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using MimeKit;
using System;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Secrets;


namespace BrihanBocanegra.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        // Acción que procesa el formulario
        public async Task<IActionResult> SendMessage(ContactFormModel model)
        {

            if (ModelState.IsValid)
            {
                var MyEmail = "me@brihanbocanegra.com";
                var Password = "******";
                // Procesar los datos del formulario aquí, como enviar un correo electrónico o guardarlos en una base de datos.
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("Contact Form", MyEmail));
                emailMessage.To.Add(new MailboxAddress("Receiver", model.Email));
                //emailMessage.Cc.Add(new MailboxAddress("", MyEmail));
                emailMessage.Subject = "Mensaje desde el formulario de contacto";
                emailMessage.Body = new TextPart("plain") {
                    Text = 
                    "Correo: " + model.Email + Environment.NewLine +
                    "Teléfono: " + model.Phone + Environment.NewLine +
                    "Asunto: " + model.Subject + Environment.NewLine +
                    "Mensaje: " + model.Message
                };
                
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync("smtp.office365.com", 587);
                    await client.AuthenticateAsync(MyEmail, Password);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }


                return RedirectToAction("Index");
            }

            return View(model);
        }
    }

    

}
