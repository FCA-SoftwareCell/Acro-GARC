namespace AcroGARC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addSubjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 126),
                    ClassStructureId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassStructures", t => t.ClassStructureId, cascadeDelete: true)
                .Index(t => t.ClassStructureId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "ClassStructureId", "dbo.ClassStructures");
            DropIndex("dbo.Subjects", new[] { "ClassStructureId" });
            DropTable("dbo.Subjects");
        }
    }
}
