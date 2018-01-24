namespace SudisIm.Model.Models
{
    public class Team
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual long CityId { get; set;}
        public virtual City City { get; set; }
    }
}
