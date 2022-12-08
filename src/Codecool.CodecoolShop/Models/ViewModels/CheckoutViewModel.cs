using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models.ViewModels
{
    public class CheckoutViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Country")]
        public string YourCountry { get; set; }
        [Required]
        [DisplayName("City")]
        public string YourCity { get; set; }
        [Required]
        [DisplayName("Zipcode")]
        public string YourZipcode { get; set; }
        [Required]
        [DisplayName("Address")]
        public string YourAdress { get; set; }
        [Required]
        [DisplayName("Country")]
        public string ShippingCountry { get; set; }
        [Required]
        [DisplayName("City")]
        public string ShippingCity { get; set; }
        [Required]
        [DisplayName("Zipcode")]
        public string ShippingZipcode { get; set; }
        [Required]
        [DisplayName("Address")]
        public string ShippingAdress { get; set; }
    }
}
