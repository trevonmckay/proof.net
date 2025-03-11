namespace Proof.NET
{
    public class TransactionSigner
    {
        public uint? Order { get; set; }

        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? ExternalId { get; set; }

        public string? Entity { get; set; }

        public string? Capacity { get; set; }

        public bool? PersonallyKnownToNotary { get; set; }

        public string? SigningStatus { get; set; }
    }
}
