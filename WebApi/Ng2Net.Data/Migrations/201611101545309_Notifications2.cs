namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notifications2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifications", "Status", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notifications", "Status", c => c.Int(nullable: false));
        }
    }
}
