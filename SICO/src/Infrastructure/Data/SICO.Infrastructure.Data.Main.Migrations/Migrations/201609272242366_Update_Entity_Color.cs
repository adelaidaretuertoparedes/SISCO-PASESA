namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Entity_Color : DbMigration
    {
        public override void Up()
        {            
            AlterColumn("dbo.Color", "LegacyCode", c => c.String(nullable: false, maxLength: 3, unicode: false));
            AlterColumn("dbo.Color", "Name", c => c.String(nullable: false, maxLength: 60, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Color", "Name", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Color", "LegacyCode", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Color", "Code", c => c.String(nullable: false, maxLength: 6));
        }
    }
}
