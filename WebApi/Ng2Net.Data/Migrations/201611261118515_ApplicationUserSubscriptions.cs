namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserSubscriptions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstitutionApplicationUsers",
                c => new
                    {
                        Institution_Id = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Institution_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Institutions", t => t.Institution_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Institution_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstitutionApplicationUsers", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.InstitutionApplicationUsers", "Institution_Id", "dbo.Institutions");
            DropIndex("dbo.InstitutionApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.InstitutionApplicationUsers", new[] { "Institution_Id" });
            DropTable("dbo.InstitutionApplicationUsers");
        }
    }
}
