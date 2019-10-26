using System;

namespace BlockchainSimulation2.Dtos
{
    public class TransactionResponseDto
    {
        public int Hash { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public string SourceClientHash { get; set; }
        public string DestinationClientHash { get; set; }
        public string BlockHash { get; set; }
    }
}
