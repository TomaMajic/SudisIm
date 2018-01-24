using FluentNHibernate.Mapping;
using SudisIm.Model.Models;

namespace SudisIm.DAL.Mappings
{
    public class ApplicationUserMap : ClassMap<ApplicationUser>
    {
        public ApplicationUserMap()
        {
            Table("AspNetUsers2");
            Id(u => u.Id);
            Map(u => u.IsSystemAdmin);
        }
       
    }
}
