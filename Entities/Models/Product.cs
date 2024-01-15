
    using System.Collections.Generic;
    namespace Entities.Models
    {
        public class Product
        {
            public int Id { get; set; }
            public string Slug { get; set; }
            public string Name { get; set; }
            public string SKU { get; set; }
            public string Description { get; set; }
            public int CategoryId { get; set; }
            public decimal Price { get; set; }
            public double? Weight { get; set; }
            public string? Dimensions { get; set; }
            public string? Materials { get; set; }
            public string? Color { get; set; }
            public string Photo1Url { get; set; }
            public string? Photo2Url { get; set; }
            public string? Photo3Url { get; set; }
            public bool IsActive { get; set; }

            public Category? Category { get; set; }
            public ICollection<Stock>? Stocks { get; set; }
            public ICollection<WishListProduct>? WishListProducts { get; set; }
        }
    }