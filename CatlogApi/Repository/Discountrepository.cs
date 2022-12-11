using CatlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CatlogApi.Repository
{    
    public interface IDiscountRepository
    {
        Task<Discount> GetDiscount(int id);
        Task<IEnumerable<Discount>> GetDiscounts();
        Task CreateDiscount (Discount item);
        Task UpdateDiscount (Discount item);
        Task DeleteDiscount (Discount TargetItem);
    }

    public class DiscountRepository:IDiscountRepository
    {
        private readonly ItemContext _context;

        public DiscountRepository(ItemContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Discount>> GetDiscounts()
        {
            return (await this._context.discount.ToListAsync()) ?? throw new NullReferenceException("NoList")  ;

        }

        public async Task<Discount> GetDiscount(int Id)
        {
            var FoundedItem = (await _context.Set<Discount>().FindAsync(Id)) ?? throw new NullReferenceException(nameof(Id)); 
            _context.Entry(FoundedItem).State = EntityState.Detached;
            return FoundedItem;
        }                                                                           

        public async Task CreateDiscount(Discount discount)
        {
            await _context.discount.AddAsync(discount);
            await _context.SaveChangesAsync();
        }
       
        public async Task UpdateDiscount(Discount item)
        {
            var itemEntry = _context.Entry(item);
            itemEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
                                                                                    
        public Task DeleteDiscount(Discount TargetItem)
        {
            _context.discount.Remove(TargetItem);
            return _context.SaveChangesAsync();
        }
 

    }
}

