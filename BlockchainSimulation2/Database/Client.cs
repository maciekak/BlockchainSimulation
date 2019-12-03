using System;
using System.Collections.Generic;

namespace BlockchainSimulation2.Database
{
    public class Client
    {
        public string Hash { get; set; }
        public ClientType Type { get; set; }
        public string Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Block> MinedBlocks { get; set; }
    }
}
