using ApiDotNet.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiDotNet.Repository
{
    public class ItemDataContext : DbContext
    {
        public ItemDataContext(DbContextOptions<ItemDataContext> options): base(options)
        {

        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.UseSerialColumns();

            }

        public DbSet<Item> Items {get;set;}
    }
}
