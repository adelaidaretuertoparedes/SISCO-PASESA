using SICO.Domain.Main.ParameterDetails;
using SICO.Infrastructure.Data.Core;

namespace SICO.Infrastructure.Data.Main.Configurations
{
    public class ParameterDetailConfiguration : EntityConfigurationBase<ParameterDetail>
    {
        public ParameterDetailConfiguration()
        {
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);
                        
            Property(x => x.Valor1)
                .IsOptional()
                .HasMaxLength(100);

            Property(x => x.Valor2)
                .IsOptional()
                .HasMaxLength(100);            

            Property(x => x.Valor3)
                .IsOptional()
                .HasMaxLength(100);            

            HasRequired(x => x.Parameter)
                .WithMany(x => x.ParameterDetails)
                .HasForeignKey(x => x.ParameterId);

            HasOptional(x => x.ParentParameterDetail)
                .WithMany(x => x.ChildParameterDetails)
                .HasForeignKey(x => x.ParentParameterDetailId)
                .WillCascadeOnDelete(false);
        }
    }
}
