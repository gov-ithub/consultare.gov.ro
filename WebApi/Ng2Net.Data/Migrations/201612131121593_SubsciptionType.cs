namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubsciptionType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "SubscriptionType", c => c.String(maxLength: 255));
            DropColumn("dbo.ApplicationUsers", "SubscribedToAll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUsers", "SubscribedToAll", c => c.Boolean(nullable: false));
            DropColumn("dbo.ApplicationUsers", "SubscriptionType");
        }
    }
}
