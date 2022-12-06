using System.Collections.Generic;

namespace Domain
{
    public class ProductCategory : BaseModel
    {
        public List<Product> Products { get; set; }
        public string Department { get; set; }
    }
}
