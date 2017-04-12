namespace AcroGARC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDurationInCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Duration", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Duration");
        }
    }
}
