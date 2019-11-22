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

        // GET: api/blockchain/blocks
        [HttpGet("blocks")]
        
        public IEnumerable<BlockResponseDto> Get()
        {
            lock(_context)
            {
                var blocks = _context.Blocks.OrderByDescending(b => b.MinedDate).ToList();
                var response = blocks.ToResponseDto();
                blocks.ForEach(b =>
                {
                    b.IsNew = false;
                    b.Updated = false;;
                });

                return response;
            }
        }

        // GET: api/blockchain/0x2face0x
        [HttpGet("blocks/{hash}")]
        public BlockDetailsResponseDto Get(string hash)
        {
            lock (_context)
            {
                var block = _context.Blocks.FirstOrDefault(b => b.Hash == hash);
                var response = block?.ToResponseDto();

                if (block == null) return null;

                block.IsNew = false;
                block.Updated = false;

                return response;
            }
        }

        // GET: api/blockchain/blocks
        [HttpGet("transactions")]
        public IEnumerable<TransactionResponseDto> GetTransactions()
        {
            lock (_context)
            {
                var transactions = _context.Transactions.OrderByDescending(t => t.TransactionDate).ToList();
                var response = transactions.ToResponseDto();

                transactions.ForEach(t =>
                {
                    t.IsNew = false;
                    t.Updated = false;
                });

                return response;
            }
        }

        // GET: api/blockchain/0x2face0x
        [HttpGet("transactions/{hash}")]
        public TransactionResponseDto GetTransaction(string hash)
        {
            lock (_context)
            {
                var transaction = _context.Transactions.FirstOrDefault(b => b.Hash == hash);

                if (transaction == null) return null;

                var response = transaction.ToResponseDto();

                transaction.IsNew = false;
                transaction.Updated = false;

                return response;
            }
        }

        // GET: api/blockchain/blocks
        [HttpGet("clients")]
        public IEnumerable<ClientResponseDto> GetMiners()
        {
            lock (_context)
            {
                var clients = _context.Clients.OrderByDescending(m => m.StartDate).ToList();
                var response = clients.ToResponseDto();

                clients.ForEach(c =>
                {
                    c.IsNew = false;
                    c.Updated = false;
                });

                return response;
            }
        }

        // GET: api/blockchain/0x2face0x
        [HttpGet("clients/{hash}")]
        public ClientDetailsResponseDto GetMiner(string hash)
        {
            lock (_context)
            {
                var client = _context.Clients.FirstOrDefault(b => b.Hash == hash);

                if (client == null) return null;
                var response = client.ToResponseDto();

                response.IsNew = false;
                response.Updated = false;

                return response;
            }
        }
    }
}
