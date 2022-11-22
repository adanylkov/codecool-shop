using System;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Models
{
    public class Cart
    {
        private readonly Dictionary<int, int> productIdQuanity = new();
        public void Add(Product product)
        {
            var quanity = productIdQuanity.GetValueOrDefault(product.Id, 0);
            productIdQuanity[product.Id] = quanity + 1;
        }
        public IEnumerable<KeyValuePair<int, int>> GetAll()
        {
            return productIdQuanity.ToArray();
        }
    }
}