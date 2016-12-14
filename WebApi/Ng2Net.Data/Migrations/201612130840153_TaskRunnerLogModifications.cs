namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskRunnerLogModifications : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskRunnerLogs", "TaskName", c => c.String(maxLength: 255));
            AddColumn("dbo.TaskRunnerLogs", "TaskResult", c => c.String(maxLength: 255));
            AlterColumn("dbo.TaskRunnerLogs", "DateStarted", c => c.DateTime(nullable: false));
            DropColumn("dbo.TaskRunnerLogs", "JobResult");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskRunnerLogs", "JobResult", c => c.String(maxLength: 255));
            AlterColumn("dbo.TaskRunnerLogs", "DateStarted", c => c.DateTime());
            DropColumn("dbo.TaskRunnerLogs", "TaskResult");
            DropColumn("dbo.TaskRunnerLogs", "TaskName");
        }
    }
}
