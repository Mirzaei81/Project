namespace CatlogApi.Models
{
    public record Discount
   {
        public int Id{get;set;}
        public string  name{get;set;}=string.Empty;
        public int amount{get;set;}
    }
}

