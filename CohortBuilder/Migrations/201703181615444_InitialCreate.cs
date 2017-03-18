namespace CohortBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cohorts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Cohort_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cohorts", t => t.Cohort_Id)
                .Index(t => t.Cohort_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Cohort_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cohorts", t => t.Cohort_Id)
                .Index(t => t.Cohort_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Cohort_Id", "dbo.Cohorts");
            DropForeignKey("dbo.Instructors", "Cohort_Id", "dbo.Cohorts");
            DropIndex("dbo.Students", new[] { "Cohort_Id" });
            DropIndex("dbo.Instructors", new[] { "Cohort_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Instructors");
            DropTable("dbo.Cohorts");
        }
    }
}
