namespace Ng2Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewStuff : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InstitutionApplicationUsers", newName: "ApplicationUserInstitutions");
            DropPrimaryKey("dbo.ApplicationUserInstitutions");
            AddPrimaryKey("dbo.ApplicationUserInstitutions", new[] { "ApplicationUser_Id", "Institution_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ApplicationUserInstitutions");
            AddPrimaryKey("dbo.ApplicationUserInstitutions", new[] { "Institution_Id", "ApplicationUser_Id" });
            RenameTable(name: "dbo.ApplicationUserInstitutions", newName: "InstitutionApplicationUsers");
        }
    }
}
