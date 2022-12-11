using Microsoft.EntityFrameworkCore;
using CatlogApi.Models;

namespace CatlogApi.Repository
{
    public interface IItemRepository
    {
        Task<Item> GetItem(int id);
        Task<IEnumerable<Item>> GetItems();
        Task CreateItem (Item item);
        Task UpdateItem (Item item);
        Task DeleteItem (Item TargetItem);
    }
                                                                                    
    public class ItemRepository: IItemRepository
    {
        protected ItemContext item;

        public ItemRepository(ItemContext itemContext)
        {
            this.item = itemContext;
        }
      
      
        public async Task<IEnumerable<Item>> GetItems()
        {
            return await this.item.Items.ToListAsync()  ;

        }
                                                                                    
        public async Task<Item> GetItem(int Id)
        {
            var FoundedItem = await this.item.Set<Item>().FindAsync(Id) ?? throw new NullReferenceException(nameof(Id)); 
            this.item.Entry(FoundedItem).State = EntityState.Detached;
            return FoundedItem;
        }                                                                           

        public async Task CreateItem(Item item)
        {
            await this.item.Items.AddAsync(item);
            await this.item.SaveChangesAsync();
        }
       
        public async Task UpdateItem(Item item)
        {
            var itemEntry = this.item.Entry(item);
            itemEntry.State = EntityState.Modified;
            await this.item.SaveChangesAsync();
        }
                                                                                    
        public Task DeleteItem(Item TargetItem)
        {
            this.item.Items.Remove(TargetItem);
            return this.item.SaveChangesAsync();
        }
        
    }
}
