using System.ComponentModel.DataAnnotations;
namespace CatlogApi.Dtos
{
    public class CatagroyDto
    {
        [Required]
        public string name{get;set;}=string.Empty;
        [Required]
        public string desc{get;set;} = string.Empty;
        [Required]
        public DateTime DateCreaeted{get;init;}
    }
}


