using System.ComponentModel.DataAnnotations;
namespace ApiDotNet.Dtos
{
    public record CreateItemDto
    {
        [Required]
        public String? name{get;set;}
        [Required]
        public int Price{get;set;}
    }
}

