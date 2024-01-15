
    using System.Collections.Generic;
    namespace Entities.Models
    {
        public class WishList
        {
            public int Id { get; set; }
            public string UserId { get; set; }

            public ICollection<WishListProduct>? WishListProducts
            {
                get; set;
            }
            public CustomUser User { get; set; } 
        }
    }