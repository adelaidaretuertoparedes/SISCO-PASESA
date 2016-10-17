namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Drop_Column_Active_Color : DbMigration
    {
        public override void Up()
        {
          
            DropColumn("dbo.Color", "Active");
        }
        
        public override void Down()
        {
            
        }
    }
}
