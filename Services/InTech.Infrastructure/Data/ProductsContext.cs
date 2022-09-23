using Microsoft.EntityFrameworkCore;
using InTech.Core.Entities;

namespace InTech.Infrastructure.Data
{
    public class ProductsContext : DbContext
    {

        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
