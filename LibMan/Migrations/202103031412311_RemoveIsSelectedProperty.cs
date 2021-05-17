namespace LibMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIsSelectedProperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "IsSelected");
            DropColumn("dbo.Borrowers", "IsSelected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Borrowers", "IsSelected", c => c.Boolean(nullable: false));
            AddColumn("dbo.Books", "IsSelected", c => c.Boolean(nullable: false));
        }
    }
}
