namespace SudisIm.Model.Models
{
    public class Team
    {
        public Team()
        {}

        public Team(string name, City city)
        {
            this.Name = name;
            this.City = city;
        }

        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual City City { get; set; }
    }
}
