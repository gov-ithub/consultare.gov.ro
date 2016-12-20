namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProposalDocumentTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proposals", "Documents", c => c.String());
            AddColumn("dbo.Proposals", "bArchive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proposals", "bArchive");
            DropColumn("dbo.Proposals", "Documents");
        }
    }
}
