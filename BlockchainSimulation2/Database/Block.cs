using System;
using System.Collections.Generic;

namespace BlockchainSimulation2.Database
{
    public class Block
    {
        public string Hash { get; set; }
        public DateTime Mined { get; set; }
        public int TransactionCount { get; set; }
        public double Size { get; set; }
        public decimal AwardForMining { get; set; }
        public decimal TotalSentAmount { get; set; }
        public decimal TotalReceivedAmount { get; set; }
        public decimal TotalBalance { get; set; }

        public Miner Miner { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
