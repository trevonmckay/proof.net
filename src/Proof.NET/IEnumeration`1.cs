using System;

namespace Proof.NET
{
    internal interface IEnumeration<TValue> : IEquatable<TValue>
    {
        TValue Value { get; }
    }
}
