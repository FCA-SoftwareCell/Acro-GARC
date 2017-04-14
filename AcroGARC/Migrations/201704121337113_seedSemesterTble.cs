namespace AcroGARC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class seedSemesterTble : DbMigration
    {
        public override void Up()
        {

            Sql(" INSERT INTO[dbo].[Semesters] ([Name]) VALUES('First')");
            Sql(" INSERT INTO[dbo].[Semesters] ([Name]) VALUES('Second')");
            Sql(" INSERT INTO[dbo].[Semesters] ([Name]) VALUES('Third')");
            Sql(" INSERT INTO[dbo].[Semesters] ([Name]) VALUES('Fourth')");
            Sql(" INSERT INTO[dbo].[Semesters] ([Name]) VALUES('Fifth')");
            Sql(" INSERT INTO[dbo].[Semesters] ([Name]) VALUES('Sixth')");
            Sql(" INSERT INTO[dbo].[Semesters] ([Name]) VALUES('Seventh')");
            Sql(" INSERT INTO[dbo].[Semesters] ([Name]) VALUES('Eighth')");
            Sql(" INSERT INTO[dbo].[Semesters] ([Name]) VALUES('Ninth')");
            Sql(" INSERT INTO[dbo].[Semesters] ([Name]) VALUES('Tenth')");

        }

        public override void Down()
        {
        }
    }
}
