namespace AcroGARC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSubjectAllocation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectAllocations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        FacultyId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.FacultyId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.FacultyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectAllocations", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SubjectAllocations", "FacultyId", "dbo.AspNetUsers");
            DropIndex("dbo.SubjectAllocations", new[] { "FacultyId" });
            DropIndex("dbo.SubjectAllocations", new[] { "SubjectId" });
            DropTable("dbo.SubjectAllocations");
        }
    }
}
