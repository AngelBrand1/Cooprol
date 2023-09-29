using Cooprol.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("Bill");

        builder.HasIndex(e => e.IdProducer, "idProducer");

        builder.Property(e => e.DateB).HasColumnName("dateB");
        builder.Property(e => e.Deductions).HasColumnName("deductions");
        builder.Property(e => e.IdProducer).HasColumnName("idProducer");
        builder.Property(e => e.LProduced).HasColumnName("lProduced");
        builder.Property(e => e.ToPay).HasColumnName("toPay");

        builder.HasOne(d => d.IdProducerNavigation).WithMany(p => p.Bills)
            .HasForeignKey(d => d.IdProducer)
                .HasConstraintName("Bill_ibfk_1");
    }
}