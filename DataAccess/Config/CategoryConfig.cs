using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(o => o.Id);
		builder.HasData(
			new Category
			{
				Id = 1,
				Name = "Men",
				Slug = "men"
			},
			new Category
			{
				Id = 2,
				Name = "Women",
				Slug = "women"
			},
			new Category
			{
				Id = 3,
				Name = "Bag",
				Slug = "bag"
			},
			new Category
			{
				Id = 4,
				Name = "Watch",
				Slug = "watch"
			},
			new Category
			{
				Id = 5,
				Name = "Hat",
				Slug = "hat"
			},
			new Category
			{
				Id = 6,
				Name = "Glasses",
				Slug = "glasses"
			});

	}
}
