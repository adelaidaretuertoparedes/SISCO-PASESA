// <auto-generated />
namespace SICO.Infrastructure.Data.Main.Migrations.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class Add_Relations_Size : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Add_Relations_Size));
        
        string IMigrationMetadata.Id
        {
            get { return "201609222112088_Add_Relations_Size"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return "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"; }
        }
    }
}
