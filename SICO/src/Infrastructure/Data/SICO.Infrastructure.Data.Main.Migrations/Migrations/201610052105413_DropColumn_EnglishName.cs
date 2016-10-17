namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropColumn_EnglishName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Color", "EnglishName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Color", "EnglishName", c => c.String());
        }
    }
}
