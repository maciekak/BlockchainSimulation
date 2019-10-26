using System;

namespace BlockchainSimulation2.Database
{
    public class Transaction
    {
        public string Hash { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public Miner SourceClient { get; set; }
        public Miner DestinationClient { get; set; }
        public Block Block { get; set; }
    }
}
