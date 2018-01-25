using System.Collections.Generic;
using SudisIm.Model.Models;

namespace SudisIm.Model.Repositories
{
    public interface IGameRepository
    {
        Game GetGameById(long gameId);
        ICollection<Game> GetGames();
        Game AddGame(Game game);
    }
}
