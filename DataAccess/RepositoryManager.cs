using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private IOrderRepository _orderRepository;
        private IAboutRepository _aboutRepository;
        private ICategoryRepository _categoryRepository;
        private IContactRepository _contactRepository;
        private ICouponRepository _couponRepository;
        private IInformationRepository _informationRepository;
        private IProductRepository _productRepository;
        private IStockRepository _stockRepository;
        private IWishListRepository _wishlistRepository;
        private IWishListProductRepository _wishlistproductRepository;

        public RepositoryManager(RepositoryContext context, IOrderRepository orderRepository, IAboutRepository aboutRepository, ICategoryRepository categoryRepository, IContactRepository contactRepository, ICouponRepository couponRepository, IInformationRepository informationRepository, IProductRepository productRepository, IStockRepository stockRepository, IWishListRepository wishlistRepository, IWishListProductRepository wishlistproductRepository)
        {
            _context = context;
            _orderRepository = orderRepository;
            _aboutRepository = aboutRepository;
            _categoryRepository = categoryRepository;
            _contactRepository = contactRepository;
            _couponRepository = couponRepository;
            _informationRepository = informationRepository;
            _productRepository = productRepository;
            _stockRepository = stockRepository;
            _wishlistRepository = wishlistRepository;
            _wishlistproductRepository = wishlistproductRepository;
        }

        public IOrderRepository Order => _orderRepository;

        public IAboutRepository About => _aboutRepository;

        public ICategoryRepository Category => _categoryRepository;

        public IContactRepository Contact => _contactRepository;

        public ICouponRepository Coupon => _couponRepository;

        public IInformationRepository Information => _informationRepository;

        public IProductRepository Product => _productRepository;

        public IStockRepository Stock => _stockRepository;

        public IWishListRepository WishList => _wishlistRepository;

        public IWishListProductRepository WishListProduct => _wishlistproductRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
