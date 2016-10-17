namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Relations_Size : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Size", new[] { "SizeType_Id" });
            RenameColumn(table: "dbo.Size", name: "SizeType_Id", newName: "IdSizeType");
            AlterColumn("dbo.Size", "IdSizeType", c => c.Int(nullable: false));
            CreateIndex("dbo.Size", "IdSizeType");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Size", new[] { "IdSizeType" });
            AlterColumn("dbo.Size", "IdSizeType", c => c.Int());
            RenameColumn(table: "dbo.Size", name: "IdSizeType", newName: "SizeType_Id");
            CreateIndex("dbo.Size", "SizeType_Id");
        }
    }
}
