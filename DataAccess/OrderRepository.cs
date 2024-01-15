using DataAccess.Contracts;
using DataAccess.Extensions;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public sealed class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOrder(Order order)
        {
            var products = order.Lines.Select(p => p.Product).ToList();

            foreach (var product in products)
            {
                // Ürünün zaten takip edilip edilmediğini kontrol et
                var existingProduct = _context.Products.Local.FirstOrDefault(p => p.Id == product.Id);
                if (existingProduct == null)
                {
                    // Ürün takip edilmiyorsa, DbContext'e ekle
                    _context.Attach(product);
                }
            }

            if (order.OrderId == 0)
            {
                foreach (var line in order.Lines)
                {
                    var product = line.Product;
                    var trackedProduct = _context.Products.Local.FirstOrDefault(p => p.Id == product.Id);
                    if (trackedProduct != null)
                    {
                        // Ürün zaten takip ediliyorsa, mevcut nesneyi kullan
                        line.Product = trackedProduct;
                    }

                    var matchingStock = _context.Stocks.FirstOrDefault(s => s.ProductId == product.Id
                                                                            && s.Size == line.Size
                                                                            && s.Color == line.Color);
                    if (matchingStock != null)
                    {
                        matchingStock.Quantity -= line.Quantity;
                    }
                }

                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }

        public void DeleteOrder(Order order) => Delete(order);

        public IQueryable<Order> Orders =>
            _context.Orders
            .Include(o => o.Lines)
            .ThenInclude(cl => cl.Product)
            .OrderBy(o => o.Shipped)
            .ThenByDescending(o => o.OrderId);

        public IQueryable<Order> GetOrdersWithParameters(OrderRequestParameters requestParameters)
        {
            var query = _context.Orders
            .Include(o => o.Lines)
            .ThenInclude(cl => cl.Product)
            .OrderBy(o => o.Shipped)
            .ThenByDescending(o => o.OrderId)
            .ToPaginate(requestParameters.PageNumber, requestParameters.PageSize);
            return query;
        }
        public IQueryable<Order> FindAllOrdersWithUserId(OrderRequestParameters requestParameters)
        {
            if (requestParameters.Shipped != null)
            {
                return _context.Orders
                        .Include(o => o.Lines)
                        .ThenInclude(cl => cl.Product)
                        .Include(u => u.CustomUser)
                        .FindAllByCondition(u => u.UserId.Equals(requestParameters.UserId) && u.Shipped == requestParameters.Shipped)
                        .ToPaginate(requestParameters.PageNumber, requestParameters.PageSize);
            }
            else
            {
				return _context.Orders
						.Include(o => o.Lines)
						.ThenInclude(cl => cl.Product)
						.Include(u => u.CustomUser)
						.FindAllByCondition(u => u.UserId.Equals(requestParameters.UserId))
						.ToPaginate(requestParameters.PageNumber, requestParameters.PageSize);
			}

             
        }
        public IQueryable<Order> OrderCount(string userID)
        {
                return _context.Orders
                        .FindAllByCondition(u => u.UserId.Equals(userID));
        }
        public Order? GetOneOrder(int orderId)
        {
            return _context.Orders
                .Include(o => o.Lines)
                .ThenInclude(cl => cl.Product)
                .FindById(orderId);
        }

        public Order? GetOneOrderForComplete(int orderId)
        {
            var Order = _context.Orders
                .Include(o => o.Lines)
                .ThenInclude(cl => cl.Product)
                .FirstOrDefault(o => o.OrderId == orderId);
            return Order;
        }
        public void UpdateOrder(Order order) => Update(order);

        public void MarkAsShipped(int orderId)
        {
            var order = GetOneOrder(orderId);
            if (order != null)
            {
                order.Shipped = true;
                Update(order);
            }
        }

        public IQueryable<Order> FindAllOrders() => FindAll(false);

        
    }


}
