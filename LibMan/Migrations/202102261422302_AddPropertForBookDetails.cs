namespace LibMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertForBookDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Publisher", c => c.String());
            AddColumn("dbo.Books", "DatePublished", c => c.DateTime());
            AddColumn("dbo.Books", "DateAddedToLibrary", c => c.DateTime());
            AddColumn("dbo.Books", "Page", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Page");
            DropColumn("dbo.Books", "DateAddedToLibrary");
            DropColumn("dbo.Books", "DatePublished");
            DropColumn("dbo.Books", "Publisher");
        }
    }
}
