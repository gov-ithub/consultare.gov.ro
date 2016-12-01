namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProposalsCorrection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Proposals", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Proposals", "Email", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proposals", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Proposals", "EndDate", c => c.DateTime(nullable: false));
        }
    }
}
