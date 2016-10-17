namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Columns_Audit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trademark", "Name", c => c.String());
            AlterColumn("dbo.Trademark", "CreatorUser", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Trademark", "UpdaterIpAddress", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trademark", "UpdaterIpAddress", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Trademark", "CreatorUser", c => c.String(maxLength: 20));
            AlterColumn("dbo.Trademark", "Name", c => c.String(maxLength: 100));
        }
    }
}
