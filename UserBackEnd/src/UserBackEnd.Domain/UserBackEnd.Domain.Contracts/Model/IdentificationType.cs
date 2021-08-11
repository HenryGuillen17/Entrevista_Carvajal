namespace UserBackEnd.Domain.Contracts.Model
{
    public class IdentificationType : IBaseModelDomain
    {
        public short IdentificationTypeId { get; set; }
        public string Description { get; set; }
    }
}