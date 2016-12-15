using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Ng2Net.Model.Security;
using Ng2Net.Model.Scheduler;
using Ng2Net.Model.Admin;
using Ng2Net.Model.Business;

namespace Ng2Net.Data
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<HtmlContent> HtmlContents { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<TaskRunnerLog> TaskRunnerLogs { get; set; }
        public DbSet<ProposalDocument> ProposalDocuments { get; set; }

        public DatabaseContext(): base("name=DefaultConnection")
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

            modelBuilder.Entity<Institution>().HasKey(i=>i.Id).HasMany(i => i.Proposals).WithOptional().HasForeignKey(i => i.InstitutionId);
            modelBuilder.Entity<Proposal>().HasRequired(p => p.Institution);
        }


    }
}