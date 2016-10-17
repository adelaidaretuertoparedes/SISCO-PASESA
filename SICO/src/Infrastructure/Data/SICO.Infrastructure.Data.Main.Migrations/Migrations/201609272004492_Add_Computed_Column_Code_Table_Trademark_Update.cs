namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Computed_Column_Code_Table_Trademark_Update : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.Trademark ADD [Code] AS (dbo.UFN_GetNextCodeSequence('MC',Id,4))");
        }
        
        public override void Down()
        {
           
        }
    }
}
