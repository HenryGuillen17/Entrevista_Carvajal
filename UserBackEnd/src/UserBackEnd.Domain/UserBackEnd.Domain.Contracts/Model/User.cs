namespace UserBackEnd.Domain.Contracts.Model
{
    public class User : IBaseModelDomain
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public short IdentificationTypeId { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
