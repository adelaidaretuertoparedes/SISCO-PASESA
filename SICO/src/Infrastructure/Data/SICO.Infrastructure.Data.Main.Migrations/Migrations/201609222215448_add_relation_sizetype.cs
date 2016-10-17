namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_relation_sizetype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        CodeArticleGroup = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        CreatedIpAddress = c.String(),
                        CreatedUser = c.String(),
                        UpdatedIpAddress = c.String(),
                        UpdatedUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SizeType", "IdClasification", c => c.Int(nullable: false));
            CreateIndex("dbo.SizeType", "IdClasification");
            AddForeignKey("dbo.SizeType", "IdClasification", "dbo.Classification", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SizeType", "IdClasification", "dbo.Classification");
            DropIndex("dbo.SizeType", new[] { "IdClasification" });
            DropColumn("dbo.SizeType", "IdClasification");
            DropTable("dbo.Classification");
        }
    }
}
