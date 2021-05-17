namespace LibMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertForBookDetails1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "YearPublished", c => c.Int());
            DropColumn("dbo.Books", "DatePublished");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "DatePublished", c => c.DateTime());
            DropColumn("dbo.Books", "YearPublished");
        }
    }
}
