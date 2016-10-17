namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Parameters_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parameter",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 200),
                        Status = c.Boolean(nullable: false),
                        Maintainable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParameterDetail",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        ParentParameterDetailId = c.Short(),
                        ParameterId = c.String(nullable: false, maxLength: 30),
                        Valor1 = c.String(maxLength: 100),
                        Valor2 = c.String(maxLength: 100),
                        Valor3 = c.String(maxLength: 100),
                        CreationDate = c.DateTime(nullable: false),
                        CreatorIpAddress = c.String(nullable: false, maxLength: 20),
                        CreatorUser = c.String(nullable: false, maxLength: 20),
                        Status = c.Boolean(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdaterIpAddress = c.String(maxLength: 20),
                        UpdaterUser = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parameter", t => t.ParameterId)
                .ForeignKey("dbo.ParameterDetail", t => t.ParentParameterDetailId)
                .Index(t => t.ParentParameterDetailId)
                .Index(t => t.ParameterId);     
           
        }
        
        public override void Down()
        {
          
        }
    }
}
