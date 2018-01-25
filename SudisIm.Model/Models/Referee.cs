namespace SudisIm.Model.Models
{
    public class Referee
    {
        public virtual long Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Address { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual string Description { get; set; }
        public virtual Licence Licence { get; set; }
       
        public virtual City City { get; set; }
        // TODO: Dodaj ref na    licence
    }
}
