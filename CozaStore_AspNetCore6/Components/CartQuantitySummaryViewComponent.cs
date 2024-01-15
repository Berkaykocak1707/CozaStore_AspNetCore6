using Business.Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore_AspNetCore6.Components
{
	public class CartQuantitySummaryViewComponent : ViewComponent
	{
		private readonly IServiceManager _serviceManager;
		private readonly Cart _cart;
        public CartQuantitySummaryViewComponent(IServiceManager repositoryContext, Cart cart)
        {
            _serviceManager = repositoryContext;
            _cart = cart;
        }
        public string Invoke()
		{
			return _cart.ComputeTotalQuantity().ToString();
		}
	}
}
