using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCCrudOps.Models
{
    public class MoviesDBContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}