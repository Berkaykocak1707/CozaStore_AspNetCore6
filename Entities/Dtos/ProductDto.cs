using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDto
    {

        public int? Id { get; init; }

        [Required]
        [StringLength(100)]
        public string? Slug { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; init; }

        [Required]
        [StringLength(100)]
        public string? SKU { get; set; }

        [Required]
        [StringLength(1000)]
        public string? Description { get; init; }


        public int? CategoryId { get; init; }


        public decimal? Price { get; init; }


        public double? Weight { get; init; }


        public string? Dimensions { get; init; }


        public string? Materials { get; init; }


        public string? Color { get; set; }

        [Required]
        [StringLength(100)]
        public string? Photo1Url { get; set; }


        public string? Photo2Url { get; set; }


        public string? Photo3Url { get; set; }


        public bool IsActive { get; init; }


        public Category? Category { get; init; }
		public ICollection<Stock>? Stocks
		{
			get; set;
		}
		public List<string> AvailableSizes
		{
			get; set;
		}
	}
}