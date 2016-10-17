namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Columns_Trademark : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trademark", "Code", c => c.String(nullable: false, maxLength: 6));
            AddColumn("dbo.Trademark", "ShortName", c => c.String(maxLength: 100));
            AddColumn("dbo.Trademark", "Owner", c => c.String(maxLength: 150));
            AddColumn("dbo.Trademark", "Active", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Trademark", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trademark", "Name", c => c.String());
            DropColumn("dbo.Trademark", "Active");
            DropColumn("dbo.Trademark", "Owner");
            DropColumn("dbo.Trademark", "ShortName");
            DropColumn("dbo.Trademark", "Code");
        }
    }
}
