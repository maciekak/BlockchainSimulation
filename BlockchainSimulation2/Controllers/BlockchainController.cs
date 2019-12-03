using System;
using System.Collections.Generic;
using System.Linq;
using BlockchainSimulation2.Database;
using BlockchainSimulation2.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BlockchainSimulation2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BlockchainController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BlockchainController(DatabaseContext context)
        {
            _context = context;
        }

        private static string GetGuid()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }

        // GET: api/blockchain/clear
        [HttpGet("clear")]
        public void Clear()
        {
            lock (_context)
            {
                _context.Blocks.Clear();
                _context.Clients.Clear();
                _context.Transactions.Clear();
            }
        }
        // GET: api/blockchain/init
        [HttpGet("init")]
        public void Init()
        {
            //            var block1 = new Block
            //            {
            //                Id = 1,
            //                Hash = GetGuid(),
            //                MinedDate = DateTime.Now.AddDays(-2),
            //                TransactionCount = 18,
            //                Size = 32.3,
            //                AwardForMining = 2,
            //                GasAmount = 12.3,
            //                TotalSentAmount = 4,
            //                TotalReceivedAmount = 3,
            //                TotalBalance = -1,
            //                Transactions = new List<Transaction>()
            //            };
            //            var block2 = new Block
            //            {
            //                Id = 2,
            //                Hash = GetGuid(),
            //                MinedDate = DateTime.Now.AddMinutes(-290),
            //                TransactionCount = 5,
            //                Size = 355.3,
            //                AwardForMining = 2,
            //                GasAmount = 122.3,
            //                TotalSentAmount = 1,
            //                TotalReceivedAmount = 5,
            //                TotalBalance = 4,
            //                Transactions = new List<Transaction>()
            //            };
            //            var block3 = new Block
            //            {
            //                Id = 3,
            //                Hash = GetGuid(),
            //                MinedDate = DateTime.Now.AddDays(-250),
            //                TransactionCount = 1,
            //                Size = 2.3,
            //                AwardForMining = 2,
            //                GasAmount = 1.3,
            //                TotalSentAmount = 23,
            //                TotalReceivedAmount = 1,
            //                TotalBalance = -22,
            //                Transactions = new List<Transaction>()
            //            };
            //
            //            var transaction1 = new Transaction
            //            {
            //                Hash = GetGuid(),
            //                TransactionDate = DateTime.Now.AddMonths(-2),
            //                GasAmount = 0.3,
            //                MoneyAmount = 12.233m
            //            };
            //            var transaction2 = new Transaction
            //            {
            //                Hash = GetGuid(),
            //                TransactionDate = DateTime.Now.AddMonths(-1),
            //                GasAmount = 0.8,
            //                MoneyAmount = 1.233m
            //            };
            //            var transaction3 = new Transaction
            //            {
            //                Hash = GetGuid(),
            //                TransactionDate = DateTime.Now.AddMonths(-22),
            //                GasAmount = 0.6,
            //                MoneyAmount = 158.233m
            //            };
            //            var transaction4 = new Transaction
            //            {
            //                Hash = GetGuid(),
            //                TransactionDate = DateTime.Now.AddMonths(-23),
            //                GasAmount = 0.1,
            //                MoneyAmount = 1222.23m
            //            };
            //
            //            var miner1 = new Client
            //            {
            //                Hash = GetGuid(),
            //                Type = ClientType.Client,
            //                Amount = 254.21m,
            //                StartDate = DateTime.Now.AddYears(-1),
            //                Transactions = new List<Transaction>(),
            //                MinedBlocks = new List<Block>()
            //            };
            //            var miner2 = new Client
            //            {
            //                Hash = GetGuid(),
            //                Type = ClientType.Client,
            //                Amount = 14.21m,
            //                StartDate = DateTime.Now.AddYears(-2),
            //                Transactions = new List<Transaction>(),
            //                MinedBlocks = new List<Block>()
            //            };
            //            var miner3 = new Client
            //            {
            //                Hash = GetGuid(),
            //                Type = ClientType.Miner,
            //                Amount = 24.21m,
            //                StartDate = DateTime.Now.AddYears(-3),
            //                Transactions = new List<Transaction>(),
            //                MinedBlocks = new List<Block>()
            //            };
            //
            //            block2.ParentBlock = block1;
            //            block3.ParentBlock = block2;
            //            block1.ChildBlock = block2;
            //            block2.ChildBlock = block3;
            //
            //            block1.Transactions.Add(transaction1);
            //            block2.Transactions.Add(transaction2);
            //            block2.Transactions.Add(transaction3);
            //            block3.Transactions.Add(transaction4);
            //            transaction1.Block = block1;
            //            transaction2.Block = block2;
            //            transaction3.Block = block2;
            //            transaction4.Block = block3;
            //
            //            miner1.Transactions.Add(transaction1);
            //            miner2.Transactions.Add(transaction1);
            //            miner1.Transactions.Add(transaction2);
            //            miner3.Transactions.Add(transaction2);
            //            miner2.Transactions.Add(transaction3);
            //            miner3.Transactions.Add(transaction3);
            //            miner1.Transactions.Add(transaction4);
            //            miner3.Transactions.Add(transaction4);
            //            transaction1.SourceClient = miner1;
            //            transaction1.DestinationClient = miner2;
            //            transaction2.SourceClient = miner1;
            //            transaction2.DestinationClient = miner3;
            //            transaction3.SourceClient = miner2;
            //            transaction3.DestinationClient = miner3;
            //            transaction4.SourceClient = miner1;
            //            transaction4.DestinationClient = miner3;
            //
            //            miner3.MinedBlocks.Add(block1);
            //            miner3.MinedBlocks.Add(block2);
            //            miner3.MinedBlocks.Add(block3);
            //            block1.Miner = miner3;
            //            block2.Miner = miner3;
            //            block3.Miner = miner3;
            //
            //            _context.Clients.Add(miner1);
            //            _context.Clients.Add(miner2);
            //            _context.Clients.Add(miner3);
            //            _context.Transactions.Add(transaction1);
            //            _context.Transactions.Add(transaction2);
            //            _context.Transactions.Add(transaction3);
            //            _context.Transactions.Add(transaction4);
            //            _context.Blocks.Add(block1);
            //            _context.Blocks.Add(block2);
            //            _context.Blocks.Add(block3);
        }

        // GET: api/blockchain/blocks
        [HttpGet("blocks")]

        public IEnumerable<BlockResponseDto> Get()
        {
            lock (_context)
            {
                return _context.Blocks.OrderByDescending(b => b.MinedDate).ToResponseDto();
            }
        }

        // GET: api/blockchain/0x2face0x
        [HttpGet("blocks/{hash}")]
        public BlockDetailsResponseDto Get(string hash)
        {
            lock (_context)
            {
                return _context.Blocks.FirstOrDefault(b => b.Hash == hash)?.ToResponseDto();
            }
        }

        // GET: api/blockchain/blocks
        [HttpGet("transactions")]
        public IEnumerable<TransactionResponseDto> GetTransactions()
        {
            lock (_context)
            {
                return _context.Transactions.OrderByDescending(t => t.TransactionDate).ToResponseDto();
            }
        }

        // GET: api/blockchain/0x2face0x
        [HttpGet("transactions/{hash}")]
        public TransactionResponseDto GetTransaction(string hash)
        {
            lock (_context)
            {
                return _context.Transactions.FirstOrDefault(b => b.Hash == hash)?.ToResponseDto();
            }
        }

        // GET: api/blockchain/blocks
        [HttpGet("clients")]
        public IEnumerable<ClientResponseDto> GetMiners()
        {
            lock (_context)
            {
                return _context.Clients.OrderByDescending(m => m.StartDate).ToResponseDto();
            }
        }

        // GET: api/blockchain/0x2face0x
        [HttpGet("clients/{hash}")]
        public ClientDetailsResponseDto GetMiner(string hash)
        {
            lock (_context)
            {
                return _context.Clients.FirstOrDefault(b => b.Hash == hash).ToResponseDto();
            }
        }

    }
}
