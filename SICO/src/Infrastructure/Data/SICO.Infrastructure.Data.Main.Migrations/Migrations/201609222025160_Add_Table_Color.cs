namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Table_Color : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 100),
                        LegacyCode = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        Active = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        CreatedIpAddress = c.String(nullable: false, maxLength: 20),
                        CreatedUser = c.String(maxLength: 20),
                        UpdatedIpAddress = c.String(nullable: false, maxLength: 20),
                        UpdatedUser = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Color");
        }
    }
}
