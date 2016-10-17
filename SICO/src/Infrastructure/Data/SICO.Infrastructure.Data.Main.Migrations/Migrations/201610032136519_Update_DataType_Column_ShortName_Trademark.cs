namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_DataType_Column_ShortName_Trademark : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trademark", "ShortName", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trademark", "ShortName", c => c.String(maxLength: 50));
        }
    }
}
