using System.Text.Json.Serialization;

namespace Proof.NET
{
    [JsonConverter(typeof(EnumerationJsonConverter))]
    public readonly struct DocumentRequirement : IEnumeration<string>
    {
        private readonly string _value;

        public static readonly DocumentRequirement Notarization = new("notarization");

        public static readonly DocumentRequirement ESign = new("esign");

        public static readonly DocumentRequirement IdentityConfirmation = new("identity_confirmation");

        public static readonly DocumentRequirement ReadOnly = new("readonly");

        public static readonly DocumentRequirement NonEssential = new("non_essential");

        public DocumentRequirement(string value)
        {
            _value = value;
        }

        string IEnumeration<string>.Value => _value;

        public bool Equals(string other)
        {
            return _value.Equals(other);
        }

        public bool Equals(DocumentRequirement other)
        {
            return Equals(other._value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is string otherValue)
            {
                return Equals(otherValue);
            }
            else if (obj is DocumentRequirement otherRequirement)
            {
                return Equals(otherRequirement);
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

        public static implicit operator string(DocumentRequirement documentRequirement) => documentRequirement._value;
    }

}
