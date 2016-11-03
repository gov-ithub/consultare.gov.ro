namespace Consultare.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Institutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Proposals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 1000),
                        InstitutionId = c.Int(nullable: false),
                        InitiatingInstitutionId = c.Int(nullable: false),
                        Description = c.String(maxLength: 2000),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(nullable: false),
                        LimitDate = c.DateTime(),
                        Link = c.String(nullable: false, maxLength: 1000),
                        Email = c.String(nullable: false, maxLength: 255),
                        Observations = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Institutions", t => t.InitiatingInstitutionId)
                .ForeignKey("dbo.Institutions", t => t.InstitutionId)
                .Index(t => t.InstitutionId)
                .Index(t => t.InitiatingInstitutionId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(maxLength: 255),
                        LastName = c.String(maxLength: 255),
                        DateCreated = c.DateTime(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUserIdentityUserLogins",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Id, t.UserId })
                .ForeignKey("dbo.ApplicationUsers", t => t.Id)
                .ForeignKey("dbo.IdentityUserLogins", t => t.UserId)
                .Index(t => t.Id)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserIdentityUserLogins", "UserId", "dbo.IdentityUserLogins");
            DropForeignKey("dbo.ApplicationUserIdentityUserLogins", "Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "RoleId", "dbo.IdentityRoles");
            DropForeignKey("dbo.Proposals", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Proposals", "InitiatingInstitutionId", "dbo.Institutions");
            DropIndex("dbo.ApplicationUserIdentityUserLogins", new[] { "UserId" });
            DropIndex("dbo.ApplicationUserIdentityUserLogins", new[] { "Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "RoleId" });
            DropIndex("dbo.Proposals", new[] { "InitiatingInstitutionId" });
            DropIndex("dbo.Proposals", new[] { "InstitutionId" });
            DropTable("dbo.ApplicationUserIdentityUserLogins");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Proposals");
            DropTable("dbo.Institutions");
        }
    }
}
