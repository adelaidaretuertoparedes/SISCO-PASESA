using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SICO.Application.Main.Colors
{
    public class UpdateColorDto : Core.ValidatableDtoBase<UpdateColorDto>
    {
        public int Id { get; set; }

        [Display(Name = "Color")]
        public string Name { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    List<ValidationResult> errors = new List<ValidationResult>();
        //    //if (!ActivitiAppSetting.InterferenciaAppDeployId.HasValue)
        //    //{
        //    //    errors.Add(
        //    //        new ValidationResult("No se ha configurado la identificador de despliegue del flujo para la aplicación interferencia,consulte administrador sistema.",
        //    //        new[] { "AppDeployId" }));
        //    //}
        //    //if (!ActivitiAppSetting.InterferenciaAppDefinitionId.HasValue)
        //    //{
        //    //    errors.Add(
        //    //        new ValidationResult("No se ha configurado la definición del flujo para la aplicación interferencia,consulte administrador sistema.",
        //    //        new[] { "AppDefinitionId" }));
        //    //}
        //    return errors;
        //}

    }
}
