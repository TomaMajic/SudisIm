namespace SudisIm.Model.Models
{
    public class Referee
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public long LicenceId { get; set; }
        // TODO: Dodaj ref na city i licence
    }
}
