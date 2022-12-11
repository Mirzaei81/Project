using System.ComponentModel.DataAnnotations;
namespace CatlogApi.Dtos
{
    public class DiscountDto
    {
        
        public string  name{get;set;}=string.Empty;
        [Required]
        public int amount{get;set;}
    }
}
