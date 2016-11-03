namespace Consultare.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMinisteries : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Proposals", "MinisteryId", "dbo.Ministeries");
            DropIndex("dbo.Proposals", new[] { "MinisteryId" });
            AddColumn("dbo.Institutions", "Type", c => c.String());
            AddColumn("dbo.Proposals", "InitiatingInstitutionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Proposals", "InitiatingInstitutionId");
            AddForeignKey("dbo.Proposals", "InitiatingInstitutionId", "dbo.Institutions", "Id", cascadeDelete: false);
            DropColumn("dbo.Proposals", "MinisteryId");
            DropTable("dbo.Ministeries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ministeries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Proposals", "MinisteryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Proposals", "InitiatingInstitutionId", "dbo.Institutions");
            DropIndex("dbo.Proposals", new[] { "InitiatingInstitutionId" });
            DropColumn("dbo.Proposals", "InitiatingInstitutionId");
            DropColumn("dbo.Institutions", "Type");
            CreateIndex("dbo.Proposals", "MinisteryId");
            AddForeignKey("dbo.Proposals", "MinisteryId", "dbo.Ministeries", "Id", cascadeDelete: true);
        }
    }
}
