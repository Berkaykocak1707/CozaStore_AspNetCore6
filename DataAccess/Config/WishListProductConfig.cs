using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class WishListProductConfig : IEntityTypeConfiguration<WishListProduct>
{
    public void Configure(EntityTypeBuilder<WishListProduct> builder)
    {
        builder.HasKey(o => o.WishListProductId);
    }
}
