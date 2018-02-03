using System.Collections.Generic;
using SudisIm.Model.Models;

namespace SudisIm.Model.Repositories
{
    public interface ICityRepository
    {
        ICollection<City> GetCities();
        City AddCity(City city);
    }
}
