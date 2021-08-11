using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserBackEnd.Infraestructure.Contracts.Entities;

namespace UserBackEnd.Infraestructure.EntityConfig
{
    public static class UserEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<UserEntity> entityBuilder)
        {
            entityBuilder.ToTable("Users");
            entityBuilder.HasKey(x => x.UserId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            entityBuilder.Property(x => x.LastName).IsRequired().HasMaxLength(64);
            entityBuilder.Property(x => x.IdentificationTypeId).IsRequired();
            entityBuilder.Property(x => x.IdentificationNumber).IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Email).IsRequired().HasMaxLength(60);
            entityBuilder.Property(x => x.Password).IsRequired().HasMaxLength(500);

            entityBuilder.HasOne(x => x.IdentificationTypeEntity)
                .WithMany(x => x.UserEntities)
                .HasForeignKey(x => x.IdentificationTypeId);
        }
    }
}