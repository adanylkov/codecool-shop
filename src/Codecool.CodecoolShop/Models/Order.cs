namespace Codecool.CodecoolShop.Models
{
    public class Order
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Address billing { get; set; }
        public Address shipping { get; set; }
    }
}
