namespace BlockchainSimulation2.Dtos
{
    public class TransactionRequestDto
    {
        public string Hash { get; set; }
        public string Date { get; set; }
        public decimal MoneyAmount { get; set; }
        public double GasAmount { get; set; }

        public string SourceClientHash { get; set; }
        public string DestinationClientHash { get; set; }
        public string BlockHash { get; set; }
    }
}
