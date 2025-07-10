namespace Proof.NET
{
    public class ProofClientOptions
    {
        public string? ApiKey { get; set; }

        public string? Endpoint { get; set; }

        public DocumentUrlVersion DefaultDocumentUrlVersion { get; init; } = DocumentUrlVersion.v2;

        public ProofEnvironment Environment { get; init; } = ProofEnvironment.Production;
    }

    public enum DocumentUrlVersion
    {
        v1,
        v2
    }

    public enum ProofEnvironment
    {
        Production,
        Sandbox,
    }
}
