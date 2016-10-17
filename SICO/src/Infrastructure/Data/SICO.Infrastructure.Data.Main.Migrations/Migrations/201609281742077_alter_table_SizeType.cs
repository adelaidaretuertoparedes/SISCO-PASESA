namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_table_SizeType : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Size",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 100),
            //            Code = c.String(nullable: false, maxLength: 6),
            //            LegacyCode = c.String(nullable: false, maxLength: 3),
            //            Order = c.Int(nullable: false),
            //            IdSizeType = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            CreatorIpAddress = c.String(),
            //            CreatorUser = c.String(),
            //            Status = c.Boolean(nullable: false),
            //            UpdateDate = c.DateTime(),
            //            UpdaterIpAddress = c.String(),
            //            UpdaterUser = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.SizeType", t => t.IdSizeType)
            //    .Index(t => t.IdSizeType);
            
            //CreateTable(
            //    "dbo.SizeType",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            Code = c.String(maxLength: 6),
            //            LegacyCode = c.String(nullable: false, maxLength: 3),
            //            Active = c.Boolean(nullable: false),
            //            ClasificationId = c.Int(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            CreatorIpAddress = c.String(nullable: false, maxLength: 20),
            //            CreatorUser = c.String(nullable: false, maxLength: 20),
            //            Status = c.Boolean(nullable: false),
            //            UpdateDate = c.DateTime(),
            //            UpdaterIpAddress = c.String(maxLength: 20),
            //            UpdaterUser = c.String(maxLength: 20),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Classification", t => t.ClasificationId)
            //    .Index(t => t.ClasificationId);
            
            //CreateTable(
            //    "dbo.Classification",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Code = c.String(),
            //            CodeArticleGroup = c.String(),
            //            Name = c.String(),
            //            Description = c.String(),
            //            Active = c.Boolean(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            CreatorIpAddress = c.String(),
            //            CreatorUser = c.String(),
            //            Status = c.Boolean(nullable: false),
            //            UpdateDate = c.DateTime(),
            //            UpdaterIpAddress = c.String(),
            //            UpdaterUser = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
        //    DropForeignKey("dbo.Size", "IdSizeType", "dbo.SizeType");
        //    DropForeignKey("dbo.SizeType", "ClasificationId", "dbo.Classification");
        //    DropIndex("dbo.SizeType", new[] { "ClasificationId" });
        //    DropIndex("dbo.Size", new[] { "IdSizeType" });
        //    DropTable("dbo.Classification");
        //    DropTable("dbo.SizeType");
        //    DropTable("dbo.Size");
        }
    }
}
