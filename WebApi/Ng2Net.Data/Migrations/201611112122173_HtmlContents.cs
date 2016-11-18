namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HtmlContents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HtmlContents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Text = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HtmlContents");
        }
    }
}
