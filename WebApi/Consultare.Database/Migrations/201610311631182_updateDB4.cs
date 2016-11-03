namespace Consultare.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Proposals", "Title", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Proposals", "Link", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Proposals", "Email", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proposals", "Email", c => c.String(maxLength: 255));
            AlterColumn("dbo.Proposals", "Link", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Proposals", "Title", c => c.String(maxLength: 1000));
        }
    }
}
