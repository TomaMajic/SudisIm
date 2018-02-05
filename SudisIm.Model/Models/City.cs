namespace SudisIm.Model.Models
{
    public class City
    {

        public City()
        {}
        public City(string name, int postalCode)
        {
            this.Name = name;
            this.PostalCode = postalCode;
        }

        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int PostalCode { get; set; }
    }
}
