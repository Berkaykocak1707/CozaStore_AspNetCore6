
    namespace Entities.Models
    {
        public class Stock
        {
            public int StockId { get; set; }
            public int ProductId { get; set; }
            public string Size { get; set; }
            public string Color { get; set; }
            public int Quantity { get; set; }

            public Product? Product { get; set; }
        }
    }