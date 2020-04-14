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
    
        public void UpdateAll(Product[] products)
        {
            //context.Products.UpdateRange(products);

            Dictionary<long, Product> data = products.ToDictionary(p => p.Id);
            IEnumerable<Product> baseline = context.Products.Where(p => data.Keys.Contains(p.Id));

            foreach (Product databaseProduct in baseline)
            {
                Product requestProduct = data[databaseProduct.Id];
                databaseProduct.Name = requestProduct.Name;
                databaseProduct.Category = requestProduct.Category;
                databaseProduct.PurchasePrice = requestProduct.PurchasePrice;
                databaseProduct.RetailPrice = requestProduct.RetailPrice;

            }

            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
