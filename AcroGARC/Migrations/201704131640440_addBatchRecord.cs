namespace AcroGARC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBatchRecord : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Batches", "CourseId", "dbo.Courses");
            DropIndex("dbo.Batches", new[] { "CourseId" });
            CreateTable(
                "dbo.BatchRecords",
                c => new
                    {
                        ClassStructureId = c.Int(nullable: false),
                        BatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClassStructureId, t.BatchId })
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .ForeignKey("dbo.ClassStructures", t => t.ClassStructureId, cascadeDelete: true)
                .Index(t => t.ClassStructureId)
                .Index(t => t.BatchId);
            
            CreateTable(
                "dbo.ClassStructures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.SemesterId);
            
            DropColumn("dbo.Batches", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Batches", "CourseId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BatchRecords", "ClassStructureId", "dbo.ClassStructures");
            DropForeignKey("dbo.ClassStructures", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.ClassStructures", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.BatchRecords", "BatchId", "dbo.Batches");
            DropIndex("dbo.ClassStructures", new[] { "SemesterId" });
            DropIndex("dbo.ClassStructures", new[] { "CourseId" });
            DropIndex("dbo.BatchRecords", new[] { "BatchId" });
            DropIndex("dbo.BatchRecords", new[] { "ClassStructureId" });
            DropTable("dbo.ClassStructures");
            DropTable("dbo.BatchRecords");
            CreateIndex("dbo.Batches", "CourseId");
            AddForeignKey("dbo.Batches", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
