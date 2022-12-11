namespace CatlogApi.Models
{   
    public partial record Category
    {
        public int Id{get;set;}
        public string name{get;set;}=string.Empty;
        public string desc{get;set;} = string.Empty;
        public DateTime DateCreaeted{get;init;}

    }
}
