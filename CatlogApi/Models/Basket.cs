using CatlogApi.Models;
namespace BasketApi.Models
{
    public record Basket 
    {

        public int Id{get;init;}
        public string Address{get;init;} = string.Empty;
        public ICollection<Item>? BasketItem{get;set;}
    }
}
