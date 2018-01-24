using System.Collections.Generic;
using System.Linq;
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.Model.Models;
using SudisIm.Model.Repositories;

namespace SudisIm.DAL.Repositories
{
    public class RefereeRepository : IRefereeRepository
    {
        private readonly ISession session;

        public RefereeRepository()
            :this(NHibernateHelper.Instance.OpenSession())
        {}

        public RefereeRepository(ISession session)
        {
            this.session = session;
        }

        public Referee GetRefereeById(long refereeId)
        {
            return this.session.Get<Referee>(refereeId);
        }

        public ICollection<Referee> GetReferees()
        {
            return this.session.Query<Referee>().ToList();
        }

        public Referee AddReferee(Referee referee)
        {
            session.SaveOrUpdate(referee);

            return referee;
        }
    }
}