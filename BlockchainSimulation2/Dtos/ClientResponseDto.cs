using System;
using System.Collections.Generic;
using BlockchainSimulation2.Database;

namespace BlockchainSimulation2.Dtos
{
    public class ClientResponseDto
    {
        public string Hash { get; set; }
        public ClientType Type { get; set; }
        public string Amount { get; set; }
        public string StartDate { get; set; }
        public bool IsNew { get; set; }
        public bool Updated { get; set; }

        public int TransactionsCount { get; set; }
        public IEnumerable<string> TransactionsHashes { get; set; }
        public int MinedBlocksCount { get; set; }
        public IEnumerable<string> MinedBlocksHashes { get; set; }
    }
}
