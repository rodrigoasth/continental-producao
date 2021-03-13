using System;
using System.Collections.Generic;
using System.Text;

namespace Continental.Producao.Domain.Core
{
    public class Money : ValueObject<Money>
    {
        public readonly double Value;

        public Money()
                : this(0)
        {
        }

        public Money(double value)
        {
            Value = value;
        }

        public Money Add(Money money)
        {
            return new Money(Value + money.Value);
        }

        public Money Subtract(Money money)
        {
            return new Money(Value - money.Value);
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<Object>() { Value };
        }
    }
}
