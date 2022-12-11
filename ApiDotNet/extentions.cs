using ApiDotNet.Dtos;
using ApiDotNet.Models;
namespace ApiDotNet
{
    public static class Extentions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                id = item.ID,
                name = item.name,
                Price = item.Price,
                DateCreated= item.DateCreated,
            };
        }
    }
}
