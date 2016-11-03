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
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
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

            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Claims).WithOptional().HasForeignKey(u => u.UserId);
            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Roles).WithRequired().HasForeignKey(r => r.UserId);
            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Logins).WithMany().Map(cs => { cs.MapLeftKey("Id"); cs.MapRightKey("UserId"); });
            modelBuilder.Entity<IdentityRole>().HasMany(u => u.Users).WithOptional().HasForeignKey(l => l.RoleId);

            modelBuilder.Entity<Proposal>().HasRequired(t => t.Institution).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Proposal>().HasRequired(t => t.InitiatingInstitution).WithMany().WillCascadeOnDelete(false);

        }


    }
}