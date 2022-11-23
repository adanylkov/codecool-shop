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

        public void Decrease(Product product1, int v)
        {
            var currentQuanity = productIdQuanity.GetValueOrDefault(product1.Id, 0);
            productIdQuanity[product1.Id] = currentQuanity - v;
            if (productIdQuanity[product1.Id] <= 0)
                Remove(product1);
        }

        public IEnumerable<KeyValuePair<int, int>> GetAll()
        {
            return productIdQuanity.ToArray();
        }

        public void Increase(Product product1, int v)
        {
            var currentQuanity = productIdQuanity.GetValueOrDefault(product1.Id, 0);
            productIdQuanity[product1.Id] = currentQuanity + v;
        }

        public void Remove(int productId)
        {
            productIdQuanity.Remove(productId);
        }
    }
}