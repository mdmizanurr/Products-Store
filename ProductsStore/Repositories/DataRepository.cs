using ProductsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsStore.Repositories
{
    public class DataRepository : IRepository
    {
        // private List<Product> data = new List<Product>();

        private ProductDataContext context;

        public DataRepository(ProductDataContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Product> Products => context.Products;

        public void AddProduct(Product product)
        {
            this.context.Add(product);
            this.context.SaveChanges();
        }
    }
}
