using Microsoft.Data.Entity;

namespace Products.Models
{
    public interface IProductsContexts
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
    }
}