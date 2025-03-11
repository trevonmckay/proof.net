using System;
using System.Collections.Generic;

namespace Proof.NET
{
    public class CreateTransactionRequest
    {
        public DateTimeOffset? ActivationTime { get; set; }

        public TransactionSigner? Signer { get; set; }

        public IEnumerable<TransactionSigner>? Signers { get; set; }

        public bool? Draft { get; set; }

        public TransactionPayer? Payer { get; set; }

        public string? ExternalId { get; set; }

        public string? TransactionName { get; set; }

        public string? MessageToSigner { get; set; }

        public string? TransactionType { get; set; }

        public string? MessageSubject { get; set; }

        public string? MessageSignature { get; set; }

        public bool? PdfBookmarked { get; set; }

        public bool? RequireSecondaryPhotoId { get; set; }

        public bool? SuppressEmail { get; set; }

        public TransactionAuthenticationRequirement? AuthenticationRequirement { get; set; }

        public bool? RequireNewSignerVerification { get; set; }

        public IEnumerable<NotaryInstruction>? NotaryInstructions { get; set; }

        public TransactionRedirect? Redirect { get; set; }

        public string? NotaryId { get; set; }

        public DateTimeOffset? NotaryMeetingTime { get; set; }

        public bool? DocumentUrlVersion { get; set; }

        public IEnumerable<string>? Documents { get; set; }

        public string? Document { get; set; }

        public IEnumerable<string>? CcRecipientEmails { get; set; }
    }
}
