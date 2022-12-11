using System.ComponentModel.DataAnnotations.Schema;
namespace CatlogApi.Models
{
    public partial record Item
    {
        public int Id {get;init;}
        public string Name {get;init;} = string.Empty;
        public int Price {get;init;}
        public DateTime DateCreated {get;init;}
        public string  image_Url {get;set;} = string.Empty;
        public string  desc{get;set;} = string.Empty;
        public int Stock {get;set;}

        [Column(TypeName = "decimal(5, 2)")]
        public decimal ratio{get;set;}

        public Category? ItemCategory{get;set;}
        public Discount? ItemDiscount{get;set;} 

    }
}
