using Domain;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Services
{
    public interface IEmailService
    {
        public void SendConfirmationEmail(string emailTo, string name, IEnumerable<KeyValuePair<Product, int>> products);
        public void SendRegistrationEmail(string name, string email, string password);
    }
}
