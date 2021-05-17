namespace LibMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateAndEditNationalId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Borrowers", "NationalId", c => c.String());
            AddColumn("dbo.Borrowers", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Borrowers", "NationalNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Borrowers", "NationalNumber", c => c.String());
            DropColumn("dbo.Borrowers", "BirthDate");
            DropColumn("dbo.Borrowers", "NationalId");
        }
    }
}
