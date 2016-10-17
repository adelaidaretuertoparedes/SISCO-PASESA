namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_DataType_Tables_Audit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParameterDetail", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.ParameterDetail", "CreatorUser", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.ParameterDetail", "UpdaterIpAddress", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.ParameterDetail", "UpdaterUser", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Trademark", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Trademark", "CreatorUser", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Trademark", "UpdaterIpAddress", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Trademark", "UpdaterUser", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.SizeType", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.SizeType", "CreatorUser", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.SizeType", "UpdaterIpAddress", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.SizeType", "UpdaterUser", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Classification", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Classification", "CreatorUser", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Classification", "UpdaterIpAddress", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Classification", "UpdaterUser", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Classification", "UpdaterUser", c => c.String(maxLength: 20));
            AlterColumn("dbo.Classification", "UpdaterIpAddress", c => c.String(maxLength: 20));
            AlterColumn("dbo.Classification", "CreatorUser", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Classification", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.SizeType", "UpdaterUser", c => c.String(maxLength: 20));
            AlterColumn("dbo.SizeType", "UpdaterIpAddress", c => c.String(maxLength: 20));
            AlterColumn("dbo.SizeType", "CreatorUser", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.SizeType", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Trademark", "UpdaterUser", c => c.String(maxLength: 20));
            AlterColumn("dbo.Trademark", "UpdaterIpAddress", c => c.String(maxLength: 20));
            AlterColumn("dbo.Trademark", "CreatorUser", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Trademark", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.ParameterDetail", "UpdaterUser", c => c.String(maxLength: 20));
            AlterColumn("dbo.ParameterDetail", "UpdaterIpAddress", c => c.String(maxLength: 20));
            AlterColumn("dbo.ParameterDetail", "CreatorUser", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.ParameterDetail", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
