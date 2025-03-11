using System;
using System.Text.Json.Serialization;

namespace Proof.NET
{
    [JsonConverter(typeof(EnumerationJsonConverter))]
    public readonly struct TransactionPayer : IEnumeration<string>, IEquatable<TransactionPayer>
    {
        private readonly string _value;

        public static readonly TransactionPayer Signer = new("signer");

        public static readonly TransactionPayer Sender = new("sender");

        string IEnumeration<string>.Value => _value;

        public TransactionPayer(string value)
        {
            _value = value;
        }

        public bool Equals(string other)
        {
            return _value.Equals(other);
        }

        public bool Equals(TransactionPayer other)
        {
            return Equals(other._value);
        }

        public override bool Equals(object obj)
        {
            if (obj is string otherValue)
            {
                return Equals(otherValue);
            }
            else if (obj is TransactionPayer otherPayer)
            {
                return Equals(otherPayer);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return _value;
        }

        public static implicit operator string(TransactionPayer payer)
        {
            return payer._value;
        }
    }
}
