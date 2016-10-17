namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Computed_Column_Code_Table_SizeType : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.SizeType ADD Code AS (dbo.UFN_GetNextCodeSequence('TL',Id,3))");
        }        
        public override void Down()
        {
        }
    }
}
