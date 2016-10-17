using System.ComponentModel.DataAnnotations;

namespace SICO.Infrastructure.CrossCutting.Validations
{
    public static class ValidationContextExtension
    {
        public static T GetService<T>(this ValidationContext validationContext)
        {
            return (T)validationContext.GetService(typeof(T));
        }
    }
}
