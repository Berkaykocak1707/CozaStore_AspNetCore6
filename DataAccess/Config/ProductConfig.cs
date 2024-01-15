using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(o => o.Id);
		builder.HasData(
		new Product
		{
			Id = 1,
			Slug = "elegant-winter-jacket",
			Name = "Elegant Winter Jacket",
			SKU = "EWJ456",
			Description = "A modern and elegant black winter jacket. Long-sleeved, with a collar and belted waist.",
			CategoryId = 2,
			Price = 500,
			Weight = 800,
			Dimensions = "Length: 70 cm, Chest: 100 cm, Sleeve: 60 cm",
			Materials = "Wool Blend",
			Color = "Snow",
			Photo1Url = "/img/elegant-winter-jacket66.png",
			Photo2Url = "/img/elegant-winter-jacket15.png",
			IsActive = false
		},
		new Product
		{
			Id = 2,
			Slug = "chic-contemporary-outfit",
			Name = "Chic Contemporary Outfit",
			SKU = "CCO789",
			Description = "A chic and contemporary ensemble, featuring luxurious textures and sophisticated styling.",
			CategoryId = 2,
			Price = 350,
			Weight = 500,
			Dimensions = "Vary based on size",
			Materials = "Mixed Fabrics",
			Color = "Multi-color",
			Photo1Url = "/img/chic-contemporary-outfit56.png",
			Photo2Url = "/img/chic-contemporary-outfit62.png",
			IsActive = false
		},
		new Product
		{
			Id = 3,
			Slug = "business-casual-outfit",
			Name = "Business Casual Outfit",
			SKU = "BCO1012",
			Description = "A chic business casual outfit, perfect for a professional setting. Features a high-waisted skirt and a sophisticated blouse.",
			CategoryId = 2,
			Price = 450,
			Weight = 550,
			Dimensions = "Vary based on size",
			Materials = "Cotton Blend",
			Color = "Beige and Pink",
			Photo1Url = "/img/business-casual-outfit74.png",
			Photo2Url = "/img/business-casual-outfit83.png",
			IsActive = false
		},
		new Product
		{
			Id = 4,
			Slug = "trendy-casual-outfit",
			Name = "Trendy Casual Outfit",
			SKU = "TCO1315",
			Description = "A casual yet trendy outfit, featuring a fitted white t-shirt and stylish pants.",
			CategoryId = 2,
			Price = 200,
			Weight = 300,
			Dimensions = "Vary based on size",
			Materials = "Cotton and Elastane",
			Color = "White and Blue",
			Photo1Url = "/img/trendy-casual-outfit71.png",
			Photo2Url = "/img/trendy-casual-outfit23.png",
			IsActive = false
		},
		new Product
		{
			Id = 5,
			Slug = "classic-evening-outfit",
			Name = "Classic Evening Outfit",
			SKU = "CEO1618",
			Description = "A sophisticated classic evening outfit, featuring a black off-the-shoulder dress.",
			CategoryId = 2,
			Price = 450,
			Weight = 450,
			Dimensions = "Vary based on size",
			Materials = "Satin",
			Color = "Black",
			Photo1Url = "/img/classic-evening-outfit11.png",
			Photo2Url = "/img/classic-evening-outfit17.png",
			IsActive = false
		},
		new Product
		{
			Id = 6,
			Slug = "classic-eyeglasses",
			Name = "Classic Eyeglasses",
			SKU = "CLSEG101",
			Description = "Stylish eyeglasses with a classic, sophisticated design. Features a timeless frame suitable for any occasion.",
			CategoryId = 6,
			Price = 150,
			Weight = 30,
			Dimensions = "Frame Width: 140 mm, Lens Height: 40 mm, Lens Width: 50 mm",
			Materials = "Metal and Plastic",
			Color = "Black",
			Photo1Url = "/img/classic-eyeglasses47.png",
			IsActive = false
		},
		new Product
		{
			Id = 7,
			Slug = "fashionable-rimless-eyeglasses",
			Name = "Fashionable Rimless Eyeglasses",
			SKU = "FRE102",
			Description = "A pair of delicate, rimless eyeglasses, showcasing a modern and lightweight design.",
			CategoryId = 6,
			Price = 350,
			Weight = 25,
			Dimensions = "Frame Width: 13.5 cm, Lens Height: 3.5 cm, Lens Width: 5 cm",
			Materials = "Metal and Polycarbonate",
			Color = "Silver",
			Photo1Url = "/img/fashionable-rimless-eyeglasses76.png",
			IsActive = false
		},
		new Product
		{
			Id = 8,
			Slug = "contemporary-round-eyeglasses",
			Name = "Contemporary Round Eyeglasses",
			SKU = "CRE103",
			Description = "A pair of contemporary eyeglasses featuring a round frame with a stylish and modern design.",
			CategoryId = 6,
			Price = 320,
			Weight = 28,
			Dimensions = "Frame Width: 14 cm, Lens Height: 4.2 cm, Lens Width: 4.5 cm",
			Materials = "Acetate",
			Color = "Brown",
			Photo1Url = "/img/contemporary-round-eyeglasses37.png",
			IsActive = false
		},
		new Product
		{
			Id = 9,
			Slug = "sophisticated-fedora-and-casual-cap",
			Name = "Sophisticated Fedora and Casual Cap",
			SKU = "HATCOMBO1920",
			Description = "This set features a sophisticated maroon fedora with a wide black band and a casual denim cap. The fedora offers an air of elegance, while the cap is perfect for everyday wear.",
			CategoryId = 5,
			Price = 50,
			Weight = 2.5E+152,
			Dimensions = "Fedora - One size fits all; Cap - Adjustable strap",
			Materials = "Wool blend (Fedora), Denim (Cap)",
			Color = "Maroon (Fedora), Blue (Cap)",
			Photo1Url = "/img/sophisticated-fedora-and-casual-cap92.png",
			IsActive = false
		},
		new Product
		{
			Id = 10,
			Slug = "elegant-wide-brimmed-sun-hat-and-knit-beanie",
			Name = "Elegant Wide-Brimmed Sun Hat and Knit Beanie",
			SKU = "HATSET2122",
			Description = "A dual-season hat set featuring an elegant, wide-brimmed sun hat in a dual-tone of sand and teal, complete with a black ribbon, and a cozy knit beanie with a playful pompom.",
			CategoryId = 5,
			Price = 60,
			Weight = 200,
			Dimensions = "Sun Hat - One size Beanie - Stretch fit",
			Materials = "Straw (Sun Hat), Acrylic knit (Beanie)",
			Color = "Sand and Teal (Sun Hat), Teal (Beanie)",
			Photo1Url = "/img/elegant-wide-brimmed-sun-hat-and-knit-beanie57.png",
			IsActive = false
		},
		new Product
		{
			Id = 11,
			Slug = "mens-classic-blue-dial-watch",
			Name = "Men's Classic Blue Dial Watch",
			SKU = "MCBDW3132",
			Description = "This men's wristwatch features a sophisticated design with a silver stainless steel band and a striking dark blue dial. The watch includes a date function and is water-resistant.",
			CategoryId = 4,
			Price = 250,
			Weight = 120,
			Dimensions = "Case Diameter - 40 mm, Band Width - 20 mm",
			Materials = "Stainless Steel",
			Color = "Silver Band",
			Photo1Url = "/img/mens-classic-blue-dial-watch70.png",
			IsActive = false
		},
		new Product
		{
			Id = 12,
			Slug = "unisex-digital-smartwatch",
			Name = "Unisex Digital Smartwatch",
			SKU = "UDSW3334",
			Description = "A modern digital smartwatch with a sleek black rubber band and a large, rectangular digital display. It is designed for both men and women and comes with various smart features such as activity tracking and notifications.",
			CategoryId = 4,
			Price = 300,
			Weight = 100,
			Dimensions = "Case Height - 44 mm, Case Width - 35 mm, Band Width - 22 mm",
			Materials = "Rubber, Glass",
			Color = "Black",
			Photo1Url = "/img/unisex-digital-smartwatch78.png",
			IsActive = false
		},
		new Product
		{
			Id = 13,
			Slug = "minimalist-unisex-timepiece",
			Name = "Minimalist Unisex Timepiece",
			SKU = "MUTW3536",
			Description = "This minimalist timepiece showcases a modern aesthetic with a simple yet elegant design. Suitable for all genders, it features a slim profile, a matte black or rose gold case, and a comfortable strap.",
			CategoryId = 4,
			Price = 150,
			Weight = 80,
			Dimensions = "Case Diameter - 38 mm, Band Width - 18 mm",
			Materials = "Metal, Leather",
			Color = "Black or Rose Gold",
			Photo1Url = "/img/minimalist-unisex-timepiece64.png",
			IsActive = false
		},
		new Product
		{
			Id = 14,
			Slug = "modern-slim-fit-navy-suit",
			Name = "Modern Slim-Fit Navy Suit",
			SKU = "MSFNS3739",
			Description = "This suit features a contemporary design with a dark navy slim-fit blazer and matching trousers. The outfit is tailored to offer a sleek silhouette, perfect for business meetings or formal events.",
			CategoryId = 1,
			Price = 350,
			Weight = 1200,
			Dimensions = "Size varies by selection",
			Materials = "Wool Blend",
			Color = "Dark Navy",
			Photo1Url = "/img/modern-slim-fit-navy-suit14.png",
			Photo2Url = "/img/modern-slim-fit-navy-suit63.png",
			IsActive = false
		},
		new Product
		{
			Id = 15,
			Slug = "trendy-casual-mens-outfit",
			Name = "Trendy Casual Men's Outfit",
			SKU = "TCMO4042",
			Description = "A fashionable and relaxed outfit, perfect for casual outings. This set features a light grey, crew-neck sweater made from a soft, breathable knit, paired with dark denim jeans and complemented by classic white sneakers.",
			CategoryId = 1,
			Price = 180,
			Weight = 1000,
			Dimensions = "Size varies by selection",
			Materials = "Cotton Knit (Sweater), Denim (Jeans), Leather (Sneakers)",
			Color = "Light Grey",
			Photo1Url = "/img/trendy-casual-mens-outfit99.png",
			Photo2Url = "/img/trendy-casual-mens-outfit8.png",
			IsActive = false
		},
		new Product
		{
			Id = 16,
			Slug = "smart-casual-mens-outfit",
			Name = "Smart Casual Men's Outfit",
			SKU = "SCMO4344",
			Description = "A refined and versatile outfit suitable for various occasions. The ensemble includes a tailored charcoal grey wool blazer, a classic white dress shirt, dark navy dress trousers, and brown leather Oxford shoes.",
			CategoryId = 1,
			Price = 350,
			Weight = 1500,
			Dimensions = "Size varies by selection",
			Materials = "Wool",
			Color = "Charcoal Grey",
			Photo1Url = "/img/smart-casual-mens-outfit38.png",
			Photo2Url = "/img/smart-casual-mens-outfit14.png",
			IsActive = false
		});

	}
}
