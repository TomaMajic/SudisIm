using FluentNHibernate.Mapping;
using SudisIm.Model.Models;

namespace SudisIm.DAL.Mappings
{
    public class GameMap : ClassMap<Game>
    {
        public GameMap()
        {
            Id(g => g.Id).GeneratedBy.Native();
            Map(g => g.Address);
            Map(g => g.StartTime);
            References(g => g.City);
            References(g => g.HomeTeam, "HomeTeamId");
            References(g =>g.AwayTeam, "AwayTeamId");
            HasManyToMany(g => g.Referees).Cascade.SaveUpdate();
        }
    }
}
