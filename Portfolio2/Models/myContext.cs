using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class myContext: DbContext
    {
        public myContext()
        {

        }
        public myContext(DbContextOptions<myContext> options) : base(options)
        { }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }


}
