using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InformationConfig : IEntityTypeConfiguration<Information>
{
    public void Configure(EntityTypeBuilder<Information> builder)
    {
        builder.HasKey(o => o.InfoId);
        builder.HasData(
        new Information
        {
            InfoId = 1,
            Address = "123 Main St, Anytown, USA",
            Phone = "(123) 456-7890",
            Email = "contact@example.com",
            IsActive = true
        });
    }
}
