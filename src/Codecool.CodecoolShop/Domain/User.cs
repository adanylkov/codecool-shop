using Microsoft.AspNetCore.Identity;

namespace Codecool.CodecoolShop.Domain
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Password { get; set; }

    }
}
