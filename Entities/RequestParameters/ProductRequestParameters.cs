using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParameters
{
    public class ProductRequestParameters : RequestParameters
    {
        public int? CategoryID
        {
            get; set;
        }
		public string? CategorySlug
		{
			get; set;
		}
		public int? ProductId
		{
            get; set;
        }
        public int MinPrice { get; set; } = 0;
        public int MaxPrice { get; set; } = int.MaxValue;
        public bool IsValidPrice => MaxPrice > MinPrice;
        public int SortBy
        {
            get;
            set;
        }
        public string Color { get; set; }
        public int PageNumber
        {
            get; set;
        }
        public int PageSize
        {
            get; set;
        }
        public ProductRequestParameters() : this(1, 5)
        {

        }
        public ProductRequestParameters(int pageNumber = 1, int pageSize = 5)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

    }
}
