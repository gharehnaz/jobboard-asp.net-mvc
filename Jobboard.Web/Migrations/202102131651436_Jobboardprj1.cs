namespace Jobboard.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jobboardprj1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobTitle = c.String(),
                        JobType = c.String(),
                        CompanyName = c.String(),
                        Location = c.String(),
                        JobRegion = c.String(),
                        PictureUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Jobs");
        }
    }
}
