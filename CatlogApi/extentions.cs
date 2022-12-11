using CatlogApi.Dtos;
using CatlogApi.Models;

namespace CatlogApi
{
    public static class Extentions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                id = item.Id,
                name = item.Name,
                Price = item.Price,
                DateCreated= item.DateCreated,
            };
        }

        public static DiscountDto AsDiscountDto(this Discount discount)
        {
            return new DiscountDto
            {
                name = discount.name,
            };
        }
    }
}

