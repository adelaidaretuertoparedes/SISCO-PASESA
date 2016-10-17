namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Computed_Column_Code : DbMigration
    {
        public override void Up()
        {
            //Sql("ALTER TABLE dbo.Classification ADD [Code] AS (dbo.UFN_GetNextCodeSequence('CL',Id,3))");

        }
        
        public override void Down()
        {
        }
    }
}
