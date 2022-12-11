namespace ApiDotNet.Models
{
    public record Item
    {
        public int Id{get;init;}
        public string name{get;set;} = string.Empty;
        public DateTime DateCreated{get;init;}
        public int Price{get;set;}
    }
}
    

