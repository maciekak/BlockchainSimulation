using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BlockchainSimulation2.Database;
using BlockchainSimulation2.Dtos;

namespace BlockchainSimulation2
{
    public static class ConversionConfiguration
    {
        private static IMapper _mapper;

        static ConversionConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Block, BlockResponseDto>()
                        .ForMember(dest => dest.MinerHash, opt => opt.MapFrom(src => src.Miner.Hash))
                        .ForMember(dest => dest.TransactionsHashes, opt => opt.MapFrom(src => src.Transactions.Select(t => t.Hash)));

                    cfg.CreateMap<Transaction, TransactionResponseDto>()
                        .ForMember(dest => dest.BlockHash, opt => opt.MapFrom(src => src.Block.Hash))
                        .ForMember(dest => dest.DestinationClientHash,
                            opt => opt.MapFrom(src => src.DestinationClient.Hash))
                        .ForMember(dest => dest.SourceClientHash, opt => opt.MapFrom(src => src.SourceClient.Hash));

                    cfg.CreateMap<Miner, MinerResponseDto>()
                        .ForMember(dest => dest.MinedBlocksHashes,
                            opt => opt.MapFrom(src => src.MinedBlocks.Select(m => m.Hash)))
                        .ForMember(dest => dest.TransactionsHashes,
                            opt => opt.MapFrom(src => src.Transactions.Select(m => m.Hash)));
                });

            _mapper = config.CreateMapper();
        }

        public static IEnumerable<BlockResponseDto> ToResponseDto(this IEnumerable<Block> from)
        {
            return _mapper.Map<IEnumerable<Block>, IEnumerable<BlockResponseDto>>(from);
        }

        public static BlockResponseDto ToResponseDto(this Block from)
        {
            return _mapper.Map<Block, BlockResponseDto>(from);
        }

        public static IEnumerable<MinerResponseDto> ToResponseDto(this IEnumerable<Miner> from)
        {
            return _mapper.Map<IEnumerable<Miner>, IEnumerable<MinerResponseDto>>(from);
        }

        public static MinerResponseDto ToResponseDto(this Miner from)
        {
            return _mapper.Map<Miner, MinerResponseDto>(from);
        }

        public static IEnumerable<TransactionResponseDto> ToResponseDto(this IEnumerable<Transaction> from)
        {
            return _mapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionResponseDto>>(from);
        }

        public static TransactionResponseDto ToResponseDto(this Transaction from)
        {
            return _mapper.Map<Transaction, TransactionResponseDto>(from);
        }
    }
}
