namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HtmlContents2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HtmlContents", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.HtmlContents", "Text", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HtmlContents", "Text", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.HtmlContents", "Name");
        }
    }
}
