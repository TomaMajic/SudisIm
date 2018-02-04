using System.Collections.Generic;

namespace SudisIm.Model.Models
{
    public class Referee
    {
        public Referee()
        {}

        public Referee(string firstName, string lastName, Licence licence)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Licence = licence;
        }

        public virtual long Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Address { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual string Description { get; set; }
        public virtual string Contact { get; set; }
        public virtual Licence Licence { get; set; }
       
        public virtual City City { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Absence> Absences { get; set; }
    }
}
