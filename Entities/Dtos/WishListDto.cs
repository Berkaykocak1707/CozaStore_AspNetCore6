using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record WishListDto
    {

        public int? Id { get; init; }

        [Required]
        [StringLength(100)]
        public string? UserId { get; init; }

		public ICollection<WishListProduct>? WishListProducts
		{
			get; set;
		}
		public CustomUser? User { get; init; }
    }
}