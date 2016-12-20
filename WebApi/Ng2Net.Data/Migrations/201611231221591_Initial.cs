namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER DATABASE [consultare.gov.start] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;");
            Sql("ALTER DATABASE [consultare.gov.start] COLLATE Latin1_general_CI_AI", suppressTransaction: true);
            Sql("ALTER DATABASE [consultare.gov.start] SET MULTI_USER;");
            CreateTable(
                "dbo.HtmlContents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Content = c.String(),
                        Url = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        From = c.String(nullable: false, maxLength: 255),
                        To = c.String(maxLength: 255),
                        Cc = c.String(maxLength: 255),
                        Bcc = c.String(maxLength: 255),
                        Subject = c.String(maxLength: 1000),
                        Body = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        Status = c.String(maxLength: 255),
                        DateProcessed = c.DateTime(),
                        Counter = c.Int(nullable: false),
                        Error = c.String(),
                        Attachments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleClaims",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        RoleId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityRoles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
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
                "dbo.ProposalCategories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Url = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Proposals",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 1000),
                        InstitutionId = c.String(nullable: false, maxLength: 128),
                        InitiatingInstitutionId = c.String(maxLength: 128),
                        Description = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(nullable: false),
                        LimitDate = c.DateTime(),
                        Link = c.String(nullable: false, maxLength: 1000),
                        Email = c.String(nullable: false, maxLength: 255),
                        Observations = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Institutions", t => t.InstitutionId, cascadeDelete: true)
                .ForeignKey("dbo.Institutions", t => t.InitiatingInstitutionId)
                .Index(t => t.InstitutionId)
                .Index(t => t.InitiatingInstitutionId);
            
            CreateTable(
                "dbo.Institutions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Type = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.ProposalCategoryProposals",
                c => new
                    {
                        ProposalCategory_Id = c.String(nullable: false, maxLength: 128),
                        Proposal_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProposalCategory_Id, t.Proposal_Id })
                .ForeignKey("dbo.ProposalCategories", t => t.ProposalCategory_Id)
                .ForeignKey("dbo.Proposals", t => t.Proposal_Id)
                .Index(t => t.ProposalCategory_Id)
                .Index(t => t.Proposal_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProposalCategoryProposals", "Proposal_Id", "dbo.Proposals");
            DropForeignKey("dbo.ProposalCategoryProposals", "ProposalCategory_Id", "dbo.ProposalCategories");
            DropForeignKey("dbo.Proposals", "InitiatingInstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Proposals", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUserIdentityUserLogins", "UserId", "dbo.IdentityUserLogins");
            DropForeignKey("dbo.ApplicationUserIdentityUserLogins", "Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "RoleId", "dbo.IdentityRoles");
            DropForeignKey("dbo.RoleClaims", "RoleId", "dbo.IdentityRoles");
            DropIndex("dbo.ProposalCategoryProposals", new[] { "Proposal_Id" });
            DropIndex("dbo.ProposalCategoryProposals", new[] { "ProposalCategory_Id" });
            DropIndex("dbo.ApplicationUserIdentityUserLogins", new[] { "UserId" });
            DropIndex("dbo.ApplicationUserIdentityUserLogins", new[] { "Id" });
            DropIndex("dbo.Proposals", new[] { "InitiatingInstitutionId" });
            DropIndex("dbo.Proposals", new[] { "InstitutionId" });
            DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "RoleId" });
            DropIndex("dbo.RoleClaims", new[] { "RoleId" });
            DropTable("dbo.ProposalCategoryProposals");
            DropTable("dbo.ApplicationUserIdentityUserLogins");
            DropTable("dbo.Institutions");
            DropTable("dbo.Proposals");
            DropTable("dbo.ProposalCategories");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.RoleClaims");
            DropTable("dbo.Notifications");
            DropTable("dbo.HtmlContents");
        }
    }
}
