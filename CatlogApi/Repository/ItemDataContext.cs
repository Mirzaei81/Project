using CatlogApi.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiDotNet.Repository
{
    public class ItemDataContext : DbContext
    {
        public ItemDataContext(DbContextOptions<ItemDataContext> options): base(options)
        {

        }

        public DbSet<Item>? Items {get;set;}
        public DbSet<Discount>?  discount{get;set;}
        public DbSet<Category>? Category{get;set;}
    }
}
