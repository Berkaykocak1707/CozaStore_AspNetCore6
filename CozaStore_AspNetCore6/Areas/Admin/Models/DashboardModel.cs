using Entities.Dtos;
using Entities.Models;

namespace CozaStore_AspNetCore6.Areas.Admin.Models
{
    public class DashboardModel
    {
        public IEnumerable<CustomUser>? Users
        {
            get; set;
        } = Enumerable.Empty<CustomUser>();
        public IEnumerable<ProductDto>? Products
        {
            get;
            set;
        } = Enumerable.Empty<ProductDto>();
        public IEnumerable<OrderDto>? Orders
        {
            get;
            set;
        } = Enumerable.Empty<OrderDto>();
        public IEnumerable<ContactDto>? Contacts
        {
            get;
            set;
        } = Enumerable.Empty<ContactDto>();
    }
}
