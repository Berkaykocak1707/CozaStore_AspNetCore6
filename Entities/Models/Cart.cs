using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines
        {
            get; set;
        }
        public Cart()
        {
            Lines = new List<CartLine>();
        }
        
        public virtual void AddItem(Product product, int quantity,string size,string color)
        {
            CartLine? line = Lines.Where(l => l.Product.Id.Equals(product.Id) && l.Size == size && l.Color == color).FirstOrDefault();

            if (line is null)
            {
                Lines.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity,
                    Size = size,
                    Color = color
                });
            }
            else
            {
                line.Quantity += quantity;
            }

        }
        public virtual void UpdateItemQuantity(Product product, int quantity, string size, string color)
        {
            CartLine? line = Lines.Where(l => l.Product.Id.Equals(product.Id) && l.Size == size && l.Color == color).FirstOrDefault();
			if (line != null)
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveItemQuantity(Product product, int quantity, string size, string color)
		{
			CartLine? line = Lines.Where(l => l.Product.Id.Equals(product.Id) && l.Size == size && l.Color == color).FirstOrDefault();
			if (line != null)
			{
				line.Quantity -= quantity;
                if (line.Quantity <= 0)
                {
                    RemoveLine(product,size,color);
                }
            }
        }
        public virtual void RemoveLine(Product product, string size, string color) =>
            Lines.RemoveAll(l => l.Product.Id.Equals(product.Id) && l.Size == size && l.Color == color);
        public decimal ComputeTotalQuantity() =>
            Lines.Sum(e => e.Quantity);

        public decimal ComputeTotalValue(int? coupon)
        {
            var subTotal = Lines.Sum(e => e.Product.Price * e.Quantity);

            if (coupon == 0 || coupon == null)
            {
                return subTotal;
            }
            else
            {
                var discount = (subTotal * coupon) / 100;
                return (decimal)(subTotal - discount);
            }
        }
            

        public virtual void Clear() => Lines.Clear();
    }
}
