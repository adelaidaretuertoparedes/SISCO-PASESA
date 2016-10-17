namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_columns_name3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trademark",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        codigo = c.String(),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        CreatedIpAddress = c.String(nullable: false, maxLength: 20),
                        CreatedUser = c.String(maxLength: 20),
                        UpdatedIpAddress = c.String(nullable: false, maxLength: 20),
                        UpdatedUser = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Size",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Code = c.String(nullable: false, maxLength: 6),
                        LegacyCode = c.String(nullable: false, maxLength: 3),
                        Order = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        CreatedIpAddress = c.String(),
                        CreatedUser = c.String(),
                        UpdatedIpAddress = c.String(),
                        UpdatedUser = c.String(),
                        SizeType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SizeType", t => t.SizeType_Id)
                .Index(t => t.SizeType_Id);
            
            CreateTable(
                "dbo.SizeType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false, maxLength: 5),
                        LegacyCode = c.String(nullable: false, maxLength: 3),
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
            DropForeignKey("dbo.Size", "SizeType_Id", "dbo.SizeType");
            DropIndex("dbo.Size", new[] { "SizeType_Id" });
            DropTable("dbo.SizeType");
            DropTable("dbo.Size");
            DropTable("dbo.Trademark");
        }
    }
}
