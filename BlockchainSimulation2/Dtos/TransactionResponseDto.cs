using System;

namespace BlockchainSimulation2.Dtos
{
    public class TransactionResponseDto
    {
        public string Hash { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }

        public string SourceClientHash { get; set; }
        public string DestinationClientHash { get; set; }
        public string BlockHash { get; set; }
    }
}
