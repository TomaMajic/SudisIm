using FluentNHibernate.Mapping;
using SudisIm.Model.Models;

namespace SudisIm.DAL.Mappings
{
    public class LicenceMap : ClassMap<Licence>
    {
        public LicenceMap()
        {
            Id(c => c.Id).GeneratedBy.Native();
            Map(c => c.Name);
            Map(c => c.Priority);
        }
    }
}
