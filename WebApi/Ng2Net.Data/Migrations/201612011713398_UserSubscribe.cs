namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserSubscribe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "UnsubscribeToken", c => c.String());
            AddColumn("dbo.ApplicationUsers", "SubscribedToAll", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "SubscribedToAll");
            DropColumn("dbo.ApplicationUsers", "UnsubscribeToken");
        }
    }
}
