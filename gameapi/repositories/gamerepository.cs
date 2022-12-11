using gameapi.context;
using gameapi.Model;
using  gameapi.dtos;
using Microsoft.EntityFrameworkCore;
namespace gameapi.repository
{
    public class gameRepsitory
    {
        private readonly GameContext? _context;
        public gameRepsitory(GameContext context)
        {
            _context = context;
        }

        public async Task<games> getGames(int id)
        {
            return (await _context.games!.FindAsync(id)) ?? throw new NullReferenceException();
        }

        public async Task<games> RateGame(int gameid,int userid,int rate)
        {
             games game = (await _context.games!.FindAsync(gameid)) ?? throw new NullReferenceException();
             game.rating +=rate;
             UserGameRate gameRate = new()
                {   
                    UserId = userid,
                    GameId = gameid,
                    Rate = rate
                };
             await _context.UsersRate!.AddAsync(gameRate);
             await _context.SaveChangesAsync();

             return game;
        }

//        public async Task<List<games>> GameByUserId(int id)
//        {
//            List<GameRate> gameIds = _context.UsersRate.Where(U => U.UserId == id)
//                                                        .Select(G => new 
//                                                                GameRate { 
//                                                                gameId =G.GameId,
//                                                                Rate = G.Rate
//                                                                })
//                                                                 .ToList();
//            var games = _context.games.Where(game => gameIds.gameId.Contains(game.id)
//
//
//        }
    }
}
