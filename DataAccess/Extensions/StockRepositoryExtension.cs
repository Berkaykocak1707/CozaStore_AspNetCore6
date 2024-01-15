using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Extensions
{
    public static class StockRepositoryExtension
    {
        // Eğer stokları belirli bir ürüne göre filtrelemek istiyorsanız
        public static IQueryable<Stock> FilteredByProductId(this IQueryable<Stock> stocks, int? productId)
        {
            if (productId is null || productId == 0)
                return stocks;
            else
                return stocks.Where(stk => stk.ProductId == productId);
        }

        public static IQueryable<Stock> ToPaginate(this IQueryable<Stock> stocks, int pageNumber, int pageSize)
        {
            return stocks
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        public static IQueryable<Stock> FindInclude(this IQueryable<Stock> stocks, params Expression<Func<Stock, object>>[] includes)
        {
            if (includes != null)
                return includes.Aggregate(stocks, (current, include) => current.Include(include));
            else
                return stocks;
        }
        public static Stock FindByIdInclude(this IQueryable<Stock> stocks, int? stockId, params Expression<Func<Stock, object>>[] includes)
        {
            IQueryable<Stock> query = stocks;

            // Includes uygula
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            // Belirli bir ID'ye göre stock nesnesini bul
            return query.FirstOrDefault(s => s.StockId == stockId);
        }


        public static IQueryable<Stock> FindAllByCondition(this IQueryable<Stock> stocks, Func<Stock, bool> condition = null)
        {
            if (condition != null)
            {
                stocks = stocks.Where(condition).AsQueryable();
            }

            return stocks;
        }
    }
}
