namespace Codecool.CodecoolShop.Models;

public class PaymentModel
{
    public string CardNumber { get; set; }
    public string UserName { get; set; }
    public int MonthExpiration { get; set; }
    public int YearExpiration { get; set; }
    public int CVV { get; set; }
}
