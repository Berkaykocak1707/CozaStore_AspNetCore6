namespace Entities.Dtos
{
    public record ProductForUpdateDto : ProductDto
    {
        public List<StockForCreation> Stocks { get; set; } = new List<StockForCreation>();
    }
    
}