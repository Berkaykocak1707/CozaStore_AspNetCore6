using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record StockDto
    {

        public int? StockId { get; init; }


        public int? ProductId { get; init; }

        [Required]
        [StringLength(100)]
        public string? Size { get; init; }

        [Required]
        [StringLength(100)]
        public string? Color { get; init; }


        public int? Quantity { get; init; }


        public Product? Product { get; init; }
    }
}