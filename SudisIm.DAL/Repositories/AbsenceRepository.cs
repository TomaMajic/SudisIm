using System.Collections.Generic;
using System.Linq;
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.Model.Models;
using SudisIm.Model.Repositories;

namespace SudisIm.DAL.Repositories
{
    public class AbsenceRepository : IAbsenceRepository
    {

        private readonly ISession session;

        public AbsenceRepository()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

        public AbsenceRepository(ISession session)
        {
            this.session = session;
        }


        public Absence GetAbsenceById(long absenceId)
        {
            return this.session.Get<Absence>(absenceId);
        }

        public ICollection<Absence> GetAbsences()
        {
            return this.session.Query<Absence>().ToList();
        }

        public ICollection<Absence> GetAbsencesForReferee(long refereeId)
        {
            return this.session.Query<Absence>().Where(a => a.Referee.Id == refereeId).ToList();
        }

        public Absence AddAbsence(Absence absence)
        {
            this.session.SaveOrUpdate(absence);
            this.session.Flush();
            return absence;
        }
    }
}