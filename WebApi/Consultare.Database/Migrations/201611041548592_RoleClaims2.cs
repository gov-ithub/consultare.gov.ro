namespace Consultare.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleClaims2 : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.IdentityRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleClaims", "RoleId", "dbo.IdentityRoles");
            DropIndex("dbo.RoleClaims", new[] { "RoleId" });
            DropColumn("dbo.IdentityRoles", "Discriminator");
            DropTable("dbo.RoleClaims");
        }
    }
}
