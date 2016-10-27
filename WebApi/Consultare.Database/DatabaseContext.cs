using Consultare.Database.DatabaseEntities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultare.Database
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Ministery> Ministeries { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Institution> Institutions { get; set; }

        public DatabaseContext(): base("Name=DatabaseContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }


    }
}