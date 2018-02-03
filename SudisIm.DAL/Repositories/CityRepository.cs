using System.Collections.Generic;
using System.Linq;
using NHibernate;
using SudisIm.DAL.NHibernate;
using SudisIm.Model.Models;
using SudisIm.Model.Repositories;

namespace SudisIm.DAL.Repositories
{
    public class CityRepository : ICityRepository
    {

        private readonly ISession session;

        public CityRepository()
            : this(NHibernateHelper.Instance.OpenSession())
        { }

        public CityRepository(ISession session)
        {
            this.session = session;
        }

        public ICollection<City> GetCities()
        {
            return this.session.Query<City>().ToList();
        }

        public City AddCity(City city)
        {
            this.session.SaveOrUpdate(city);
            this.session.Flush();
            return city;
        }
    }
}