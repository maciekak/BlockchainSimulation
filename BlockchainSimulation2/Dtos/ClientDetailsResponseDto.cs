using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockchainSimulation2.Database;

namespace BlockchainSimulation2.Dtos
{
    public class ClientDetailsResponseDto
    {
        public string Hash { get; set; }
        public ClientType Type { get; set; }
        public string Amount { get; set; }
        public string StartDate { get; set; }
        public bool IsNew { get; set; }
        public bool Updated { get; set; }

        public int TransactionsCount { get; set; }
        public IEnumerable<TransactionSimpleResponseDto> TransactionsHashes { get; set; }
        public int MinedBlocksCount { get; set; }
        public IEnumerable<BlockSimpleResponseDto> MinedBlocksHashes { get; set; }
    }
}
