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

        // GET: api/blockchain/blocks
        [HttpGet("blocks")]
        public IEnumerable<BlockResponseDto> Get()
        {
            return _context.Blocks.ToResponseDto();
        }

        // GET: api/blockchain/0x2face0x
        [HttpGet("block/{hash}", Name = "Get")]
        public Block Get(string hash)
        {
            return _context.Blocks.FirstOrDefault(b => b.Hash == hash);
        }

        // GET: api/blockchain/blocks
        [HttpGet("transactions")]
        public IEnumerable<TransactionResponseDto> GetTransactions()
        {
            return _context.Transactions.ToResponseDto();
        }

        // GET: api/blockchain/0x2face0x
        [HttpGet("transaction/{hash}", Name = "Get")]
        public TransactionResponseDto GetTransaction(string hash)
        {
            return _context.Transactions.FirstOrDefault(b => b.Hash == hash).ToResponseDto();
        }

        // GET: api/blockchain/blocks
        [HttpGet("miners")]
        public IEnumerable<MinerResponseDto> GetMiners()
        {
            return _context.Miners.ToResponseDto();
        }

        // GET: api/blockchain/0x2face0x
        [HttpGet("miner/{hash}", Name = "Get")]
        public MinerResponseDto GetMiner(string hash)
        {
            return _context.Miners.FirstOrDefault(b => b.Hash == hash).ToResponseDto();
        }

    }
}
