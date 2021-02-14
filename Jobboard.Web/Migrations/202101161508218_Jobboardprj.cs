namespace Jobboard.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jobboardprj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Price = c.Long(nullable: false),
                        Title = c.String(),
                        PictureUrl = c.String(),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Author = c.String(),
                        NewsCategory_Id = c.Long(nullable: false),
                        Title = c.String(),
                        PictureUrl = c.String(),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsCategoryEntities", t => t.NewsCategory_Id, cascadeDelete: true)
                .Index(t => t.NewsCategory_Id);
            
            CreateTable(
                "dbo.NewsCategoryEntities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "NewsCategory_Id", "dbo.NewsCategoryEntities");
            DropIndex("dbo.News", new[] { "NewsCategory_Id" });
            DropTable("dbo.NewsCategoryEntities");
            DropTable("dbo.News");
            DropTable("dbo.Courses");
        }
    }
}
