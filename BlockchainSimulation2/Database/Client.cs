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
        public bool IsNew { get; set; }
        public bool Updated { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Block> MinedBlocks { get; set; }
    }
}
