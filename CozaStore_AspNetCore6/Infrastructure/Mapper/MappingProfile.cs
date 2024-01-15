using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace CozaStore_AspNetCore6.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AboutDto, About>().ReverseMap();
            CreateMap<AboutForCreationDto, About>();
            CreateMap<AboutForUpdateDto, About>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>().ReverseMap();
            CreateMap<ContactDto, Contact>().ReverseMap();
            CreateMap<ContactForCreationDto, Contact>();
            CreateMap<ContactForUpdateDto, Contact>().ReverseMap();
            CreateMap<CouponDto, Coupon>().ReverseMap();
            CreateMap<CouponForCreationDto, Coupon>();
            CreateMap<CouponForUpdateDto, Coupon>().ReverseMap();
            CreateMap<InformationDto, Information>().ReverseMap();
            CreateMap<InformationForCreationDto, Information>();
            CreateMap<InformationForUpdateDto, Information>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductForCreationDto, Product>()
                .ForMember(i => i.Stocks, opt => opt.Ignore());
            CreateMap<ProductForUpdateDto, Product>().ForMember(i => i.Stocks, opt => opt.Ignore()).ReverseMap();
            CreateMap<StockDto, Stock>().ReverseMap();
            CreateMap<StockForCreationDto, Stock>();
            CreateMap<StockForUpdateDto, Stock>().ReverseMap();
            CreateMap<WishListDto, WishList>().ReverseMap();
            CreateMap<WishListForCreationDto, WishList>();
            CreateMap<WishListForUpdateDto, WishList>().ReverseMap();
            CreateMap<WishListProductDto, WishListProduct>().ReverseMap();
            CreateMap<WishListProductForCreationDto, WishListProduct>();
            CreateMap<WishListProductForUpdateDto, WishListProduct>().ReverseMap();
            CreateMap<OrderDto, Order>();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<OrderDto, OrderDtoForCreation>().ReverseMap();
            CreateMap<OrderDto, OrderDtoForCreation>();
            CreateMap<UserDtoForCreation, CustomUser>();
            CreateMap<UserDtoForUpdate, CustomUser>().ReverseMap();
            CreateMap<OrderDtoForCreation, Order>();
            CreateMap<OrderDtoForUpdate, Order>().ReverseMap();
        }
    }
}
