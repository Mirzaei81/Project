using Microsoft.EntityFrameworkCore;
using gameapi.Model;
namespace gameapi.context
{
    public class GameContext: DbContext
    {
        public DbSet<games>? games;
        public DbSet<UserGameRate>? UsersRate;
        public GameContext(DbContextOptions<GameContext> options):base(options)
        {
        }
    }
}
