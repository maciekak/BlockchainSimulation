﻿using System;
using System.Collections.Generic;

namespace BlockchainSimulation2.Dtos
{
    public class BlockRequestDto
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public DateTime MinedDate { get; set; }
        public int TransactionCount { get; set; }
        public double Size { get; set; }
        public double GasAmount { get; set; }
        public decimal AwardForMining { get; set; }
        public decimal TotalSentAmount { get; set; }
        public decimal TotalReceivedAmount { get; set; }
        public decimal TotalBalance { get; set; }

        public string MinerHash { get; set; }
        public string ParentHash { get; set; }
        public IEnumerable<string> TransactionsHashes { get; set; }
    }
}
