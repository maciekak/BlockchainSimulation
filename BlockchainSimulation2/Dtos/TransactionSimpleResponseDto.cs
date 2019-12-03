namespace BlockchainSimulation2.Dtos
{
    public class TransactionSimpleResponseDto
    {
        public string Hash { get; set; }
        public string TransactionDate { get; set; }
        public string MoneyAmount { get; set; }
        public bool IsNew { get; set; }
        public bool Updated { get; set; }
        public string BlockHash { get; set; }
    }
}
