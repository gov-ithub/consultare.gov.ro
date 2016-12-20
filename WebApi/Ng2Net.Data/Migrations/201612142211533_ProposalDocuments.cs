namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProposalDocuments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProposalCategoryProposals", "ProposalCategory_Id", "dbo.ProposalCategories");
            DropForeignKey("dbo.ProposalCategoryProposals", "Proposal_Id", "dbo.Proposals");
            DropIndex("dbo.ProposalCategoryProposals", new[] { "ProposalCategory_Id" });
            DropIndex("dbo.ProposalCategoryProposals", new[] { "Proposal_Id" });
            CreateTable(
                "dbo.ProposalDocuments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Type = c.String(),
                        Url = c.String(),
                        Proposal_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proposals", t => t.Proposal_Id)
                .Index(t => t.Proposal_Id);
            
            DropTable("dbo.ProposalCategories");
            DropTable("dbo.ProposalCategoryProposals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProposalCategoryProposals",
                c => new
                    {
                        ProposalCategory_Id = c.String(nullable: false, maxLength: 128),
                        Proposal_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ProposalCategory_Id, t.Proposal_Id });
            
            CreateTable(
                "dbo.ProposalCategories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Url = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.ProposalDocuments", "Proposal_Id", "dbo.Proposals");
            DropIndex("dbo.ProposalDocuments", new[] { "Proposal_Id" });
            DropTable("dbo.ProposalDocuments");
            CreateIndex("dbo.ProposalCategoryProposals", "Proposal_Id");
            CreateIndex("dbo.ProposalCategoryProposals", "ProposalCategory_Id");
            AddForeignKey("dbo.ProposalCategoryProposals", "Proposal_Id", "dbo.Proposals", "Id");
            AddForeignKey("dbo.ProposalCategoryProposals", "ProposalCategory_Id", "dbo.ProposalCategories", "Id");
        }
    }
}
