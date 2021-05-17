namespace LibMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LendFirstM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookLends", "DateLent", c => c.DateTime(nullable: false));
            AddColumn("dbo.BookLends", "ReturnDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "BookLocAtLibrary", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "BookLocAtLibrary");
            DropColumn("dbo.BookLends", "ReturnDate");
            DropColumn("dbo.BookLends", "DateLent");
        }
    }
}
