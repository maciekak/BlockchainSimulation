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
            var block = new Block
            {
                Id = dto.Id,
                Hash = dto.Hash,
                MinedDate = dto.MinedDate,
                TransactionCount = dto.TransactionCount,
                Size = dto.Size,
                AwardForMining = dto.AwardForMining,
                GasAmount = dto.GasAmount,
                TotalSentAmount = dto.TotalSentAmount,
                TotalReceivedAmount = dto.TotalReceivedAmount,
                TotalBalance = dto.TotalBalance
            };

            var transactions = _context.Transactions
                .Where(t => dto.TransactionsHashes.Contains(t.Hash))
                .ToList();

            transactions.ForEach(t => t.Block = block);
            block.Transactions = transactions;

            var parentBlock = _context.Blocks
                .FirstOrDefault(b => b.Hash == dto.ParentHash);

            if (parentBlock != null) parentBlock.ChildBlock = block;
            block.ParentBlock = parentBlock;

            var client = _context.Clients
                .FirstOrDefault(c => c.Hash == dto.MinerHash);

            client?.MinedBlocks.Add(block);
            block.Miner = client;

            _context.Blocks.Add(block);
        }

        // POST: api/data/add/transaction
        [HttpPost("add/transaction")]
        public void Post([FromBody] TransactionRequestDto dto)
        {
            var transaction = new Transaction
            {
                Hash = dto.Hash,
                Date = dto.Date,
                GasAmount = dto.GasAmount,
                MoneyAmount = dto.MoneyAmount
            };

            //TODO: something can go wrong here
            var block = _context.Blocks.FirstOrDefault(b => b.Hash == dto.BlockHash);
            transaction.Block = block;
            block?.Transactions.Add(transaction);

            var sourceClient = _context.Clients
                .FirstOrDefault(m => m.Hash == dto.SourceClientHash);

            var destinationClient = _context.Clients
                .FirstOrDefault(m => m.Hash == dto.DestinationClientHash);

            transaction.SourceClient = sourceClient;
            transaction.DestinationClient = destinationClient;
            sourceClient?.Transactions.Add(transaction);
            destinationClient?.Transactions.Add(transaction);

            _context.Transactions.Add(transaction);
        }

        // POST: api/data/add/client
        [HttpPost("add/client")]
        public void Post([FromBody] ClientRequestDto dto)
        {
            var client = new Client
            {
                Hash = dto.Hash,
                Type = dto.Type,
                Amount = dto.Amount,
                StartDate = dto.StartDate,
                Transactions = new List<Transaction>()
            };

            var blocks = _context.Blocks
                .Where(b => dto.MinedBlocksHashes.Contains(b.Hash))
                .ToList();

            blocks.ForEach(b => b.Miner = client);
            client.MinedBlocks = blocks;

            _context.Clients.Add(client);
        }
    }
}
