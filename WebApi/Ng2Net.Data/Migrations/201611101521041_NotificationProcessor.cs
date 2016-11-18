namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotificationProcessor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        From = c.String(nullable: false, maxLength: 255),
                        To = c.String(maxLength: 255),
                        Cc = c.String(maxLength: 255),
                        Bcc = c.String(maxLength: 255),
                        Subject = c.String(maxLength: 1000),
                        Body = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        DateProcessed = c.DateTime(),
                        Counter = c.Int(nullable: false),
                        Error = c.String(),
                        Attachments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notifications");
        }
    }
}
