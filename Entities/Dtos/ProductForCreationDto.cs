namespace Entities.Dtos
{
    public record ProductForCreationDto : ProductDto
    {
        public List<StockForCreation> Stocks { get; set; } = new List<StockForCreation>();
    }
    public class StockForCreation
    {
        public string? Size
        {
            get; set;
        }
        public string? Color
        {
            get; set;
        }
        public int Quantity
        {
            get; set;
        }
    }
}