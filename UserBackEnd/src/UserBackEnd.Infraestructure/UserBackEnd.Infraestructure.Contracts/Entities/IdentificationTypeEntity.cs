using System.Collections.Generic;

namespace UserBackEnd.Infraestructure.Contracts.Entities
{
    public class IdentificationTypeEntity : IBaseEntity
    {
        public short IdentificationTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserEntity> UserEntities { get; set; }
    }
}