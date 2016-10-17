namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Compute_Column_Table_Trademark : DbMigration
    {
        public override void Up()
        {
            //Sql("ALTER TABLE dbo.Trademark ADD [Code] AS (dbo.UFN_GetNextSequence('MC',Id,4))");
        }
        
        public override void Down()
        {
        }
    }
}
