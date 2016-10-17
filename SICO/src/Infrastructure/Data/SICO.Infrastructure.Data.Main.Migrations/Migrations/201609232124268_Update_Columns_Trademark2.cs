namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Columns_Trademark2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trademark", "LegacyCode", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Trademark", "ShortName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Trademark", "Owner", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trademark", "Owner", c => c.String(maxLength: 150));
            AlterColumn("dbo.Trademark", "ShortName", c => c.String(maxLength: 100));
            DropColumn("dbo.Trademark", "LegacyCode");
        }
    }
}
