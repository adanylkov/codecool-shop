namespace Codecool.CodecoolShop.Models;

public class PaymentModel
{
    public string CardNumber { get; set; }
    public string UserName { get; set; }
    public string MonthExpiration { get; set; }
    public string YearExpiration { get; set; }
    public string CVV { get; set; }
}
