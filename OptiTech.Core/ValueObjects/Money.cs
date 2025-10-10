using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiTech.Core.ValueObjects
{
    public class Money
    {
        public Money(decimal amount, string currency = "BRL")
        {
            if (amount < 0) throw new ArgumentException("Amount cannot be negative");
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; private set; }
        public string Currency { get; private set; }

        public Money Add(Money other)
        {
            if (Currency != other.Currency) throw new InvalidOperationException("Currencies must match");

            return new Money(Amount + other.Amount, Currency);
        }
    }
}
