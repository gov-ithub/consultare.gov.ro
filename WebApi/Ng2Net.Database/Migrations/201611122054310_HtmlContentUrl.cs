namespace Ng2Net.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HtmlContentUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HtmlContents", "Url", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HtmlContents", "Url");
        }
    }
}
