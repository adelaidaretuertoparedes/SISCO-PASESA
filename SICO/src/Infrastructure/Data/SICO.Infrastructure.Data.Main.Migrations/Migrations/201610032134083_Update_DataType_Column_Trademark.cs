namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_DataType_Column_Trademark : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trademark", "LegacyCode", c => c.String(nullable: false, maxLength: 2, unicode: false));
            AlterColumn("dbo.Trademark", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Trademark", "Owner", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trademark", "Owner", c => c.String(maxLength: 100));
            AlterColumn("dbo.Trademark", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Trademark", "LegacyCode", c => c.String(nullable: false, maxLength: 2));
        }
    }
}
