using System.Text.Json.Serialization;
using Entities.Dtos;
using Entities.Models;
using CozaStore_AspNetCore6.Infrastructure.Extensions;

namespace CozaStore_AspNetCore6.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession? Session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()
                .HttpContext?.Session;

            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        public override void AddItem(Product product, int quantity, string size, string color)
        {
            base.AddItem(product, quantity, size, color);
            Session?.SetJson<SessionCart>("cart",this);
        }

        public override void Clear()
        {
            base.Clear();
            Session?.Remove("cart");
        }
        public override void UpdateItemQuantity(Product product, int quantity, string size, string color)
        {
            base.UpdateItemQuantity(product, quantity, size, color);
            Session?.SetJson<SessionCart>("cart", this);
        }
        public override void RemoveItemQuantity(Product product, int quantity, string size, string color)
        {
            base.RemoveItemQuantity(product, quantity, size, color);
            Session?.SetJson<SessionCart>("cart", this);
        }
        public override void RemoveLine(Product product, string size, string color)
        {
            base.RemoveLine(product,size,color);
            Session?.SetJson<SessionCart>("cart",this);
        }
    }
}