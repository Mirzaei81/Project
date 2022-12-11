using CatlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CatlogApi.Repository
{
    public interface ICategoryRepository
        {
            Task<Category> GetDiscount(int id);
            Task<IEnumerable<Category>> GetDiscounts();
            Task CreateCategory (Discount item);
            Task UpdateCategory (Discount item);
            Task DeleteCategory (Discount TargetItem);
        }

    public class CategoryRepository:ICategoryRepository
        {
            private readonly ItemContext _context;

            public CategoryRepository(ItemContext context)
            {
                this._context = context;
            }

            public async Task<IEnumerable<Category>> GetDiscounts()
            {
                return (await this._context.category.ToListAsync()) ?? throw new NullReferenceException("NoList")  ;

            }

            public async Task<Category> GetDiscount(int Id)
            {
                var FoundedItem = (await _context.Set<Category>().FindAsync(Id)) ?? throw new NullReferenceException(nameof(Id)); 
                _context.Entry(FoundedItem).State = EntityState.Detached;
                return FoundedItem;
            }                                                                           

            public async Task CreateCategory(Discount discount)
            {
                await _context.discount.AddAsync(discount);
                await _context.SaveChangesAsync();
            }
           
            public async Task UpdateCategory(Discount item)
            {
                var itemEntry = _context.Entry(item);
                itemEntry.State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
                                                                                        
            public Task DeleteCategory(Discount TargetItem)
            {
                _context.discount.Remove(TargetItem);
                return _context.SaveChangesAsync();
            }

    }
}
