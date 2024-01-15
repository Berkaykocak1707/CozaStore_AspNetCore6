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
    public static class ProductRepositoryExtension
    {
        public static IQueryable<Product> FilteredByCategorySlug(this IQueryable<Product> product,string? CategorySlug)
        {
            if (CategorySlug is null)
                return product;
            else
                return product.Where(prd => prd.Category.Slug.Equals(CategorySlug));
        }
        public static IQueryable<Product> ToPaginate(this IQueryable<Product> product,
            int pageNumber, int pageSize)
        {
            return product
                .Skip(((pageNumber - 1) * pageSize))
                .Take(pageSize);
        }
        public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products,
            String? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return products;
            else
                return products.Where(prd => prd.Name.ToLower()
                    .Contains(searchTerm.ToLower()));
        }
        public static IQueryable<Product> FilteredSortBy(this IQueryable<Product> products, int orderType)
        {
            //Default 1
            //Newness 2 
            //Low to High 3 
            //High to Low 4
            if (orderType == null)
            {
                return products;
            }
            else if (orderType <1 || orderType > 4)
            {
                return products;
            }
            else
            {
                switch (orderType)
                {
                    case 1: // Default
                        return products.OrderBy(prd => prd.Id); // Default sort by ID

                    case 2: // Newness
                        return products.OrderByDescending(prd => prd.Id); // Sort by newest products on top.

                    case 3: // Low to High
                        return products.OrderBy(prd => prd.Price); // Sort from low to high price.

                    case 4: // High to Low
                        return products.OrderByDescending(prd => prd.Price); // Sort from high to low price.


                    default:
                        throw new ArgumentOutOfRangeException(nameof(orderType), "Invalid order type");
                }
            }  
        }
        public static IQueryable<Product> FilteredByColor(this IQueryable<Product> products, string? color)
        {
            if (string.IsNullOrWhiteSpace(color))
                return products;
            else
				return products.Where(product => product.Stocks.Any(stock => stock.Color.ToLower().Contains(color.ToLower())));
		}
        public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products,
            int minPrice, int maxPrice, bool isValidPrice)
        {
            if (minPrice < maxPrice)
                    isValidPrice = true;
            else
                    isValidPrice = false;

            if (isValidPrice)
                return products.Where(prd => prd.Price >= minPrice && prd.Price <= maxPrice);
            else
                return products;
        }
        public static IQueryable<Product> FindInclude(this IQueryable<Product> product,  params Expression<Func<Product, object>>[] includes)
         {
            if (includes != null)
               return product = includes.Aggregate(product, (current, include) => current.Include(include));
            else   
               return product;
        }
        public static IQueryable<Product> FindAllByCondition(this IQueryable<Product> product, Func<Product, bool> condition = null)
        {

            if (condition != null)
            {
                product = product.Where(condition).AsQueryable();
            }

            return product;
        }

    }
}
