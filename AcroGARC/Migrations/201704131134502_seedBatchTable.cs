namespace AcroGARC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class seedBatchTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Batches (Year,CourseId) Values(getDate(),'1')");
        }

        public override void Down()
        {
        }
    }
}
