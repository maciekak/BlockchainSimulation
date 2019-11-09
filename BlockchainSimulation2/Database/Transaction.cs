using System;

namespace BlockchainSimulation2.Database
{
    public class Transaction
    {
        public string Hash { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal MoneyAmount { get; set; }
        public double GasAmount { get; set; }

        public Client SourceClient { get; set; }
        public Client DestinationClient { get; set; }
        public Block Block { get; set; }
    }
}
