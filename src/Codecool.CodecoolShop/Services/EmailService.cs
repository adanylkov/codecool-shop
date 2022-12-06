using Domain;
using System.Collections.Generic;
using System.Text;
using System;
using Serilog;

namespace Codecool.CodecoolShop.Services
{
    public class EmailService : IEmailService
    {
        public void SendConfirmationEmail(string emailTo, string name, IEnumerable<KeyValuePair<Product, int>> products)
        {
            var emailBody = new StringBuilder();
            emailBody.AppendLine($"Hello, {name}");
            emailBody.AppendLine("Order details:");
            var total = 0M;
            foreach (var item in products)
            {
                var product = item.Key;
                total += product.DefaultPrice * item.Value;
                emailBody.AppendLine($"{product.Name} x{item.Value} = {product.DefaultPrice * item.Value}$");
            }
            emailBody.AppendLine(new string('-', 20));
            emailBody.AppendLine($"Total: {total}$");

            var email = new Email(emailTo, "Your order confirmation", emailBody.ToString());
            email.Send();
        }
        public void SendRegistrationEmail(string name, string email, string password)
        {
            try
            {
                Log.Information("Trying to send registration email");
                var emailBody = new StringBuilder();
                emailBody.AppendLine($"Hello, {name}!");
                emailBody.AppendLine($"You're username is {name} and password is {password}");

                var yourEmail = new Email(email, "Your Registration confirmation", emailBody.ToString());
                yourEmail.Send();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in sending registration email!");
            }
        }
    }
}
