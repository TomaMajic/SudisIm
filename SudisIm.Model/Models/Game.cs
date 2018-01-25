using System;
using System.Collections.Generic;

namespace SudisIm.Model.Models
{
    public class Game
    {
        public Game()
        {
            this.Referees = new List<Referee>();
        }
        public virtual long Id { get; set; }
        //public virtual long HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }
        //public virtual long AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual ICollection<Referee> Referees { get; set; }
        public virtual string Address { get; set; }
        //public virtual long CityId { get; set; }

        public virtual City City { get; set; }

    }
}
