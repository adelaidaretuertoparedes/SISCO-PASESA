namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Column_EnglishName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Color", "EnglishName", c => c.String());
            AlterColumn("dbo.Color", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Color", "Name", c => c.String(nullable: false, maxLength: 60, unicode: false));
            DropColumn("dbo.Color", "EnglishName");
        }
    }
}
