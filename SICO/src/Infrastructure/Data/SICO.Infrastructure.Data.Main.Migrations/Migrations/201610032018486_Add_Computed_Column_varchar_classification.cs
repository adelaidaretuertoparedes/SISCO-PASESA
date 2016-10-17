namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Computed_Column_varchar_classification : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Trademark",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Code = c.String(maxLength: 6),
            //            CreationDate = c.DateTime(nullable: false),
            //            CreatorIpAddress = c.String(nullable: false, maxLength: 20),
            //            CreatorUser = c.String(nullable: false, maxLength: 20),
            //            Status = c.Boolean(nullable: false),
            //            UpdateDate = c.DateTime(),
            //            UpdaterIpAddress = c.String(maxLength: 20),
            //            UpdaterUser = c.String(maxLength: 20),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AvailableLegacyCode",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Code = c.String(nullable: false, maxLength: 10, unicode: false),
            //            IdType = c.Int(nullable: false),
            //            Type = c.String(nullable: false, maxLength: 20, unicode: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.TableParameter",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            IdTable = c.String(nullable: false, maxLength: 20, unicode: false),
            //            Description = c.String(nullable: false, maxLength: 100, unicode: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            CreatorIpAddress = c.String(),
            //            CreatorUser = c.String(),
            //            Status = c.Boolean(nullable: false),
            //            UpdateDate = c.DateTime(),
            //            UpdaterIpAddress = c.String(),
            //            UpdaterUser = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Classification",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Code = c.String(nullable: false, maxLength: 5, unicode: false),
            //            ArticleGroupCode = c.String(nullable: false, maxLength: 100, unicode: false),
            //            Name = c.String(nullable: false, maxLength: 50, unicode: false),
            //            Active = c.Boolean(nullable: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            CreatorIpAddress = c.String(nullable: false, maxLength: 20),
            //            CreatorUser = c.String(nullable: false, maxLength: 20),
            //            Status = c.Boolean(nullable: false),
            //            UpdateDate = c.DateTime(),
            //            UpdaterIpAddress = c.String(maxLength: 20),
            //            UpdaterUser = c.String(maxLength: 20),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.Classification");
            //DropTable("dbo.TableParameter");
            //DropTable("dbo.AvailableLegacyCode");
            //DropTable("dbo.Trademark");
        }
    }
}
