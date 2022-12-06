using Domain;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Services
{
    public interface IEmailService
    {
        public void SendConfirmationEmail(string emailTo, string name, IEnumerable<KeyValuePair<Product, int>> products);
    }
}
