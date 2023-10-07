using Cooprol.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Cooprol.Data.Configuration;
public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("Role");

     

        // builder.HasOne(d => d.IdProducerNavigation).WithMany(p => p.Bills)
        //     .HasForeignKey(d => d.IdProducer)
        //         .HasConstraintName("Bill_ibfk_1");
    }
}