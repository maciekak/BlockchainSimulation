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
    public class DataController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public DataController(DatabaseContext context)
        {
            _context = context;
        }

        // POST: api/data/add/block
        [HttpPost("add/block")]
        public void Post([FromBody] BlockRequestDto dto)
        {
            lock (_context)
            {
                var block = new Block
                {
                    Id = _context.GetNextId(),
                    Hash = dto.Hash,
                    MinedDate = dto.MinedDate,
                    TransactionCount = dto.TransactionCount,
                    Size = dto.Size,
                    AwardForMining = dto.AwardForMining,
                    GasAmount = dto.GasAmount,
                    TotalSentAmount = dto.TotalSentAmount,
                    TotalReceivedAmount = dto.TotalReceivedAmount,
                    TotalBalance = dto.TotalBalance,
                    AddDate = DateTime.Now
                };
                var foundBlock = _context.Blocks.FirstOrDefault(b => b.Hash == dto.Hash);
                if (foundBlock != null)
                {
                    foundBlock.MinedDate = dto.MinedDate;
                    foundBlock.TransactionCount = dto.TransactionCount;
                    foundBlock.Size = dto.Size;
                    foundBlock.AwardForMining = dto.AwardForMining;
                    foundBlock.GasAmount = dto.GasAmount;
                    foundBlock.TotalSentAmount = dto.TotalSentAmount;
                    foundBlock.TotalReceivedAmount = dto.TotalReceivedAmount;
                    foundBlock.TotalBalance = dto.TotalBalance;
                    foundBlock.UpdateDate = DateTime.Now;
                    block = foundBlock;
                }

                var transactions = _context.Transactions
                    .Where(t => dto.TransactionsHashes?.Contains(t.Hash) == true)
                    .ToList();

                transactions.ForEach(t =>
                {
                    t.Block = block;
                    t.UpdateDate = DateTime.Now;
                });
                block.Transactions = transactions;

                var parentBlock = _context.Blocks
                    .FirstOrDefault(b => b.Hash == dto.ParentHash);

                if (parentBlock != null)
                {
                    parentBlock.ChildBlock = block;
                    parentBlock.UpdateDate = DateTime.Now;
                }
                block.ParentBlock = parentBlock;

                var client = _context.Clients
                    .FirstOrDefault(c => c.Hash == dto.MinerHash);

                if (client?.MinedBlocks.All(b => b.Hash != block.Hash) == true)
                {
                    client.UpdateDate = DateTime.Now;
                    client.MinedBlocks.Add(block);
                }

                block.Miner = client;

                if (_context.Blocks.All(b => b.Hash != block.Hash))
                {
                    _context.Blocks.Add(block);
                }
            }
        }

        // POST: api/data/add/transaction
        [HttpPost("add/transaction")]
        public void Post([FromBody] TransactionRequestDto dto)
        {
            lock (_context)
            {
                var transaction = new Transaction
                {
                    Hash = dto.Hash,
                    TransactionDate = dto.TransactionDate,
                    GasAmount = dto.GasAmount,
                    MoneyAmount = dto.MoneyAmount,
                    AddDate = DateTime.Now
                };
                var foundTransaction = _context.Transactions.FirstOrDefault(t => t.Hash == dto.Hash);
                if (foundTransaction != null)
                {
                    foundTransaction.TransactionDate = dto.TransactionDate;
                    foundTransaction.GasAmount = dto.GasAmount;
                    foundTransaction.MoneyAmount = dto.MoneyAmount;
                    foundTransaction.UpdateDate = DateTime.Now;
                    transaction = foundTransaction;
                }

                var block = _context.Blocks.FirstOrDefault(b => b.Hash == dto.BlockHash);
                transaction.Block = block;
                if (block?.Transactions.All(t => t.Hash != transaction.Hash) == true)
                {
                    block.UpdateDate = DateTime.Now;
                    block.Transactions.Add(transaction);
                }

                var sourceClient = _context.Clients
                    .FirstOrDefault(m => m.Hash == dto.SourceClientHash);

                var destinationClient = _context.Clients
                    .FirstOrDefault(m => m.Hash == dto.DestinationClientHash);

                transaction.SourceClient = sourceClient;
                transaction.DestinationClient = destinationClient;
                if (sourceClient?.Transactions.All(t => t.Hash != transaction.Hash) == true)
                {
                    sourceClient.UpdateDate = DateTime.Now;
                    sourceClient.Transactions.Add(transaction);
                }

                if (destinationClient?.Transactions.All(t => t.Hash != transaction.Hash) == true)
                {
                    destinationClient.UpdateDate = DateTime.Now;
                    destinationClient.Transactions.Add(transaction);
                }

                if (_context.Transactions.All(t => t.Hash != transaction.Hash))
                {
                    _context.Transactions.Add(transaction);
                }
            }
        }

        // POST: api/data/add/client
        [HttpPost("add/client")]
        public void Post([FromBody] ClientRequestDto dto)
        {
            lock (_context)
            {
                var client = new Client
                {
                    Hash = dto.Hash,
                    Type = dto.Type,
                    Amount = dto.Amount,
                    StartDate = dto.StartDate,
                    Transactions = new List<Transaction>(),
                    AddDate = DateTime.Now
                };
                var foundClient = _context.Clients.FirstOrDefault(c => c.Hash == dto.Hash);
                if (foundClient != null)
                {
                    foundClient.Hash = dto.Hash;
                    foundClient.Type = dto.Type;
                    foundClient.Amount = dto.Amount;
                    foundClient.UpdateDate = DateTime.Now;
                    client = foundClient;
                }

                var blocks = _context.Blocks
                    .Where(b => dto.MinedBlocksHashes?.Contains(b.Hash) == true)
                    .ToList();

                blocks.ForEach(b =>
                {
                    b.Miner = client;
                    b.UpdateDate = DateTime.Now;
                });
                client.MinedBlocks = blocks;

                if (_context.Clients.All(c => c.Hash != client.Hash))
                {
                    _context.Clients.Add(client);
                }
            }
        }
    }
}
