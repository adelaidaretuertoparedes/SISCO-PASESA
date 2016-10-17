namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Table_DetailSizeType : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Parameter",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 30),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            Description = c.String(maxLength: 200),
            //            Status = c.Boolean(nullable: false),
            //            Maintainable = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.ParameterDetail",
            //    c => new
            //        {
            //            Id = c.Short(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 200),
            //            ParentParameterDetailId = c.Short(),
            //            ParameterId = c.String(nullable: false, maxLength: 30),
            //            Valor1 = c.String(maxLength: 100),
            //            Valor2 = c.String(maxLength: 100),
            //            Valor3 = c.String(maxLength: 100),
            //            CreationDate = c.DateTime(nullable: false),
            //            CreatorIpAddress = c.String(nullable: false, maxLength: 20, unicode: false),
            //            CreatorUser = c.String(nullable: false, maxLength: 20, unicode: false),
            //            Status = c.Boolean(nullable: false),
            //            UpdateDate = c.DateTime(),
            //            UpdaterIpAddress = c.String(maxLength: 20, unicode: false),
            //            UpdaterUser = c.String(maxLength: 20, unicode: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Parameter", t => t.ParameterId)
            //    .ForeignKey("dbo.ParameterDetail", t => t.ParentParameterDetailId)
            //    .Index(t => t.ParentParameterDetailId)
            //    .Index(t => t.ParameterId);
            
            //CreateTable(
            //    "dbo.ArticleGroup",
            //    c => new
            //        {
            //            Id = c.Short(nullable: false),
            //            Name = c.String(nullable: false, maxLength: 200),
            //            Code = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Size",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            Code = c.String(maxLength: 6, unicode: false),
            //            LegacyCode = c.String(nullable: false, maxLength: 3, unicode: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            CreatorIpAddress = c.String(),
            //            CreatorUser = c.String(),
            //            Status = c.Boolean(nullable: false),
            //            UpdateDate = c.DateTime(),
            //            UpdaterIpAddress = c.String(),
            //            UpdaterUser = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetailSizeType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SizeId = c.Int(nullable: false),
                        SizeTypeId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CreatorIpAddress = c.String(nullable: false, maxLength: 20, unicode: false),
                        CreatorUser = c.String(nullable: false, maxLength: 20, unicode: false),
                        Status = c.Boolean(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdaterIpAddress = c.String(maxLength: 20, unicode: false),
                        UpdaterUser = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Size", t => t.SizeId)
                .ForeignKey("dbo.SizeType", t => t.SizeTypeId)
                .Index(t => t.SizeId)
                .Index(t => t.SizeTypeId);
            
            //CreateTable(
            //    "dbo.SizeType",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            Code = c.String(maxLength: 6, unicode: false),
            //            LegacyCode = c.String(nullable: false, maxLength: 3, unicode: false),
            //            Description = c.String(nullable: false, maxLength: 100, unicode: false),
            //            CreationDate = c.DateTime(nullable: false),
            //            CreatorIpAddress = c.String(nullable: false, maxLength: 20, unicode: false),
            //            CreatorUser = c.String(nullable: false, maxLength: 20, unicode: false),
            //            Status = c.Boolean(nullable: false),
            //            UpdateDate = c.DateTime(),
            //            UpdaterIpAddress = c.String(maxLength: 20, unicode: false),
            //            UpdaterUser = c.String(maxLength: 20, unicode: false),
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
            //            CreatorIpAddress = c.String(nullable: false, maxLength: 20, unicode: false),
            //            CreatorUser = c.String(nullable: false, maxLength: 20, unicode: false),
            //            Status = c.Boolean(nullable: false),
            //            UpdateDate = c.DateTime(),
            //            UpdaterIpAddress = c.String(maxLength: 20, unicode: false),
            //            UpdaterUser = c.String(maxLength: 20, unicode: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //AlterColumn("dbo.Trademark", "Code", c => c.String(maxLength: 6));
            //AlterColumn("dbo.Trademark", "Name", c => c.String());
            //AlterColumn("dbo.Trademark", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20, unicode: false));
            //AlterColumn("dbo.Trademark", "CreatorUser", c => c.String(nullable: false, maxLength: 20, unicode: false));
            //AlterColumn("dbo.Trademark", "UpdaterIpAddress", c => c.String(maxLength: 20, unicode: false));
            //AlterColumn("dbo.Trademark", "UpdaterUser", c => c.String(maxLength: 20, unicode: false));
            //AlterColumn("dbo.Color", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20, unicode: false));
            //AlterColumn("dbo.Color", "CreatorUser", c => c.String(nullable: false, maxLength: 20, unicode: false));
            //AlterColumn("dbo.Color", "UpdaterIpAddress", c => c.String(maxLength: 20, unicode: false));
            //AlterColumn("dbo.Color", "UpdaterUser", c => c.String(maxLength: 20, unicode: false));
            //DropColumn("dbo.Trademark", "LegacyCode");
            //DropColumn("dbo.Trademark", "ShortName");
            //DropColumn("dbo.Trademark", "Owner");
            //DropColumn("dbo.Trademark", "Active");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Trademark", "Active", c => c.Boolean(nullable: false));
            //AddColumn("dbo.Trademark", "Owner", c => c.String(maxLength: 100));
            //AddColumn("dbo.Trademark", "ShortName", c => c.String(maxLength: 50));
            //AddColumn("dbo.Trademark", "LegacyCode", c => c.String(nullable: false, maxLength: 2));
            //DropForeignKey("dbo.DetailSizeType", "SizeTypeId", "dbo.SizeType");
            //DropForeignKey("dbo.DetailSizeType", "SizeId", "dbo.Size");
            //DropForeignKey("dbo.ParameterDetail", "ParentParameterDetailId", "dbo.ParameterDetail");
            //DropForeignKey("dbo.ParameterDetail", "ParameterId", "dbo.Parameter");
            //DropIndex("dbo.DetailSizeType", new[] { "SizeTypeId" });
            //DropIndex("dbo.DetailSizeType", new[] { "SizeId" });
            //DropIndex("dbo.ParameterDetail", new[] { "ParameterId" });
            //DropIndex("dbo.ParameterDetail", new[] { "ParentParameterDetailId" });
            //AlterColumn("dbo.Color", "UpdaterUser", c => c.String(maxLength: 20));
            //AlterColumn("dbo.Color", "UpdaterIpAddress", c => c.String(maxLength: 20));
            //AlterColumn("dbo.Color", "CreatorUser", c => c.String(nullable: false, maxLength: 20));
            //AlterColumn("dbo.Color", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20));
            //AlterColumn("dbo.Trademark", "UpdaterUser", c => c.String(maxLength: 20));
            //AlterColumn("dbo.Trademark", "UpdaterIpAddress", c => c.String(maxLength: 20));
            //AlterColumn("dbo.Trademark", "CreatorUser", c => c.String(nullable: false, maxLength: 20));
            //AlterColumn("dbo.Trademark", "CreatorIpAddress", c => c.String(nullable: false, maxLength: 20));
            //AlterColumn("dbo.Trademark", "Name", c => c.String(nullable: false, maxLength: 50));
            //AlterColumn("dbo.Trademark", "Code", c => c.String(nullable: false, maxLength: 6));
            //DropTable("dbo.Classification");
            //DropTable("dbo.TableParameter");
            //DropTable("dbo.SizeType");
            //DropTable("dbo.DetailSizeType");
            //DropTable("dbo.Size");
            //DropTable("dbo.ArticleGroup");
            //DropTable("dbo.ParameterDetail");
            //DropTable("dbo.Parameter");
        }
    }
}
