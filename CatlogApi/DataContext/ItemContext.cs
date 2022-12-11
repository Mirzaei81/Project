using CatlogApi.Models;
using Microsoft.EntityFrameworkCore;
namespace CatlogApi.DataContext
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) :base(options)
        {
        }
        
        public DbSet<Item>? Items{get;set;}
        public DbSet<Category>? category{get;set;}
        public DbSet<Discount>? discount{get;set;}
    }
     
}

