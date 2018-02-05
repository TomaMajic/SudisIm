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
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual ICollection<Referee> Referees { get; set; }
        public virtual string Address { get; set; }
        public virtual Licence MinimalLicence { get; set; }
        public virtual int NoOfReferees { get; set; }
        public virtual City City { get; set; }

        public virtual int GetRefereeCount()
        {
            return this.Referees.Count;
        }

        public virtual string GetFormatedStartTime()
        {
            return $"{this.StartTime:dddd, MM.dd.yyyy}";
        }

        public virtual string GetGameTitle()
        {
            return $"{this.HomeTeam.Name} vs {this.AwayTeam.Name}";
        }

        public virtual string GetLocation()
        {
            return $"{this.Address}, {this.City.Name}";
        }
    }
}
