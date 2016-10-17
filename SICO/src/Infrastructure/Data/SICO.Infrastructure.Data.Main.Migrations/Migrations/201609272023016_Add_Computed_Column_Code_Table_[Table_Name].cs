namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Computed_Column_Code_Table_Table_Name : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.Color ADD Code AS (dbo.UFN_GetNextCodeSequence('CR',Id,5))");
        }
        
        public override void Down()
        {
        }
    }
}
