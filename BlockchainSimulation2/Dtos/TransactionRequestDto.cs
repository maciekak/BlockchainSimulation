using System;

namespace BlockchainSimulation2.Dtos
{
    public class TransactionRequestDto
    {
        public string Hash { get; set; }
        public DateTime TransactionDate { get; set; }
        public string MoneyAmount { get; set; }
        public double GasAmount { get; set; }

        public string SourceClientHash { get; set; }
        public string DestinationClientHash { get; set; }
        public string BlockHash { get; set; }
    }
}
