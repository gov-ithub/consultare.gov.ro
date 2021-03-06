namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Email : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Proposals", "Email", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Proposals", "Email", c => c.String(nullable: false, maxLength: 1000));
        }
    }
}
