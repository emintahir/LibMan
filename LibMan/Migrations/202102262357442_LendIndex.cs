namespace LibMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LendIndex : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BookLends", newName: "LendBooks");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.LendBooks", newName: "BookLends");
        }
    }
}
