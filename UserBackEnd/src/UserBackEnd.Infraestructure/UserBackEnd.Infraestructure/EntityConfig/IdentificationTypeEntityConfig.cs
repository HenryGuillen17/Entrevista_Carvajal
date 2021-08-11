using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserBackEnd.Infraestructure.Contracts.Entities;

namespace UserBackEnd.Infraestructure.EntityConfig
{
    public static class IdentificationTypeEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<IdentificationTypeEntity> entityBuilder)
        {
            entityBuilder.ToTable("IdentificationTypes");
            entityBuilder.HasKey(x => x.IdentificationTypeId);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(45);
        }
    }
}
