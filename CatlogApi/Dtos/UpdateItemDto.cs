using System.ComponentModel.DataAnnotations;
using CatlogApi.Models;
namespace CatlogApi.Dtos
{
    public record UpdateItemDto
    {
        [Required]
        public String? name{get;set;}
        [Required]
        public int Price{get;set;}
        public Category? ItemCategory{get;set;}
        public Discount? ItemDiscount{get;set;} 
    }
}


