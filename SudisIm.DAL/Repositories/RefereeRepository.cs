using System;
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

        public IQueryable<Referee> GetReferees()
        {
            return this.session.Query<Referee>();
        }
        
        public Referee AddReferee(Referee referee)
        {
            session.SaveOrUpdate(referee);
            session.Flush();
            return referee;
        }

        public Referee GetRefereeByUser(string username)
        {

            var referee = this.GetReferees().FirstOrDefault(r => r.User.UserName == username);

            if (referee == null)
                throw new Exception("User does not have defined referee");

            return referee;
        }
    }
}