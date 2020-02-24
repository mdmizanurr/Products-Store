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

        private readonly ProductDataContext context;
        
        public DataRepository(ProductDataContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Product> Products => context.Products.ToList();

        public void AddProduct(Product product)
        {   
            this.context.Add(product);
            this.context.SaveChanges();
        }

        public Product GetProduct(long key)
        {
             return context.Products.Find(key);

        }

        public void UpdateProduct(Product product)
        {
            Product p = GetProduct(product.Id);
            p.Name = product.Name;
            p.Category = product.Category;
            p.PurchasePrice = product.PurchasePrice;
            p.RetailPrice = product.RetailPrice;
           // context.Products.Update(product);
            context.SaveChanges();
        }
    }
}
