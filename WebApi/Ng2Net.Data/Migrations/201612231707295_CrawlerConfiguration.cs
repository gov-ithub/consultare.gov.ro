namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrawlerConfiguration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CrawlerConfigurations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        InstitutionId = c.String(),
                        Url = c.String(),
                        XsltConfig = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Proposals", "ProposalSignature", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proposals", "ProposalSignature");
            DropTable("dbo.CrawlerConfigurations");
        }
    }
}
