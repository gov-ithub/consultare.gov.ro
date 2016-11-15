namespace Ng2Net.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HtmlContents3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HtmlContents", "Content", c => c.String());
            DropColumn("dbo.HtmlContents", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HtmlContents", "Text", c => c.String());
            DropColumn("dbo.HtmlContents", "Content");
        }
    }
}
