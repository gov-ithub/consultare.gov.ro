namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProposalDocuments2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProposalDocuments", name: "Proposal_Id", newName: "ProposalId");
            RenameIndex(table: "dbo.ProposalDocuments", name: "IX_Proposal_Id", newName: "IX_ProposalId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProposalDocuments", name: "IX_ProposalId", newName: "IX_Proposal_Id");
            RenameColumn(table: "dbo.ProposalDocuments", name: "ProposalId", newName: "Proposal_Id");
        }
    }
}
