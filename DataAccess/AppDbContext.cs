﻿using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Account> Accounts { get; set; }
    public DbSet<BadmintonCourt> BadmintonCourts { get; set; }
    public DbSet<Court> Courts { get; set; }
    public DbSet<ServiceCourt> ServiceCourts { get; set; }
    public DbSet<Slot> Slots { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<BookingSlot> BookingSlots { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());
    }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        return configuration.GetConnectionString("DefaultConnectionString") ?? "";
    }
}