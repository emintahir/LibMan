namespace LibMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateAddedToLibrary : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "DateAddedToLibrary", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "DateAddedToLibrary", c => c.DateTime());
        }
    }
}
