namespace AcroGARC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClassMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassOrganisations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(nullable: false, maxLength: 128),
                        ClassStructureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassStructures", t => t.ClassStructureId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.ClassStructureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassOrganisations", "StudentId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ClassOrganisations", "ClassStructureId", "dbo.ClassStructures");
            DropIndex("dbo.ClassOrganisations", new[] { "ClassStructureId" });
            DropIndex("dbo.ClassOrganisations", new[] { "StudentId" });
            DropTable("dbo.ClassOrganisations");
        }
    }
}
