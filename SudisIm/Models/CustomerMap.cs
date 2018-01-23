using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace SudisIm.Models
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(c => c.CustomerId);
            Map(c => c.FirstName);
            Map(c => c.LastName);
        }
    }
}