namespace gameapi.Model
{
    public class UserGameRate
    {
        public int UserId{get;set;}
        public int GameId{get;set;}
        public int Rate{get;set;}
    }

    public class Genres
    {   
        public int id { get; set; }
        public string name { get; set; }= string.Empty;
        public string slug { get; set; }= string.Empty;
        public int games_count { get; set; }
        public ICollection<games> games{get;set;} = new List<games>();
    }

    public class Platforms
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string slug { get; set; }= string.Empty;
        public ICollection<games> gamesplatforms{get;set;} = new List<games>();

    }


    public class games
    {
        public int id { get; set; }
        public string name { get; set; }= string.Empty;
        public string released { get; set; }= string.Empty;
        public string background_image { get; set; }= string.Empty;
        public double rating { get; set; } = 0;
        public int ratings_count { get; set; }
        public int added { get; set; }
        public int? metacritic { get; set; } = 0;
        public ICollection<Platforms>  platforms{ get; set; } = new List<Platforms>();
        public ICollection<Genres> genres { get; set; } = new List<Genres>();
        public ICollection<Tags> tags { get; set; } = new List<Tags>();

    }

    public class Tags
    {   
        public int id { get; set; }
        public string name { get; set; }= string.Empty;
        public string slug { get; set; }= string.Empty;
        public int games_count { get; set; }
        public ICollection<games> games{get;set;} = new List<games>();

    }

}
