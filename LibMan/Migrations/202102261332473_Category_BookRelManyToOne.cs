namespace LibMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Category_BookRelManyToOne : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookCategories", "BookId", "dbo.Books");
            DropForeignKey("dbo.BookCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.BookCategories", new[] { "BookId" });
            DropIndex("dbo.BookCategories", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Books", name: "Category_CategoryId", newName: "CategoryId");
            RenameIndex(table: "dbo.Books", name: "IX_Category_CategoryId", newName: "IX_CategoryId");
            DropTable("dbo.BookCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BookCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            RenameIndex(table: "dbo.Books", name: "IX_CategoryId", newName: "IX_Category_CategoryId");
            RenameColumn(table: "dbo.Books", name: "CategoryId", newName: "Category_CategoryId");
            CreateIndex("dbo.BookCategories", "CategoryId");
            CreateIndex("dbo.BookCategories", "BookId");
            AddForeignKey("dbo.BookCategories", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.BookCategories", "BookId", "dbo.Books", "BookId", cascadeDelete: true);
        }
    }
}
