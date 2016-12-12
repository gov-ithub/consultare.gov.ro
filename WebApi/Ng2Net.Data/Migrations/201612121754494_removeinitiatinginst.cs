namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeinitiatinginst : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Proposals", "InitiatingInstitutionId", "dbo.Institutions");
            DropIndex("dbo.Proposals", new[] { "InitiatingInstitutionId" });
            DropColumn("dbo.Proposals", "InitiatingInstitutionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proposals", "InitiatingInstitutionId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Proposals", "InitiatingInstitutionId");
            AddForeignKey("dbo.Proposals", "InitiatingInstitutionId", "dbo.Institutions", "Id");
        }
    }
}
