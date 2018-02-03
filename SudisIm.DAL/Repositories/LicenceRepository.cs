using System.Collections.Generic;
using System.Linq;
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.Model.Models;
using SudisIm.Model.Repositories;

namespace SudisIm.DAL.Repositories
{
    public class LicenceRepository : ILicenceRepository
    {

        private readonly ISession session;

        public LicenceRepository()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

        public LicenceRepository(ISession session)
        {
            this.session = session;
        }

        public Licence GetLicenceById(long licenceId)
        {
            return this.session.Get<Licence>(licenceId);
        }

        public ICollection<Licence> GetLicences()
        {
            return this.session.Query<Licence>().ToList();
        }

        public Licence AddLicence(Licence licence)
        {
            this.session.SaveOrUpdate(licence);
            this.session.Flush();
            return licence;
        }
    }
}