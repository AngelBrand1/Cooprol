using Cooprol.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("User");

        builder.Property(e => e.Name)
        .HasColumnName("name");
        builder.Property(e => e.NumberCc)
        .HasColumnName("numbercc");
        builder.Property(e => e.Email)
        .HasColumnName("email");
        builder.Property(e => e.UserName)
        .HasColumnName("numbercc");
        builder.Property(e => e.Password)
        .HasColumnName("password");

        builder.
        HasMany(e => e.Roles)
        .WithMany(r => r.Users)
        .UsingEntity<UserRole>(
            j => j
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRole)
            .HasForeignKey(ur => ur.IdRole),

            j => j
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRole)
            .HasForeignKey(u => u.IdUser),
            
            j => 
            {
                j.HasKey(ur => new {ur.IdRole, ur.IdUser});
            }

        );
    
    }
    
}