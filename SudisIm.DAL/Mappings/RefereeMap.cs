using FluentNHibernate.Mapping;
using SudisIm.Model.Models;

namespace SudisIm.DAL.Mappings
{
    public class RefereeMap : ClassMap<Referee>
    {
        public RefereeMap()
        {
            Id(r => r.Id).GeneratedBy.Native();
            Map(r => r.FirstName);
            Map(r => r.LastName);
            Map(r => r.IsDeleted);
            Map(r => r.Address);
            Map(r => r.Description);
            Map(r => r.Contact);
            References(r => r.City);
            References(r => r.Licence);
            References(r => r.User);
            HasMany(r => r.Absences).Inverse();
        }
    }
}
