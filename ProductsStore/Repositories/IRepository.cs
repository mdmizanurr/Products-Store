using ProductsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsStore.Repositories
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }

        Product GetProduct(long key);

        void AddProduct(Product product);

        void UpdateProduct(Product product);
    }
}
