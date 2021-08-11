namespace UserBackEnd.Infraestructure.Contracts.Entities
{
    public class UserEntity : IBaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public short IdentificationTypeId { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual IdentificationTypeEntity IdentificationTypeEntity { get; set; }
    }
}
