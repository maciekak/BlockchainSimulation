namespace BlockchainSimulation2.Dtos
{
    public class BlockSimpleResponseDto
    {
        public string Hash { get; set; }
        public string MinedDate { get; set; }
        public double Size { get; set; }
        public int TransactionCount { get; set; }
    }
}
