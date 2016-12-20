namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProposalDocumentTypes1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proposals", "Archived", c => c.Boolean(nullable: false));
            DropColumn("dbo.Proposals", "bArchive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proposals", "bArchive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Proposals", "Archived");
        }
    }
}
