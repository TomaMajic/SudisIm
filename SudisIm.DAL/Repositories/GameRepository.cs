using System.Collections.Generic;
using System.Linq;
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.Model.Models;
using SudisIm.Model.Repositories;

namespace SudisIm.DAL.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ISession session;

        public GameRepository()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

        public GameRepository(ISession session)
        {
            this.session = session;
        }


        public Game GetGameById(long gameId)
        {

            return this.session.Get<Game>(gameId);
        }

        public ICollection<Game> GetGames()
        {
            return this.session.Query<Game>().ToList();
        }

        public Game AddGame(Game game)
        {
            session.SaveOrUpdate(game);
            session.Flush();
            return game;
        }
    }
}