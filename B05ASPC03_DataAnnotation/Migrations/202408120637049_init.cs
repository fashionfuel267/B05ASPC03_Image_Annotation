namespace B05ASPC03_DataAnnotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        Description = c.String(maxLength: 150),
                        CategoryId = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "CategoryId", "dbo.BlogCategories");
            DropIndex("dbo.Blogs", new[] { "CategoryId" });
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogCategories");
        }
    }
}
