
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
    {
        public class WishListProduct
        {
            [Key]
            public int WishListProductId { get; set; }
            public int WishListId { get; set; }
            public int ProductId { get; set; }

            public WishList? WishList { get; set; }
            public Product? Product { get; set; }
        }
    }