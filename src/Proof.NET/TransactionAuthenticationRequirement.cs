using System;

namespace Proof.NET
{
    public readonly struct TransactionAuthenticationRequirement : IEnumeration<string>, IEquatable<TransactionAuthenticationRequirement>
    {
        private readonly string _value;

        public static readonly TransactionAuthenticationRequirement None = new("none");

        public static readonly TransactionAuthenticationRequirement Sms = new("sms");

        string IEnumeration<string>.Value => _value;

        public TransactionAuthenticationRequirement(string value)
        {
            _value = value;
        }

        public bool Equals(string other)
        {
            return _value.Equals(other);
        }

        public bool Equals(TransactionAuthenticationRequirement other)
        {
            return Equals(other._value);
        }

        public override bool Equals(object obj)
        {
            if (obj is string otherValue)
            {
                return Equals(otherValue);
            }
            else if (obj is TransactionAuthenticationRequirement otherRequirement)
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

        public static implicit operator string(TransactionAuthenticationRequirement requirement)
        {
            return requirement._value;
        }
    }
}
