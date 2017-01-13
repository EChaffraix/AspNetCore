using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SoaWebsite.Web.Models
{
    public class DeveloperContext : DbContext
    {
        public DeveloperContext(DbContextOptions<DeveloperContext> options)
            : base(options)
        { }

        public DbSet<Developer> Developers { get; set; }
    }

    public class Developer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}