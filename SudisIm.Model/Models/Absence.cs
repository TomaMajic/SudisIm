using System;

namespace SudisIm.Model.Models
{
    public class Absence
    {
        public virtual long Id { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string Excuse { get; set; }
        public virtual Referee Referee { get; set; }
    }
}
