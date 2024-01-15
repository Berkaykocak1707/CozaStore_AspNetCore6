using Business.Contracts;

namespace Business.Contracts
{
    public interface IServiceManager
    {
        IAuthService AuthService
        {
        get; }
        IOrderService OrderService
        {
        get; }
        IAboutService AboutService
        {
            get;
        }
        ICategoryService CategoryService
        {
            get;
        }
        IContactService ContactService
        {
            get;
        }
        ICouponService CouponService
        {
            get;
        }
        IInformationService InformationService
        {
            get;
        }
        IProductService ProductService
        {
            get;
        }
        IStockService StockService
        {
            get;
        }
        IWishListService WishListService
        {
            get;
        }
        IWishListProductService WishListProductService
        {
            get;
        }
    }
}