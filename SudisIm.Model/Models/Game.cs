using System;
using System.Collections.Generic;

namespace SudisIm.Model.Models
{
    public class Game
    {
        public long Id { get; set; }
        public long HomeTeamId { get; set; }
        public long AwayTeamId { get; set; }
        public DateTime StartTime { get; set; }
        public ICollection<Referee> Referees { get; set; }
        public string Address { get; set; }
        public long CityId { get; set; }

        // TODO: navigacijski propertyi za timove i city

    }
}
