using System.Collections.Generic;
using SudisIm.Model.Models;

namespace SudisIm.Model.Repositories
{
    public interface ICityRepository
    {
        City GetCityById(long cityId);
        ICollection<City> GetCities();
        City AddCity(City city);
    }
}
