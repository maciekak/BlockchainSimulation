using System;
using System.Collections.Generic;

namespace BlockchainSimulation2.Dtos
{
    public class BlockResponseDto
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public string MinedDate { get; set; }
        public double Size { get; set; }
        public double GasAmount { get; set; }
        public string AwardForMining { get; set; }
        public string TotalSentAmount { get; set; }
        public string TotalReceivedAmount { get; set; }
        public string TotalBalance { get; set; }
        public bool IsNew { get; set; }
        public bool Updated { get; set; }

        public string MinerHash { get; set; }
        public string ParentHash { get; set; }
        public string ChildHash { get; set; }
        public int TransactionCount { get; set; }
        public IEnumerable<string> TransactionsHashes { get; set; }
    }
}
