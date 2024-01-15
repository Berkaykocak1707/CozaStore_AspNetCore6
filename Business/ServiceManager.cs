using Business.Contracts;

namespace Business
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAboutService _aboutService;
        private readonly ICategoryService _categoryService;
        private readonly IContactService _contactService;
        private readonly ICouponService _couponService;
        private readonly IInformationService _informationService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IStockService _stockService;
        private readonly IWishListService _wishListService;
        private readonly IWishListProductService _wishListProductService;
        private readonly IAuthService _authService;

        public ServiceManager(
            IAboutService aboutService,
            ICategoryService categoryService,
            IContactService contactService,
            ICouponService couponService,
            IInformationService informationService,
            IOrderService orderService,
            IProductService productService,
            IStockService stockService,
            IWishListService wishListService,
            IWishListProductService wishListProductService,
            IAuthService authService)
        {
            _aboutService = aboutService;
            _categoryService = categoryService;
            _contactService = contactService;
            _couponService = couponService;
            _informationService = informationService;
            _orderService = orderService;
            _productService = productService;
            _stockService = stockService;
            _wishListService = wishListService;
            _wishListProductService = wishListProductService;
            _authService = authService;
        }

        public IAboutService AboutService => _aboutService;
        public ICategoryService CategoryService => _categoryService;
        public IContactService ContactService => _contactService;
        public ICouponService CouponService => _couponService;
        public IInformationService InformationService => _informationService;
        public IOrderService OrderService => _orderService;
        public IProductService ProductService => _productService;
        public IStockService StockService => _stockService;
        public IWishListService WishListService => _wishListService;
        public IWishListProductService WishListProductService => _wishListProductService;

        public IAuthService AuthService => _authService;
    }
}
