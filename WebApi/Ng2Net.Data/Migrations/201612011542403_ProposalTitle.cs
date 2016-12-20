namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProposalTitle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Proposals", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proposals", "Title", c => c.String(nullable: false, maxLength: 1000));
        }
    }
}
