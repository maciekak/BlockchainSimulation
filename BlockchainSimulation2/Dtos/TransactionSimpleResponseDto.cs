namespace BlockchainSimulation2.Dtos
{
    public class TransactionSimpleResponseDto
    {
        public string Hash { get; set; }
        public string TransactionDate { get; set; }
        public decimal MoneyAmount { get; set; }
        public string BlockHash { get; set; }
    }
}
