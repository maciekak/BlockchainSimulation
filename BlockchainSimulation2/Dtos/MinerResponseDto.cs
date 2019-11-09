using System;
using System.Collections.Generic;
using BlockchainSimulation2.Database;

namespace BlockchainSimulation2.Dtos
{
    public class MinerResponseDto
    {
        public string Hash { get; set; }
        public ClientType Type { get; set; }
        public decimal Amount { get; set; }
        public string StartDate { get; set; }

        public IEnumerable<string> TransactionsHashes { get; set; }
        public IEnumerable<string> MinedBlocksHashes { get; set; }
    }
}
