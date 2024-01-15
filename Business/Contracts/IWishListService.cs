using Entities.Dtos;
using Entities.Models;

public interface IWishListService
{
    //IEnumerable<WishListDto> FindAllWishLists();
    WishListDto GetWishListById(int wishlistId);
    WishListDto? GetWishListByUserId(string UserId);
    void CreateWishList(WishListForCreationDto wishlistDto);
    void DeleteWishList(int wishlistId);
}
