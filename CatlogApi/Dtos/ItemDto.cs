namespace CatlogApi.Dtos
{
    public record ItemDto
        {
            public int id{get;init;}
            public string name{get;set;} = string.Empty;
            public DateTime DateCreated{get;init;}
            public int Price{get;set;}
        }
}
