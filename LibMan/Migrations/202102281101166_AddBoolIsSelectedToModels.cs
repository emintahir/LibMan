namespace LibMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBoolIsSelectedToModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "IsSelected", c => c.Boolean(nullable: false));
            AddColumn("dbo.Borrowers", "IsSelected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Borrowers", "IsSelected");
            DropColumn("dbo.Books", "IsSelected");
        }
    }
}
