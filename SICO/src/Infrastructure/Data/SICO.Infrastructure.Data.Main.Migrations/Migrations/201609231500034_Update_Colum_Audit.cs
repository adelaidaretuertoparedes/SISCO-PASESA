namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Colum_Audit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trademark", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trademark", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Trademark", "CreatorUser", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Trademark", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Trademark", "UpdaterIpAddress", c => c.String(maxLength: 20));
            AddColumn("dbo.Trademark", "UpdaterUser", c => c.String(maxLength: 20));
            AddColumn("dbo.Color", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Color", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Color", "CreatorUser", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Color", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Color", "UpdaterIpAddress", c => c.String(maxLength: 20));
            AddColumn("dbo.Color", "UpdaterUser", c => c.String(maxLength: 20));
            AlterColumn("dbo.Color", "Code", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Color", "LegacyCode", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Color", "Name", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Trademark", "CreatedDate");
            DropColumn("dbo.Trademark", "UpdatedDate");
            DropColumn("dbo.Trademark", "CreatedIpAddress");
            DropColumn("dbo.Trademark", "CreatedUser");
            DropColumn("dbo.Trademark", "UpdatedIpAddress");
            DropColumn("dbo.Trademark", "UpdatedUser");
            DropColumn("dbo.Color", "CreatedDate");
            DropColumn("dbo.Color", "UpdatedDate");
            DropColumn("dbo.Color", "CreatedIpAddress");
            DropColumn("dbo.Color", "CreatedUser");
            DropColumn("dbo.Color", "UpdatedIpAddress");
            DropColumn("dbo.Color", "UpdatedUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Color", "UpdatedUser", c => c.String(maxLength: 20));
            AddColumn("dbo.Color", "UpdatedIpAddress", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Color", "CreatedUser", c => c.String(maxLength: 20));
            AddColumn("dbo.Color", "CreatedIpAddress", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Color", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Color", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trademark", "UpdatedUser", c => c.String(maxLength: 20));
            AddColumn("dbo.Trademark", "UpdatedIpAddress", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Trademark", "CreatedUser", c => c.String(maxLength: 20));
            AddColumn("dbo.Trademark", "CreatedIpAddress", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Trademark", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Trademark", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Color", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Color", "LegacyCode", c => c.String(maxLength: 100));
            AlterColumn("dbo.Color", "Code", c => c.String(maxLength: 100));
            DropColumn("dbo.Color", "UpdaterUser");
            DropColumn("dbo.Color", "UpdaterIpAddress");
            DropColumn("dbo.Color", "UpdateDate");
            DropColumn("dbo.Color", "CreatorUser");
            DropColumn("dbo.Color", "CreatorIpAddress");
            DropColumn("dbo.Color", "CreationDate");
            DropColumn("dbo.Trademark", "UpdaterUser");
            DropColumn("dbo.Trademark", "UpdaterIpAddress");
            DropColumn("dbo.Trademark", "UpdateDate");
            DropColumn("dbo.Trademark", "CreatorUser");
            DropColumn("dbo.Trademark", "CreatorIpAddress");
            DropColumn("dbo.Trademark", "CreationDate");
        }
    }
}
