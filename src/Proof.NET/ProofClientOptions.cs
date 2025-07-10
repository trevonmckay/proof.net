namespace Proof.NET
{
    public class ProofClientOptions
    {
        public string? ApiKey { get; set; }

        public string? Endpoint { get; set; }
    }

    public enum DocumentUrlVersion
    {
        v1,
        v2
    }
}
