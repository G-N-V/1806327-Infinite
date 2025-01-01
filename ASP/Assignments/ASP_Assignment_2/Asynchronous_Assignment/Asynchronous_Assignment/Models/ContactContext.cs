using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Asynchronous_Assignment.Models
{
    public class ContactContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}