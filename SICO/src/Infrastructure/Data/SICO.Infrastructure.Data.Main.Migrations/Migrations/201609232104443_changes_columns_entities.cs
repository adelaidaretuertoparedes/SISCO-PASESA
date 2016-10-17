namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes_columns_entities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trademark", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trademark", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Trademark", "CreatorUser", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Trademark", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Trademark", "UpdaterIpAddress", c => c.String(maxLength: 20));
            AddColumn("dbo.Trademark", "UpdaterUser", c => c.String(maxLength: 20));
            AddColumn("dbo.SizeType", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SizeType", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.SizeType", "CreatorUser", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.SizeType", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.SizeType", "UpdaterIpAddress", c => c.String(maxLength: 20));
            AddColumn("dbo.SizeType", "UpdaterUser", c => c.String(maxLength: 20));
            AddColumn("dbo.Classification", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Classification", "CreatorIpAddress", c => c.String());
            AddColumn("dbo.Classification", "CreatorUser", c => c.String());
            AddColumn("dbo.Classification", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Classification", "UpdaterIpAddress", c => c.String());
            AddColumn("dbo.Classification", "UpdaterUser", c => c.String());
            AddColumn("dbo.Size", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Size", "CreatorIpAddress", c => c.String());
            AddColumn("dbo.Size", "CreatorUser", c => c.String());
            AddColumn("dbo.Size", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Size", "UpdaterIpAddress", c => c.String());
            AddColumn("dbo.Size", "UpdaterUser", c => c.String());
            DropColumn("dbo.Trademark", "CreatedDate");
            DropColumn("dbo.Trademark", "UpdatedDate");
            DropColumn("dbo.Trademark", "CreatedIpAddress");
            DropColumn("dbo.Trademark", "CreatedUser");
            DropColumn("dbo.Trademark", "UpdatedIpAddress");
            DropColumn("dbo.Trademark", "UpdatedUser");
            DropColumn("dbo.SizeType", "CreatedDate");
            DropColumn("dbo.SizeType", "UpdatedDate");
            DropColumn("dbo.SizeType", "CreatedIpAddress");
            DropColumn("dbo.SizeType", "CreatedUser");
            DropColumn("dbo.SizeType", "UpdatedIpAddress");
            DropColumn("dbo.SizeType", "UpdatedUser");
            DropColumn("dbo.Classification", "CreatedDate");
            DropColumn("dbo.Classification", "UpdatedDate");
            DropColumn("dbo.Classification", "CreatedIpAddress");
            DropColumn("dbo.Classification", "CreatedUser");
            DropColumn("dbo.Classification", "UpdatedIpAddress");
            DropColumn("dbo.Classification", "UpdatedUser");
            DropColumn("dbo.Size", "CreatedDate");
            DropColumn("dbo.Size", "UpdatedDate");
            DropColumn("dbo.Size", "CreatedIpAddress");
            DropColumn("dbo.Size", "CreatedUser");
            DropColumn("dbo.Size", "UpdatedIpAddress");
            DropColumn("dbo.Size", "UpdatedUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Size", "UpdatedUser", c => c.String());
            AddColumn("dbo.Size", "UpdatedIpAddress", c => c.String());
            AddColumn("dbo.Size", "CreatedUser", c => c.String());
            AddColumn("dbo.Size", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.Size", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Size", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Classification", "UpdatedUser", c => c.String());
            AddColumn("dbo.Classification", "UpdatedIpAddress", c => c.String());
            AddColumn("dbo.Classification", "CreatedUser", c => c.String());
            AddColumn("dbo.Classification", "CreatedIpAddress", c => c.String());
            AddColumn("dbo.Classification", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Classification", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SizeType", "UpdatedUser", c => c.String(maxLength: 20));
            AddColumn("dbo.SizeType", "UpdatedIpAddress", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.SizeType", "CreatedUser", c => c.String(maxLength: 20));
            AddColumn("dbo.SizeType", "CreatedIpAddress", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.SizeType", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.SizeType", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trademark", "UpdatedUser", c => c.String(maxLength: 20));
            AddColumn("dbo.Trademark", "UpdatedIpAddress", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Trademark", "CreatedUser", c => c.String(maxLength: 20));
            AddColumn("dbo.Trademark", "CreatedIpAddress", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Trademark", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Trademark", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Size", "UpdaterUser");
            DropColumn("dbo.Size", "UpdaterIpAddress");
            DropColumn("dbo.Size", "UpdateDate");
            DropColumn("dbo.Size", "CreatorUser");
            DropColumn("dbo.Size", "CreatorIpAddress");
            DropColumn("dbo.Size", "CreationDate");
            DropColumn("dbo.Classification", "UpdaterUser");
            DropColumn("dbo.Classification", "UpdaterIpAddress");
            DropColumn("dbo.Classification", "UpdateDate");
            DropColumn("dbo.Classification", "CreatorUser");
            DropColumn("dbo.Classification", "CreatorIpAddress");
            DropColumn("dbo.Classification", "CreationDate");
            DropColumn("dbo.SizeType", "UpdaterUser");
            DropColumn("dbo.SizeType", "UpdaterIpAddress");
            DropColumn("dbo.SizeType", "UpdateDate");
            DropColumn("dbo.SizeType", "CreatorUser");
            DropColumn("dbo.SizeType", "CreatorIpAddress");
            DropColumn("dbo.SizeType", "CreationDate");
            DropColumn("dbo.Trademark", "UpdaterUser");
            DropColumn("dbo.Trademark", "UpdaterIpAddress");
            DropColumn("dbo.Trademark", "UpdateDate");
            DropColumn("dbo.Trademark", "CreatorUser");
            DropColumn("dbo.Trademark", "CreatorIpAddress");
            DropColumn("dbo.Trademark", "CreationDate");
        }
    }
}
