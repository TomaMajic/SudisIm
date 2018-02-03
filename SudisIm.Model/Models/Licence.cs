namespace SudisIm.Model.Models
{
   public  class Licence
    {
        public Licence()
        {}

        public Licence(string name, int priority)
        {
            this.Name = name;
            this.Priority = priority;
        }

        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Priority { get; set; }
    }
}
