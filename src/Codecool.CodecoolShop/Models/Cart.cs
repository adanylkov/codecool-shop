﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Models
{
    public class Cart
    {
        public readonly Dictionary<int, int> productIdQuanity = new();
        public void Add(Product product)
        {
            var quanity = productIdQuanity.GetValueOrDefault(product.Id, 0);
            productIdQuanity[product.Id] = quanity + 1;
        }

        public void SetQuanity(int productId, int v)
        {
            productIdQuanity[productId] = v;
            if (productIdQuanity[productId] <= 0)
                Remove(productId);
        }

        public IEnumerable<KeyValuePair<int, int>> GetAll()
        {
            return productIdQuanity.ToArray();
        }

        public void Remove(int productId)
        {
            productIdQuanity.Remove(productId);
        }
    }
}