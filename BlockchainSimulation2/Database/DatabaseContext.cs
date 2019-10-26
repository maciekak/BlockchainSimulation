using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace BlockchainSimulation2.Database
{
    public class DatabaseContext
    {
        private const string TransactionsKey = "transactions";
        private const string BlocksKey = "blocks";
        private const string MinersKey = "miners";

        private readonly IMemoryCache _memoryCache;

        public DatabaseContext(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;

            _memoryCache.Set(TransactionsKey, new List<Transaction>());
            _memoryCache.Set(BlocksKey, new List<Block>());
            _memoryCache.Set(MinersKey, new List<Miner>());
        }

        public ICollection<Transaction> Transactions => (ICollection<Transaction>) _memoryCache.Get(TransactionsKey);

        public ICollection<Block> Blocks => (ICollection<Block>)_memoryCache.Get(BlocksKey);

        public ICollection<Miner> Miners => (ICollection<Miner>)_memoryCache.Get(MinersKey);
    }
}
