using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models;

public class PaymentModel
{
    [Required]
    [DisplayName("Card number")]
    public string CardNumber { get; set; }
    [Required]
    [DisplayName("Card holder name")]
    public string CardHolder { get; set; }
    [Required]
    [DisplayName("Month expiration")]
    public string MonthExpiration { get; set; }
    [Required]
    [DisplayName("Year expiration")]
    public string YearExpiration { get; set; }
    [Required]
    [DisplayName("Cvv code")]
    public string CVV { get; set; }
}
