using System;
using System.Collections.Generic;

namespace BlockchainSimulation2.Dtos
{
    public class BlockResponseDto
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public string MinedDate { get; set; }
        public int TransactionCount { get; set; }
        public double Size { get; set; }
        public decimal AwardForMining { get; set; }
        public decimal TotalSentAmount { get; set; }
        public decimal TotalReceivedAmount { get; set; }
        public decimal TotalBalance { get; set; }

        public string MinerHash { get; set; }
        public IEnumerable<string> TransactionsHashes { get; set; }
    }
}
