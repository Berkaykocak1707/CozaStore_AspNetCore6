using Entities.Models;
using System.ComponentModel.DataAnnotations;
namespace Entities.Dtos
{
    public record CategoryDto
    {

        public int Id { get; init; }

        [Required]
        [StringLength(100)]
        public string? Name { get; init; }

        [StringLength(100)]
        public string? Slug { get; set; }
		public ICollection<Product>? Products
		{
			get; set;
		}
	}
}