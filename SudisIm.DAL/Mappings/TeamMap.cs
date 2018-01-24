using FluentNHibernate.Mapping;
using SudisIm.Model.Models;

namespace SudisIm.DAL.Mappings
{
    public class TeamMap : ClassMap<Team>
    {
        public TeamMap()
        {

            Id(c => c.Id).GeneratedBy.Native();
            Map(c => c.Name);
            References(t => t.City);
        }
    }
}
