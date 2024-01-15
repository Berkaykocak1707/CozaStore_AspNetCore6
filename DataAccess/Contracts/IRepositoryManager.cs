using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IRepositoryManager
    {

        IAboutRepository About
        {
            get;
        }
        ICategoryRepository Category
        {
            get;
        }
        IContactRepository Contact
        {
            get;
        }
        ICouponRepository Coupon
        {
            get;
        }
        IInformationRepository Information
        {
            get;
        }
        IProductRepository Product
        {
            get;
        }
        IStockRepository Stock
        {
            get;
        }
        IWishListRepository WishList
        {
            get;
        }
        IWishListProductRepository WishListProduct
        {
            get;
        }
        IOrderRepository Order
        {
            get;
        }

        void Save();
    }
}
