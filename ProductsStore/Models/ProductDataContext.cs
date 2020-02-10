using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsStore.Models
{
    public class ProductDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }


        public ProductDataContext(DbContextOptions<ProductDataContext> opts) 
            : base(opts)  { }

    }
}
