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
            Map(g => g.NoOfReferees);
            References(g => g.City);
            References(g => g.MinimalLicence);
            References(g => g.HomeTeam, "HomeTeamId");
            References(g =>g.AwayTeam, "AwayTeamId");
            HasManyToMany(g => g.Referees).Cascade.SaveUpdate();
        }
    }
}
