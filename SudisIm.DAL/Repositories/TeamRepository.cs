using System.Collections.Generic;
using System.Linq;
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.Model.Models;
using SudisIm.Model.Repositories;

namespace SudisIm.DAL.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ISession session;

        public TeamRepository()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

        public TeamRepository(ISession session)
        {
            this.session = session;
        }

        public Team GetTeamById(long teamId)
        {
            return this.session.Get<Team>(teamId);
        }

        public ICollection<Team> GetTeams()
        {
            return this.session.Query<Team>().ToList();
        }

        public Team AddTeam(Team team)
        {
            this.session.SaveOrUpdate(team);
            this.session.Flush();
            return team;
        }
    }
}