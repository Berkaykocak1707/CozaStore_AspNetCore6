using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StockConfig : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(o => o.StockId);
		builder.HasData(
						new Stock
						{
							StockId = 1,
							ProductId = 1,
							Size = "XL",
							Color = "Snow",
							Quantity = 5
						},
						new Stock
						{
							StockId = 2,
							ProductId = 2,
							Size = "S",
							Color = "Black",
							Quantity = 5
						},
						new Stock
						{
							StockId = 3,
							ProductId = 3,
							Size = "M",
							Color = "Pink",
							Quantity = 5
						},
						new Stock
						{
							StockId = 4,
							ProductId = 4,
							Size = "XS",
							Color = "White",
							Quantity = 5
						},
						new Stock
						{
							StockId = 5,
							ProductId = 5,
							Size = "L",
							Color = "Black",
							Quantity = 5
						},
						new Stock
						{
							StockId = 6,
							ProductId = 6,
							Size = "Fix",
							Color = "Black",
							Quantity = 20
						},
						new Stock
						{
							StockId = 7,
							ProductId = 7,
							Size = "Fix",
							Color = "Silver",
							Quantity = 10
						},
						new Stock
						{
							StockId = 8,
							ProductId = 8,
							Size = "Fix",
							Color = "Maroon (Fedora)",
							Quantity = 5
						},
						new Stock
						{
							StockId = 9,
							ProductId = 9,
							Size = "Fix",
							Color = "Straw",
							Quantity = 5
						},
						new Stock
						{
							StockId = 10,
							ProductId = 10,
							Size = "Fix",
							Color = "Silver Band",
							Quantity = 10
						},
						new Stock
						{
							StockId = 11,
							ProductId = 11,
							Size = "Fix",
							Color = "Black",
							Quantity = 12
						},
						new Stock
						{
							StockId = 12,
							ProductId = 12,
							Size = "Fix",
							Color = "Black",
							Quantity = 5
						},
						new Stock
						{
							StockId = 13,
							ProductId = 13,
							Size = "XL",
							Color = "Dark Navy",
							Quantity = 5
						},
						new Stock
						{
							StockId = 14,
							ProductId = 14,
							Size = "XL",
							Color = "Light Grey",
							Quantity = 5
						},
						new Stock
						{
							StockId = 15,
							ProductId = 15,
							Size = "XL",
							Color = "Charcoal Grey",
							Quantity = 5
						},
						new Stock { StockId = 16, ProductId = 1, Size = "XL", Color = "Blue", Quantity = 10 },
						new Stock { StockId = 17, ProductId = 1, Size = "XL", Color = "Orange", Quantity = 10 },
						new Stock { StockId = 18, ProductId = 1, Size = "L", Color = "Orange", Quantity = 11 },
						new Stock { StockId = 19, ProductId = 1, Size = "L", Color = "Blue", Quantity = 1 },
						new Stock { StockId = 20, ProductId = 1, Size = "M", Color = "Purple", Quantity = 10 },
						new Stock { StockId = 21, ProductId = 1, Size = "M", Color = "Red", Quantity = 15 },
						new Stock { StockId = 22, ProductId = 1, Size = "S", Color = "Orange", Quantity = 6 },
						new Stock { StockId = 23, ProductId = 1, Size = "S", Color = "Blue", Quantity = 12 },
						new Stock { StockId = 24, ProductId = 2, Size = "XL", Color = "Orange", Quantity = 1 },
						new Stock { StockId = 25, ProductId = 2, Size = "XL", Color = "Orange", Quantity = 9 },
						new Stock { StockId = 26, ProductId = 2, Size = "L", Color = "Yellow", Quantity = 14 },
						new Stock { StockId = 27, ProductId = 2, Size = "L", Color = "Green", Quantity = 8 },
						new Stock { StockId = 28, ProductId = 2, Size = "M", Color = "Red", Quantity = 4 },
						new Stock { StockId = 29, ProductId = 2, Size = "M", Color = "Purple", Quantity = 5 },
						new Stock { StockId = 30, ProductId = 2, Size = "S", Color = "Purple", Quantity = 13 },
						new Stock { StockId = 31, ProductId = 2, Size = "S", Color = "Purple", Quantity = 10 },
						new Stock { StockId = 32, ProductId = 3, Size = "XL", Color = "Yellow", Quantity = 4 },
						new Stock { StockId = 33, ProductId = 3, Size = "XL", Color = "Red", Quantity = 4 },
						new Stock { StockId = 34, ProductId = 3, Size = "L", Color = "Blue", Quantity = 2 },
						new Stock { StockId = 35, ProductId = 3, Size = "L", Color = "Purple", Quantity = 1 },
						new Stock { StockId = 36, ProductId = 3, Size = "M", Color = "Red", Quantity = 8 },
						new Stock { StockId = 37, ProductId = 3, Size = "M", Color = "Red", Quantity = 2 },
						new Stock { StockId = 38, ProductId = 3, Size = "S", Color = "Blue", Quantity = 6 },
						new Stock { StockId = 39, ProductId = 3, Size = "S", Color = "Green", Quantity = 5 },
						new Stock { StockId = 40, ProductId = 4, Size = "XL", Color = "Red", Quantity = 1 },
						new Stock { StockId = 41, ProductId = 4, Size = "XL", Color = "Orange", Quantity = 9 },
						new Stock { StockId = 42, ProductId = 4, Size = "L", Color = "Orange", Quantity = 14 },
						new Stock { StockId = 43, ProductId = 4, Size = "L", Color = "Orange", Quantity = 10 },
						new Stock { StockId = 44, ProductId = 4, Size = "M", Color = "Purple", Quantity = 4 },
						new Stock { StockId = 45, ProductId = 4, Size = "M", Color = "Purple", Quantity = 15 },
						new Stock { StockId = 46, ProductId = 4, Size = "S", Color = "Green", Quantity = 2 },
						new Stock { StockId = 47, ProductId = 4, Size = "S", Color = "Purple", Quantity = 15 },
						new Stock { StockId = 48, ProductId = 5, Size = "XL", Color = "Green", Quantity = 8 },
						new Stock { StockId = 49, ProductId = 5, Size = "XL", Color = "Purple", Quantity = 14 },
						new Stock { StockId = 50, ProductId = 5, Size = "L", Color = "Red", Quantity = 7 },
						new Stock { StockId = 51, ProductId = 5, Size = "L", Color = "Blue", Quantity = 11 },
						new Stock { StockId = 52, ProductId = 5, Size = "M", Color = "Green", Quantity = 1 },
						new Stock { StockId = 53, ProductId = 5, Size = "M", Color = "Yellow", Quantity = 4 },
						new Stock { StockId = 54, ProductId = 5, Size = "S", Color = "Yellow", Quantity = 7 },
						new Stock { StockId = 55, ProductId = 5, Size = "S", Color = "Purple", Quantity = 9 },
						new Stock { StockId = 56, ProductId = 6, Size = "Fix", Color = "Yellow", Quantity = 3 },
						new Stock { StockId = 57, ProductId = 6, Size = "Fix", Color = "Purple", Quantity = 3 },
						new Stock { StockId = 58, ProductId = 6, Size = "Fix", Color = "Orange", Quantity = 7 },
						new Stock { StockId = 59, ProductId = 7, Size = "Fix", Color = "Green", Quantity = 7 },
						new Stock { StockId = 60, ProductId = 7, Size = "Fix", Color = "Green", Quantity = 7 },
						new Stock { StockId = 61, ProductId = 7, Size = "Fix", Color = "Blue", Quantity = 7 },
						new Stock { StockId = 62, ProductId = 8, Size = "Fix", Color = "Green", Quantity = 15 },
						new Stock { StockId = 63, ProductId = 8, Size = "Fix", Color = "Yellow", Quantity = 8 },
						new Stock { StockId = 64, ProductId = 8, Size = "Fix", Color = "Red", Quantity = 5 },
						new Stock { StockId = 65, ProductId = 9, Size = "Fix", Color = "Blue", Quantity = 5 },
						new Stock { StockId = 66, ProductId = 9, Size = "Fix", Color = "Red", Quantity = 14 },
						new Stock { StockId = 67, ProductId = 9, Size = "Fix", Color = "Yellow", Quantity = 8 },
						new Stock { StockId = 68, ProductId = 10, Size = "Fix", Color = "Orange", Quantity = 15 },
						new Stock { StockId = 69, ProductId = 10, Size = "Fix", Color = "Blue", Quantity = 2 },
						new Stock { StockId = 70, ProductId = 10, Size = "Fix", Color = "Yellow", Quantity = 14 },
						new Stock { StockId = 71, ProductId = 11, Size = "Fix", Color = "Yellow", Quantity = 14 },
						new Stock { StockId = 72, ProductId = 11, Size = "Fix", Color = "Red", Quantity = 8 },
						new Stock { StockId = 73, ProductId = 11, Size = "Fix", Color = "Green", Quantity = 6 },
						new Stock { StockId = 74, ProductId = 12, Size = "Fix", Color = "Blue", Quantity = 14 },
						new Stock { StockId = 75, ProductId = 12, Size = "Fix", Color = "Blue", Quantity = 11 },
						new Stock { StockId = 76, ProductId = 12, Size = "Fix", Color = "Orange", Quantity = 6 },
						new Stock { StockId = 77, ProductId = 13, Size = "XL", Color = "Purple", Quantity = 3 },
						new Stock { StockId = 78, ProductId = 13, Size = "XL", Color = "Green", Quantity = 9 },
						new Stock { StockId = 79, ProductId = 13, Size = "L", Color = "Red", Quantity = 1 },
						new Stock { StockId = 80, ProductId = 13, Size = "L", Color = "Yellow", Quantity = 6 },
						new Stock { StockId = 81, ProductId = 13, Size = "M", Color = "Green", Quantity = 3 },
						new Stock { StockId = 82, ProductId = 13, Size = "M", Color = "Orange", Quantity = 3 },
						new Stock { StockId = 83, ProductId = 13, Size = "S", Color = "Purple", Quantity = 1 },
						new Stock { StockId = 84, ProductId = 13, Size = "S", Color = "Purple", Quantity = 12 },
						new Stock { StockId = 85, ProductId = 14, Size = "XL", Color = "Yellow", Quantity = 9 },
						new Stock { StockId = 86, ProductId = 14, Size = "XL", Color = "Yellow", Quantity = 15 },
						new Stock { StockId = 87, ProductId = 14, Size = "L", Color = "Orange", Quantity = 6 },
						new Stock { StockId = 88, ProductId = 14, Size = "L", Color = "Red", Quantity = 3 },
						new Stock { StockId = 89, ProductId = 14, Size = "M", Color = "Purple", Quantity = 7 },
						new Stock { StockId = 90, ProductId = 14, Size = "M", Color = "Yellow", Quantity = 4 },
						new Stock { StockId = 91, ProductId = 14, Size = "S", Color = "Orange", Quantity = 12 },
						new Stock { StockId = 92, ProductId = 14, Size = "S", Color = "Green", Quantity = 12 },
						new Stock { StockId = 93, ProductId = 15, Size = "XL", Color = "Green", Quantity = 14 },
						new Stock { StockId = 94, ProductId = 15, Size = "XL", Color = "Orange", Quantity = 1 },
						new Stock { StockId = 95, ProductId = 15, Size = "L", Color = "Orange", Quantity = 1 },
						new Stock { StockId = 96, ProductId = 15, Size = "L", Color = "Red", Quantity = 9 },
						new Stock { StockId = 97, ProductId = 15, Size = "M", Color = "Purple", Quantity = 8 },
						new Stock { StockId = 98, ProductId = 15, Size = "M", Color = "Green", Quantity = 14 },
						new Stock { StockId = 99, ProductId = 15, Size = "S", Color = "Purple", Quantity = 8 },
						new Stock { StockId = 100, ProductId = 15, Size = "S", Color = "Purple", Quantity = 14 },
						new Stock { StockId = 101, ProductId = 16, Size = "Fix", Color = "Red", Quantity = 6 },
						new Stock { StockId = 102, ProductId = 16, Size = "Fix", Color = "Blue", Quantity = 1 },
						new Stock { StockId = 103, ProductId = 16, Size = "Fix", Color = "Yellow", Quantity = 9 });

	}
}
