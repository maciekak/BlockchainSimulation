using System;
using System.Collections.Generic;

namespace BlockchainSimulation2.Database
{
    public class Block
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public DateTime MinedDate { get; set; }
        public int TransactionCount { get; set; }
        public double Size { get; set; }
        public double GasAmount { get; set; }
        public string AwardForMining { get; set; }
        public string TotalSentAmount { get; set; }
        public string TotalReceivedAmount { get; set; }
        public string TotalBalance { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Client Miner { get; set; }
        public Block ParentBlock { get; set; }
        public Block ChildBlock { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
