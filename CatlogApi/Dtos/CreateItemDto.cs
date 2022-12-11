using System.ComponentModel.DataAnnotations;
using CatlogApi.Models;

namespace CatlogApi.Dtos
{
    public record CreateItemDto
    {
        [Required]
        public String Name{get;set;} = string.Empty;
        [Required]
        public int Price{get;set;}
        [Required]
        public string  desc{get;set;} = string.Empty;
        [Required]
        public DateTime DateCreated {get;init;}
        [Required]
        public int Stock {get;set;}
        [Required]
        public Category? ItemCategory{get;set;}
    }
}


