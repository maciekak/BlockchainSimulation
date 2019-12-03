using System;

namespace BlockchainSimulation2.Dtos
{
    public class TransactionResponseDto
    {
        public string Hash { get; set; }
        public string TransactionDate { get; set; }
        public string MoneyAmount { get; set; }
        public double GasAmount { get; set; }
        public bool IsNew { get; set; }
        public bool Updated { get; set; }

        public string SourceClientHash { get; set; }
        public string DestinationClientHash { get; set; }
        public string BlockHash { get; set; }
    }
}
