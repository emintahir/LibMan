namespace LibMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLendDetailTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LendBooks", newName: "Lends");
            DropForeignKey("dbo.LendBooks", "BookId", "dbo.Books");
            DropIndex("dbo.Lends", new[] { "BookId" });
            CreateTable(
                "dbo.LendDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LendId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Lends", t => t.LendId, cascadeDelete: true)
                .Index(t => t.LendId)
                .Index(t => t.BookId);
            
            DropColumn("dbo.Lends", "BookId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lends", "BookId", c => c.Int(nullable: false));
            DropForeignKey("dbo.LendDetails", "LendId", "dbo.Lends");
            DropForeignKey("dbo.LendDetails", "BookId", "dbo.Books");
            DropIndex("dbo.LendDetails", new[] { "BookId" });
            DropIndex("dbo.LendDetails", new[] { "LendId" });
            DropTable("dbo.LendDetails");
            CreateIndex("dbo.Lends", "BookId");
            AddForeignKey("dbo.LendBooks", "BookId", "dbo.Books", "BookId", cascadeDelete: true);
            RenameTable(name: "dbo.Lends", newName: "LendBooks");
        }
    }
}
