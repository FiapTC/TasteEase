﻿using Fiap.TasteEase.Infra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fiap.TasteEase.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<OrderModel> Orders { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder
                .Entity<OrderModel>()
                .Property(e => e.Status)
                .HasConversion(new EnumToStringConverter<OrderStatusModel>());
            
            base.OnModelCreating(modelBuilder);
        }
        
        protected sealed override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                .HaveConversion(typeof(DateTimeToDateTimeUtc));
        }
    }

    public class DateTimeToDateTimeUtc : ValueConverter<DateTime, DateTime>
    {
        public DateTimeToDateTimeUtc() : 
            base(c => DateTime.SpecifyKind(c, DateTimeKind.Unspecified), c => c) { }
    }
}