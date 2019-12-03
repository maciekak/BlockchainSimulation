using System;
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
                cfg.CreateMap<Block, BlockResponseDto>(MemberList.Destination)
                    .ForMember(dest => dest.MinerHash,
                        opt => opt.MapFrom(src => src.Miner.Hash))
                    .ForMember(dest => dest.TransactionsHashes,
                        opt => opt.MapFrom(src => src.Transactions.Select(t => t.Hash)))
                    .ForMember(dest => dest.ParentHash,
                        opt => opt.MapFrom(src => src.ParentBlock.Hash))
                    .ForMember(dest => dest.ChildHash,
                        opt => opt.MapFrom(src => src.ChildBlock.Hash))
                    .ForMember(dest => dest.TransactionCount,
                        opt => opt.MapFrom(src => src.Transactions.Count))
                    .ForMember(dest => dest.IsNew,
                    opt => opt.MapFrom(src => src.AddDate.AddSeconds(3) > DateTime.Now))
                    .ForMember(dest => dest.Updated,
                        opt => opt.MapFrom(src => src.UpdateDate.AddSeconds(3) > DateTime.Now));

                cfg.CreateMap<Block, BlockDetailsResponseDto>(MemberList.Destination)
                    .ForMember(dest => dest.MinerHash,
                        opt => opt.MapFrom(src => src.Miner.Hash))
                    .ForMember(dest => dest.Transactions,
                        opt => opt.MapFrom(src => src.Transactions.Select(t => new TransactionSimpleResponseDto
                        {
                            Hash = t.Hash,
                            MoneyAmount = t.MoneyAmount,
                            TransactionDate = t.TransactionDate.ToString("d.MM.yyyy H:mm:ss"),
                            BlockHash = t.Block.Hash
                        })))
                    .ForMember(dest => dest.ParentHash,
                        opt => opt.MapFrom(src => src.ParentBlock.Hash))
                    .ForMember(dest => dest.ChildHash,
                        opt => opt.MapFrom(src => src.ChildBlock.Hash))
                    .ForMember(dest => dest.TransactionCount,
                        opt => opt.MapFrom(src => src.Transactions.Count))
                    .ForMember(dest => dest.IsNew,
                        opt => opt.MapFrom(src => src.AddDate.AddSeconds(3) > DateTime.Now))
                    .ForMember(dest => dest.Updated,
                        opt => opt.MapFrom(src => src.UpdateDate.AddSeconds(3) > DateTime.Now));

                cfg.CreateMap<Transaction, TransactionResponseDto>(MemberList.Destination)
                    .ForMember(dest => dest.BlockHash,
                        opt => opt.MapFrom(src => src.Block.Hash))
                    .ForMember(dest => dest.DestinationClientHash,
                        opt => opt.MapFrom(src => src.DestinationClient.Hash))
                    .ForMember(dest => dest.SourceClientHash,
                        opt => opt.MapFrom(src => src.SourceClient.Hash))
                    .ForMember(dest => dest.IsNew,
                        opt => opt.MapFrom(src => src.AddDate.AddSeconds(3) > DateTime.Now))
                    .ForMember(dest => dest.Updated,
                        opt => opt.MapFrom(src => src.UpdateDate.AddSeconds(3) > DateTime.Now));

                cfg.CreateMap<Client, ClientResponseDto>(MemberList.Destination)
                    .ForMember(dest => dest.MinedBlocksHashes,
                        opt => opt.MapFrom(src => src.MinedBlocks.Select(m => m.Hash)))
                    .ForMember(dest => dest.TransactionsHashes,
                        opt => opt.MapFrom(src => src.Transactions.Select(m => m.Hash)))
                    .ForMember(dest => dest.TransactionsCount,
                        opt => opt.MapFrom(src => src.Transactions.Count))
                    .ForMember(dest => dest.MinedBlocksCount,
                        opt => opt.MapFrom(src => src.MinedBlocks.Count))
                    .ForMember(dest => dest.IsNew,
                        opt => opt.MapFrom(src => src.AddDate.AddSeconds(3) > DateTime.Now))
                    .ForMember(dest => dest.Updated,
                        opt => opt.MapFrom(src => src.UpdateDate.AddSeconds(3) > DateTime.Now));

                cfg.CreateMap<Client, ClientDetailsResponseDto>(MemberList.Destination)
                    .ForMember(dest => dest.MinedBlocksHashes,
                        opt => opt.MapFrom(src => src.MinedBlocks.Select(m => new BlockSimpleResponseDto
                        {
                            Hash = m.Hash,
                            MinedDate = m.MinedDate.ToString("d.MM.yyyy H:mm:ss"),
                            Size = m.Size,
                            TransactionCount = m.Transactions.Count
                        })))
                    .ForMember(dest => dest.TransactionsHashes,
                        opt => opt.MapFrom(src => src.Transactions.Select(m => new TransactionSimpleResponseDto
                        {
                            Hash = m.Hash,
                            MoneyAmount = m.MoneyAmount,
                            TransactionDate = m.TransactionDate.ToString("d.MM.yyyy H:mm:ss"),
                            BlockHash = m.Block.Hash,
                        })))
                    .ForMember(dest => dest.TransactionsCount,
                        opt => opt.MapFrom(src => src.Transactions.Count))
                    .ForMember(dest => dest.MinedBlocksCount,
                        opt => opt.MapFrom(src => src.MinedBlocks.Count))
                    .ForMember(dest => dest.IsNew,
                        opt => opt.MapFrom(src => src.AddDate.AddSeconds(3) > DateTime.Now))
                    .ForMember(dest => dest.Updated,
                        opt => opt.MapFrom(src => src.UpdateDate.AddSeconds(3) > DateTime.Now));

                cfg.CreateMap<DateTime, string>()
                    .ConvertUsing(date => date.ToString("d.MM.yyyy H:mm:ss"));
            });

            _mapper = config.CreateMapper();
        }

        public static IEnumerable<BlockResponseDto> ToResponseDto(this IEnumerable<Block> from)
        {
            return _mapper.Map<IEnumerable<Block>, IEnumerable<BlockResponseDto>>(from);
        }

        public static BlockDetailsResponseDto ToResponseDto(this Block from)
        {
            return _mapper.Map<Block, BlockDetailsResponseDto>(from);
        }

        public static IEnumerable<ClientResponseDto> ToResponseDto(this IEnumerable<Client> from)
        {
            return _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResponseDto>>(from);
        }

        public static ClientDetailsResponseDto ToResponseDto(this Client from)
        {
            return _mapper.Map<Client, ClientDetailsResponseDto>(from);
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
