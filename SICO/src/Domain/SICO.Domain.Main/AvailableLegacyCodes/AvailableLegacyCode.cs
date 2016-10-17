using SICO.Domain.Core;

namespace SICO.Domain.Main.AvailableLegacyCodes
{
    public class AvailableLegacyCode: AuditEntityBase
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int TypeId { get; set; }

        public string Type { get; set; }

    }
}
