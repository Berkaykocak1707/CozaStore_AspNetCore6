using Entities.Dtos;
using Entities.Models;

public interface IWishListProductService
{
	IEnumerable<WishListProductDto> FindAllWishListProducts(int wishlistId);

	void AddProductToWishList(WishListProductForCreationDto wishlistproductDto);
    void RemoveProductFromWishList(int wishlistId, int wishlistproductId); 
    void DeleteWishListProductsByListId(int wishlistId);
    WishListProductDto GetWishListProductById(int wishlistId, int? wishlistproductId);
}
