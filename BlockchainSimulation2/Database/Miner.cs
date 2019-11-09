using System;
using System.Collections.Generic;

namespace BlockchainSimulation2.Database
{
    public class Miner
    {
        public string Hash { get; set; }
        public ClientType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Block> MinedBlocks { get; set; }
    }
}
