using FluentNHibernate.Mapping;
using SudisIm.Model.Models;

namespace SudisIm.DAL.Mappings
{
    public class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Id(c => c.Id).GeneratedBy.Native();
            Map(c => c.Name);
        }
    }
}
