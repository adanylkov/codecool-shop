using Microsoft.Build.Framework;

namespace Codecool.CodecoolShop.Models;

public class PaymentModel
{
    [Required]
    public string CardNumber { get; set; }
    [Required]
    public string CardHolder { get; set; }
    [Required]
    public string MonthExpiration { get; set; }
    [Required]
    public string YearExpiration { get; set; }
    [Required]
    public string CVV { get; set; }
}
