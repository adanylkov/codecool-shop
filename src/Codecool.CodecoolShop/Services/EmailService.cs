using Codecool.CodecoolShop.Models;
using System.Collections.Generic;
using System.Text;

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
    }
}
