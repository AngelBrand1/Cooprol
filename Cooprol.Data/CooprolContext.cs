using System;
using System.Collections.Generic;
using System.Reflection;
using Cooprol.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cooprol.Data;

public class CooprolContext : DbContext
{

    public CooprolContext(DbContextOptions<CooprolContext> options)
        : base(options)
    {
    }

    public  DbSet<Bill> Bills { get; set; }

    public  DbSet<Producer> Producers { get; set; }
    // public  DbSet<User> Users { get; set; }
    // public  DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

}
