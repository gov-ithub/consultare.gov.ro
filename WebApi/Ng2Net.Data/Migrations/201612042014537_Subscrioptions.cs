namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subscrioptions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskRunnerLogs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DateStarted = c.DateTime(),
                        DateEnded = c.DateTime(),
                        JobResult = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaskRunnerLogs");
        }
    }
}
