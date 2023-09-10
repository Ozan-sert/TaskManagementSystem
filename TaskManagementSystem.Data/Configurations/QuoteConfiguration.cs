using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagementSystem.Core.Models;

namespace TaskManagementSystem.Data.Configurations;

public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
{
    public void Configure(EntityTypeBuilder<Quote> builder)
    {
        // Configure the properties of the Quote entity here.
        builder.HasKey(q => q.QuoteID);
       // builder.Property(q => q.QuoteType).HasMaxLength(255).IsRequired();
        //builder.Property(q => q.QuoteType).IsRequired();
        var quoteTypeConverter = new EnumToStringConverter<QuoteType>();
        builder
            .Property(q => q.QuoteType)
            .IsRequired()
            .HasConversion(quoteTypeConverter);
        builder.Property(q => q.Description).HasMaxLength(1000);
        builder.Property(q => q.DueDate).IsRequired();
        builder.Property(q => q.Premium).HasColumnType("decimal(18, 2)").IsRequired();
        builder.Property(q => q.Sales).IsRequired();

    }
}