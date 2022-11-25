using Newtonsoft.Json;
using System.IO;
namespace Codecool.CodecoolShop.Models
{
    public class Order
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Address billing { get; set; }
        public Address shipping { get; set; }
        public void SaveToJson()
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter("orderJson.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this);
            }
        }
    }
}
