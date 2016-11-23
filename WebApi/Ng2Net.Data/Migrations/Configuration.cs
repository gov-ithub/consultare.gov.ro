namespace Ng2Net.Data.Migrations
{    
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Security;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Claims;
    public sealed class Configuration : DbMigrationsConfiguration<Ng2Net.Data.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Ng2Net.Data.DatabaseContext context)
        {

            if (context.Roles.Count() > 0)
                return;
            if (System.Diagnostics.Debugger.IsAttached == false)
            {

                System.Diagnostics.Debugger.Launch();

            }
            ApplicationRole adminRole = new ApplicationRole("Administrator");
            ApplicationRole userRole = new ApplicationRole() { Name = "User" };
            ApplicationRole devRole = new ApplicationRole() { Name = "Developer" };
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));
            roleManager.Create(adminRole);
            roleManager.Create(userRole);
            roleManager.Create(devRole);

            adminRole.Claims.Add(new RoleClaim() { ClaimType = "AdminLogin", ClaimValue = "true" });
            devRole.Claims.Add(new RoleClaim() { ClaimType = "AdminLogin", ClaimValue = "true" });
            devRole.Claims.Add(new RoleClaim() { ClaimType = "Developer", ClaimValue = "true" });
            adminRole.Claims.Add(new RoleClaim() { ClaimType = "EditHtmlContent", ClaimValue = "true" });
            
            context.SaveChanges();

            ApplicationUser usrAdmin = new ApplicationUser
            {
                UserName = "admin",
                FirstName = "Admin",
                LastName = "Lastname",
                Email = "Email@admin.com"
            };

            var createResult = userManager.Create(usrAdmin, "admin1");

            if (createResult.Errors.Count() > 0)
                throw new Exception(createResult.Errors.First());
            userManager.AddToRole(usrAdmin.Id, "Administrator");
            userManager.AddToRole(usrAdmin.Id, "User");

            ApplicationUser usrUser = new ApplicationUser
            {
                UserName = "user",
                FirstName = "User1",
                LastName = "Lastname",
                Email = "Email@user1.com"
            };

            var createAdminResult = userManager.Create(usrUser, "user12");

            if (createAdminResult.Errors.Count() > 0)
                throw new Exception(createAdminResult.Errors.First());
            userManager.AddToRole(usrUser.Id, "User");


            ApplicationUser devUser = new ApplicationUser
            {
                UserName = "dev",
                FirstName = "Developer",
                LastName = "Lastname",
                Email = "Email@developer.com"
            };

            var createDevResult = userManager.Create(devUser, "dev123");

            if (createDevResult.Errors.Count() > 0)
                throw new Exception(createDevResult.Errors.First());
            userManager.AddToRole(devUser.Id, "User");
            userManager.AddToRole(devUser.Id, "Administrator");
            userManager.AddToRole(devUser.Id, "Developer");

            base.Seed(context);
        }
    }
}
