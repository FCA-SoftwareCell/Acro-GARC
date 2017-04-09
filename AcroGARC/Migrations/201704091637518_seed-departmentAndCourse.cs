namespace AcroGARC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seeddepartmentAndCourse : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Departments (Name) Values ('FCA')");
            Sql("INSERT INTO Courses (Name,DepartmentId) Values ('MCA',1)");
        }
        
        public override void Down()
        {
        }
    }
}
