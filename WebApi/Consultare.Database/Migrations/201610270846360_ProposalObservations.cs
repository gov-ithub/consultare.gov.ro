namespace Consultare.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProposalObservations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proposals", "Observations", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proposals", "Observations");
        }
    }
}
