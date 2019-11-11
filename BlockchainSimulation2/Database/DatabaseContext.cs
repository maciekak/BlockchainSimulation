using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace BlockchainSimulation2.Database
{
    public class DatabaseContext
    {
        private const string TransactionsKey = "transactions";
        private const string BlocksKey = "blocks";
        private const string ClientsKey = "clients";

        private readonly IMemoryCache _memoryCache;

        private int _counter = 1;

        public DatabaseContext(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;

            _memoryCache.Set(TransactionsKey, new List<Transaction>());
            _memoryCache.Set(BlocksKey, new List<Block>());
            _memoryCache.Set(ClientsKey, new List<Client>());
        }

        public ICollection<Transaction> Transactions => (ICollection<Transaction>) _memoryCache.Get(TransactionsKey);

        public ICollection<Block> Blocks => (ICollection<Block>)_memoryCache.Get(BlocksKey);

        public ICollection<Client> Clients => (ICollection<Client>)_memoryCache.Get(ClientsKey);

        public int GetNextId()
        {
            return _counter++;
        }
    }
}
