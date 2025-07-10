namespace Proof.NET
{
    public record ProofClientOptions
    {
        public string? ApiKey { get; init; }

        public string? Endpoint { get; init; }

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
