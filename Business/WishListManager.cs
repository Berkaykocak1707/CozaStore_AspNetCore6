using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;

namespace Business
{
    public class WishListManager : IWishListService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public WishListManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void CreateWishList(WishListForCreationDto wishlistDto)
        {
            var wishlistEntity = _mapper.Map<WishList>(wishlistDto);
            _repositoryManager.WishList.CreateWishList(wishlistEntity);
            _repositoryManager.Save();
        }

        public void DeleteWishList(int wishlistId)
        {
            var wishlist = _repositoryManager.WishList.GetWishListById(wishlistId);
            _repositoryManager.WishList.DeleteWishList(wishlist);
            _repositoryManager.Save();
        }

        //public IEnumerable<WishListDto> FindAllWishLists()
        //{
        //    var wishlist = _repositoryManager.WishList.FindAllWishLists();
        //    var wishlistDto = _mapper.Map<IEnumerable<WishListDto>>(wishlist);
        //    return wishlistDto;
        //}

        public WishListDto GetWishListById(int wishlistId)
        {
            var wishlist = _repositoryManager.WishList.GetWishListById(wishlistId);
            var wishlistDto = _mapper.Map<WishListDto>(wishlist);
            return wishlistDto;
        }

        public WishListDto? GetWishListByUserId(string UserId)
        {
            var wishlist = _repositoryManager.WishList.GetWishListByUserId(UserId);
            var wishlistDto = _mapper.Map<WishListDto>(wishlist);
            return wishlistDto;
        }
    }
}
