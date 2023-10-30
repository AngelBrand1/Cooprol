using Cooprol.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
{
    public void Configure(EntityTypeBuilder<Producer> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("Producer");

        builder.Property(e => e.CellNumber).HasColumnName("cellNumber");
        builder.Property(e => e.IsActive).HasColumnName("isActive");
        builder.Property(e => e.Name).HasColumnName("name");
        builder.Property(e => e.NumberCc).HasColumnName("numberCc");

        builder
        .HasMany(p => p.Bills)
        .WithOne(b => b.IdProducerNavigation)
        .HasForeignKey(b => b.IdProducer)
        .IsRequired();
    }
}