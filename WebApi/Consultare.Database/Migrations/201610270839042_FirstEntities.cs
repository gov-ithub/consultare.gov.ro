namespace Consultare.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Institutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ministeries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Proposals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 1000),
                        InstitutionId = c.Int(nullable: false),
                        MinisteryId = c.Int(nullable: false),
                        Description = c.String(maxLength: 2000),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(nullable: false),
                        LimitDate = c.DateTime(),
                        Link = c.String(maxLength: 1000),
                        Email = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Institutions", t => t.InstitutionId, cascadeDelete: true)
                .ForeignKey("dbo.Ministeries", t => t.MinisteryId, cascadeDelete: true)
                .Index(t => t.InstitutionId)
                .Index(t => t.MinisteryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proposals", "MinisteryId", "dbo.Ministeries");
            DropForeignKey("dbo.Proposals", "InstitutionId", "dbo.Institutions");
            DropIndex("dbo.Proposals", new[] { "MinisteryId" });
            DropIndex("dbo.Proposals", new[] { "InstitutionId" });
            DropTable("dbo.Proposals");
            DropTable("dbo.Ministeries");
            DropTable("dbo.Institutions");
        }
    }
}
