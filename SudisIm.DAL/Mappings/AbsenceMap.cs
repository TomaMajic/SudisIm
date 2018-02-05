using FluentNHibernate.Mapping;
using SudisIm.Model.Models;

namespace SudisIm.DAL.Mappings
{
    public class AbsenceMap : ClassMap<Absence>
    {
        public AbsenceMap()
        {
            Id(c => c.Id).GeneratedBy.Native();
            Map(c => c.Excuse);
            Map(c => c.StartDate);
            Map(c => c.EndDate);
            References(c => c.Referee);
        }
    }
}
