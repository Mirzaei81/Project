using ApiDotNet.Models;

namespace ApiDotNet.Repository
{
    public interface IItemRepository
    {
        Item? GetItem(int id);
        Task<List<Item>>? GetItems();
        void CreateItem (Item item);
        void UpdateItem (Item item);
        void DeleteItem (int id);
    }

    public class ItemRepositories : IItemRepository
    {
        private readonly ItemDataContext items;

        public ItemRepositories(ItemDataContext itemDataContext)
        {
            this.items = itemDataContext;
        }
      
        public async Task<List<Item>>? GetItems()
        {
            return await items.Items.To();
        }

        public Item? GetItem(int Id)
        {
            return items.FindAsync(Id);
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }
        
        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.ID== item.ID);
            items[index] = item;
        }

        public void DeleteItem(int id)
        {
            var index = items.FindIndex(existingItem => existingItem.ID== id);
            items.RemoveAt(index);
        }


    };

}

