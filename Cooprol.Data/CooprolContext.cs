using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Cooprol.Data.Models;
namespace Cooprol.Data;

public class CooprolContext: DbContext
{
    public CooprolContext(
        DbContextOptions<CooprolContext> options): base(options)
    {

    }
    public DbSet<Producer> Producers {get; set;}
    public DbSet<Bill> Bills {get; set;}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        if(builder == null)
        {
            return;
        }
        builder.Entity<Producer>().ToTable("Producer").HasKey(k => k.Id);
        builder.Entity<Bill>().ToTable("Bill").HasKey(k => k.Id);
        base.OnModelCreating(builder);
    }
}