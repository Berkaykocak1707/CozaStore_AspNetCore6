using AutoMapper;
using Business.Contracts;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using System.Drawing;

namespace CozaStore_AspNetCore6.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;
       
        public Cart Cart { get; set; }

        public CartModel(IServiceManager manager, Cart cartService, IMapper mapper)
        {
            _manager = manager;
            Cart = cartService;
            _mapper = mapper;
        }


        public void OnGet()
        {
            
        }

        public IActionResult OnPost(int productID, int quantity,string color, string size,string returnUrl)
        {
            if (color == null || size == null)
            {
                TempData["ErrorMessage"] = "Please choose a size and color";
                return Redirect(returnUrl);
            }
            var productDto = _manager.ProductService.GetProductById(productID);
            var product = _mapper.Map<Product>(productDto);

            if(product is not null)
            {
                var stock = _manager.StockService.GetStockForCart(productID, size, color);
                if (stock.Quantity < quantity)
                {
                     TempData["ErrorMessage"] = $"Limit for this product is {stock.Quantity}";
                    if (stock.Quantity == 0)
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        quantity = (int)stock.Quantity;
                        Cart.AddItem(product, quantity, size, color);
                    }                    
                }
                else if (stock.Quantity <= 0)
                {
                    return Redirect(returnUrl);
                }
                else
                {
					// Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
					Cart.AddItem(product, quantity,size,color);
					// HttpContext.Session.SetJson<Cart>("cart",Cart);
				}

			}
            return Page();
        }
        public IActionResult OnPostUpdate(int productId, string size, string color,int numproduct)
        {
            numproduct += 1;
            var stock = _manager.StockService.GetStockForCart(productId, size, color);
            if (stock.Quantity < numproduct)
            {
                TempData["ErrorMessage"] = $"Limit for this product is {stock.Quantity}";
                return Page();
            }
            else
            {
                ProductDto productDto = _manager.ProductService.GetProductById(productId);
                var product = _mapper.Map<Product>(productDto);
                if (product != null)
                {
                  Cart.UpdateItemQuantity(product, 1,size,color);
                }
            }
            return Page();
        }
        public IActionResult OnPostRemove(int productId, string size, string color)
        {
            ProductDto productDto = _manager.ProductService.GetProductById(productId);
            var product = _mapper.Map<Product>(productDto);
            if (product != null)
            {
                Cart.RemoveItemQuantity(product, 1,size,color);
            }
            return Page(); 
        }
        public IActionResult OnPostDelete(int productId, string size, string color)
        {
            ProductDto productDto = _manager.ProductService.GetProductById(productId);
            var product = _mapper.Map<Product>(productDto);
            if (product != null)
            {
                Cart.RemoveLine(product, size, color);
            }
            return Page();
        }
        public IActionResult OnPostCoupon(string coupon)
        {
            if (coupon != null)
            {
                var couponDiscount = _manager.CouponService.GetCouponByCouponName(coupon);
                if (couponDiscount.CouponStock <= 0)
                {
                    TempData["ErrorMessage"] = "Coupon is out of stock";
                }
                else if (couponDiscount == null || couponDiscount.IsActive == false)
                {
                    TempData["ErrorMessage"] = "Coupon is not active";
                }
                else
                {
                    TempData["couponName"] = couponDiscount.CouponCode;
                    TempData["couponDiscount"] = couponDiscount.CouponDiscountPercentage;
				    decimal Total = Cart.ComputeTotalValue((int?)couponDiscount.CouponDiscountPercentage);
                    TempData["Total"] = Total.ToString();
                }
            }
            
            return Page();
        }
    }
}