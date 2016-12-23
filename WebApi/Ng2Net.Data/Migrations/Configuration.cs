namespace Ng2Net.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Security;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Security.Claims;
    public sealed class Configuration : DbMigrationsConfiguration<Ng2Net.Data.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Ng2Net.Data.DatabaseContext context)
        {
            context.CrawlerConfigurations.AddOrUpdate(x => x.Id,
                new Model.Scheduler.CrawlerConfiguration()
                {
                    Id = "d522d7f8-1f07-4e58-9612-1d45d2c425ca",
                    InstitutionId = "1",
                    Active = true,
                    Url = "http://www.mai.gov.ro/index05_1.html",
                    XsltConfig = @"<?xml version=""1.0"" encoding=""UTF-8""?><xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">
                                    <xsl:template match=""/"">
                                    <rows>
                                    <xsl:apply-templates select=""//div[@class='textPreview']/div[@style]"" />
                                    </rows>
                                </xsl:template>
                                <xsl:template match=""div[@style]/p/strong"">
                                <row>
                                <date><xsl:value-of select=""substring(normalize-space(),29,4)"" />-<xsl:value-of select=""substring(normalize-space(),26,2)"" />-<xsl:value-of select=""substring(normalize-space(),23,2)"" /></date>
                                <xsl:variable name=""firstDivId"" select=""generate-id(./ancestor::div[@style and position()=1])"" />
                                <xsl:for-each select=""./ancestor::div[@style]/following-sibling::p"">   
                                <xsl:if test=""$firstDivId=generate-id(preceding-sibling::div[@style and position()=1])"">
                                    <xsl:call-template name=""processBody"" /> 
                                </xsl:if>
                                </xsl:for-each>
                                </row>
                                </xsl:template>
                                <xsl:template name=""processBody"">
                                    <xsl:if test=""contains(normalize-space(),'[...]')"">
                                        <body><xsl:value-of select=""substring-before(normalize-space(), '[...]')"" /></body>
                                    </xsl:if>
                                    <xsl:if test=""a/@href"">
                                        <file>http://www.mai.gov.ro/<xsl:value-of select=""a/@href"" /></file>
                                    </xsl:if>
                                    <xsl:if test=""contains(normalize-space(),'mai.gov.ro')"">
                                        <xsl:variable name=""firstProcess"" select=""substring-before(normalize-space(), ' de zile')"" />
                                        <xsl:variable name=""secondProcess"" select=""substring($firstProcess, string-length($firstProcess)-1,2)"" />
                                        <days><xsl:value-of select=""$secondProcess"" /></days>
                                        <xsl:variable name=""thirdProcess"" select=""substring-after(normalize-space(), 'adresa de e-mail: ')"" />
                                        <xsl:variable name=""fourthProcess"" select=""substring-before($thirdProcess, ', ')"" />
                                        <email><xsl:value-of select=""$fourthProcess"" /></email>
                                    </xsl:if>
                                </xsl:template>
                                </xsl:stylesheet>"
                }
                );


            if (context.Roles.Count() > 0)
                return;
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{

            //    System.Diagnostics.Debugger.Launch();

            //}
            ApplicationRole adminRole = new ApplicationRole("Administrator");
            ApplicationRole userRole = new ApplicationRole() { Name = "User" };
            ApplicationRole devRole = new ApplicationRole() { Name = "Developer" };
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));
            roleManager.Create(adminRole);
            roleManager.Create(userRole);
            roleManager.Create(devRole);

            devRole.Claims.Add(new RoleClaim() { ClaimType = "AdminLogin", ClaimValue = "true" });
            devRole.Claims.Add(new RoleClaim() { ClaimType = "Developer", ClaimValue = "true" });
            devRole.Claims.Add(new RoleClaim() { ClaimType = "EditProposals", ClaimValue = "true" });
            devRole.Claims.Add(new RoleClaim() { ClaimType = "ManageUsers", ClaimValue = "true" });
            adminRole.Claims.Add(new RoleClaim() { ClaimType = "AdminLogin", ClaimValue = "true" });
            adminRole.Claims.Add(new RoleClaim() { ClaimType = "EditHtmlContent", ClaimValue = "true" });
            adminRole.Claims.Add(new RoleClaim() { ClaimType = "EditProposals", ClaimValue = "true" });
            adminRole.Claims.Add(new RoleClaim() { ClaimType = "ManageUsers", ClaimValue = "true" });

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
