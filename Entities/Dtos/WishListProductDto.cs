using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record WishListProductDto
    {
		public int WishListProductId
		{
			get; set;
		}

		public int? WishListId { get; init; }


        public int? ProductId { get; init; }


        public WishList? WishList { get; init; }


        public Product? Product { get; init; }
    }
}